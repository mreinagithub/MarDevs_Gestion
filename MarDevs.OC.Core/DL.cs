using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using NHibernate.Cfg;
using NHibernate;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;

namespace MarDevs.OC.Core
{
    public class DL : IDisposable
    {
        #region MIEMBROS ESTATICOS

        private static string STR_ERROR_CONCURRENCIA = "El objeto que intenta actualizar ha sido modificado por otro usuario." + System.Environment.NewLine
                                                        + "La operación no pudo concretarse.";

        private static string STR_ERROR_ACCESO_DATOS = "Se ha producido un error al intentar acceder a la base de datos." + System.Environment.NewLine
                                                        + "La operación no pudo concretarse.";

        private static string STR_ERROR_ELIMINAR_FK = "Se ha producido un error al intentar eliminar el elemento." + System.Environment.NewLine
                                                        + "Hay otros elementos que dependen de él y por lo tanto no puede eliminarse.";


        private static string STR_ERROR_INSERTAR_UK = "Se ha producido un error al intentar insertar el elemento." + System.Environment.NewLine
                                                    + "Está intentando insertar un elemento que ya existe.";

        internal static Configuration config;
        internal static ISessionFactory factory;
        protected static IList<DL> sesionesAbiertas = new List<DL>();
        public static void ConfigurarNHibernate(string assembly, bool buildSession)
        {
            try
            {
                if (config == null)
                    config = new Configuration();
				config.SetDefaultAssembly("MarDevs.OC.Core");
				config.SetDefaultNamespace("MarDevs.OC.Core");
				config.SessionFactoryName("NHibernate.MarDevs");
                config.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, typeof(NHibernate.Connection.DriverConnectionProvider).AssemblyQualifiedName);
                config.SetProperty(NHibernate.Cfg.Environment.CacheProvider, typeof(NHibernate.Cache.HashtableCacheProvider).AssemblyQualifiedName);
                config.SetProperty(NHibernate.Cfg.Environment.UseQueryCache, "true");
                config.SetProperty(NHibernate.Cfg.Environment.QueryStartupChecking, "false");
                config.SetProperty(NHibernate.Cfg.Environment.QuerySubstitutions, "true 1, false 0, yes 'Y', no 'N'");
                config.SetProperty(NHibernate.Cfg.Environment.BatchSize, "10");
                config.SetProperty(NHibernate.Cfg.Environment.Isolation, "ReadCommitted");
                config.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, "none");
                config.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
                config.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, typeof(NHibernate.Driver.SqlClientDriver).AssemblyQualifiedName);
                config.SetProperty(NHibernate.Cfg.Environment.Dialect, typeof(NHibernate.Dialect.MsSql2005Dialect).AssemblyQualifiedName);
                config.SetProperty(NHibernate.Cfg.Environment.ConnectionString, ConfigBL.StringDeConexion);
                config.SetProperty(NHibernate.Cfg.Environment.ShowSql, "false");
                config.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, "444");
                config.SetProperty(NHibernate.Cfg.Environment.WrapResultSets, "false");
                config.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass, typeof(NHibernate.Bytecode.DefaultProxyFactoryFactory).AssemblyQualifiedName);
                config.AddAssembly(assembly);

                //config.Configure();
                if (buildSession)
                    factory = config.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw new ExcepcionTecnica("No se pudo agregar el ensamblado.", ex);
            }
        }
        public static DL ObtenerSesion()
        {
            return new DL();
        }
        public static void LimpiarSecondLevelCache(Type tipo)
        {
            factory.Evict(tipo);
        }

        #endregion

        public DL()
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(ConfigBL.StringDeConexion);
                session = factory.OpenSession(sqlConn, new NHInterceptor(this));
                if (session.Connection.State == ConnectionState.Closed) { session.Connection.Open(); }
                session.FlushMode = FlushMode.Auto;
                DL.sesionesAbiertas.Add(this);
            }
            catch (Exception ex)
            {
                WrapException(ex);
            }
        }

        #region VARIABLES DE INSTANCIA

        public ISession session;
        //TODO: ES PUBLIC POR AHORA, DEBE SER PROTECTED
        protected ITransaction trx = null;
        internal IList listaRestablecerId = null;

        #endregion

        #region HQL

        public void InicializarColeccion(object objeto, object coleccion)
        {
            if (NHibernateUtil.IsInitialized(coleccion))
            {
                return;
            }
            bool encontrado = false;
            foreach (DL dl in DL.sesionesAbiertas)
            {
                if (dl.session.Contains(objeto))
                {
                    //dl.session.Evict(objeto);
                    encontrado = true;
                    break;
                }
            }
            try
            {
                //session.Lock(objeto,LockMode.None);
                if (!encontrado) { session.Lock(objeto, LockMode.None); }
                NHibernateUtil.Initialize(coleccion);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public void InicializarProperty(object objeto, object property)
        {
            if (NHibernateUtil.IsInitialized(property))
            {
                return;
            }
            foreach (DL dl in DL.sesionesAbiertas)
            {
                if (dl.session.Contains(objeto))
                    dl.session.Evict(objeto);
            }
            try
            {
                session.Lock(objeto, LockMode.None);
                NHibernateUtil.Initialize(property);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public void EjecutarComandosPendientes()
        {
            try
            {
                session.Flush();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public void Guardar(IPersistente obj)
        {
            try
            {
                if (obj.IdAutogenerado())
                    session.SaveOrUpdate(obj);
                else
                {
                    if (obj.EsNuevo())
                        session.Save(obj);
                    else
                        session.Update(obj);
                }
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public void Guardar(object obj)
        {
            try
            {
                this.session.Update(obj);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public void Eliminar(IPersistente obj)
        {
            try
            {
                session.Delete(obj);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public void IncluirObjeto(IPersistente obj)
        {
            if (!obj.EsNuevo())
                this.session.Lock(obj, LockMode.None);
        }
        public void ExcluirObjeto(IPersistente obj)
        {
            if (this.session.Contains(obj))
                this.session.Evict(obj);
        }
        public void ExcluirTodosLosObjetos()
        {
            this.session.Clear();
        }
        public void Actualizar(IPersistente obj)
        {
            try
            {
                if (!obj.EsNuevo())
                    session.Refresh(obj);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public object Leer(Type tipo, object id)
        {
            try
            {
                return session.Get(tipo, id);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public T Leer<T>(object id)
        {
            try
            {
                return session.Get<T>(id);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }

        public IList Listar(Type tipo)
        {
            try
            {
                return session.CreateCriteria(tipo).List();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public IList<T> Listar<T>()
        {
            try
            {
                return session.CreateCriteria(typeof(T)).List<T>();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public IQueryable<T> SessionLinq<T>()
        {
            try
            {
                return session.Query<T>();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public IList<T> Listar<T>(string busqueda)
        {
            try
            {
                return session.CreateQuery(busqueda).List<T>();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public IList Listar(string busqueda)
        {
            try
            {
                return session.CreateQuery(busqueda).List();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public object BuscarUniqueResult(string busqueda)
        {
            try
            {
                return session.CreateQuery(busqueda).UniqueResult();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public T BuscarUniqueResult<T>(string busqueda)
        {
            try
            {
                return session.CreateQuery(busqueda).UniqueResult<T>();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }

        public IList Buscar(string[] busquedas)
        {
            try
            {
                IMultiQuery iquery = session.CreateMultiQuery();
                foreach (string hql in busquedas)
                    iquery.Add(hql);

                return iquery.List();
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
 
        #endregion HQL

        #region SQL

        public DataTable EjecutarSQL(string sentenciaSql)
        {
            SqlCommand command = CrearCommand(CommandType.Text, sentenciaSql);
            return EjecutarSQL(command);
        }
        public DataTable EjecutarSQL(SqlCommand command)
        {
            command.Connection = session.Connection as SqlConnection;
            if (trx != null)
                trx.Enlist(command);
            try
            {
                DataTable dt;
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    dt = new DataTable();
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public DataTable EjecutarSQL(CommandType tipo, string comando, params IDataParameter[] parametros)
        {
            SqlCommand command = CrearCommand(tipo, comando, parametros);
            return EjecutarSQL(command);
        }

		public DataSet EjecutarSQLDs(CommandType tipo, string comando, params IDataParameter[] parametros)
		{
			SqlCommand command = CrearCommand(tipo, comando, parametros);
			return EjecutarSQLDs(command);
		}

		public DataSet EjecutarSQLDs(SqlCommand command)
		{
			command.Connection = session.Connection as SqlConnection;
			if (trx != null)
				trx.Enlist(command);
			try
			{
				DataSet ds;
				using (SqlDataAdapter da = new SqlDataAdapter(command))
				{
					ds = new DataSet();
					da.Fill(ds);
				}
				return ds;
			}
			catch (Exception ex)
			{
				throw WrapException(ex);
			}
		}
        public object EjecutarSqlEscalar(CommandType tipo, string comando, params IDataParameter[] parametros)
        {
            SqlCommand command = CrearCommand(tipo, comando, parametros);
            return EjecutarSqlEscalar(command);
        }
        public object EjecutarSqlEscalar(SqlCommand command)
        {
            command.Connection = session.Connection as SqlConnection;
            if (trx != null)
                trx.Enlist(command);
            return command.ExecuteScalar();
        }
        public SqlCommand CrearCommand(CommandType tipo, string comando, params IDataParameter[] parametros)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = session.Connection as SqlConnection;
            command.CommandType = tipo;
            command.CommandText = comando;
            command.CommandTimeout = 180;

            SqlParameter sqlparam = null;
            foreach (IDataParameter parametro in parametros)
            {
                sqlparam = new SqlParameter();
                sqlparam.Value = parametro.Value;
                sqlparam.ParameterName = parametro.ParameterName;
                command.Parameters.Add(sqlparam);
            }
            if (trx != null)
                trx.Enlist(command);
            return command;
        }
        public int EjecutarSqlNonQuery(CommandType tipo, string comando, params IDataParameter[] parametros)
        {
            SqlCommand command = CrearCommand(tipo, comando, parametros);
            return EjecutarSqlNonQuery(command);
        }
        public int EjecutarSqlNonQuery(SqlCommand command)
        {
            command.Connection = session.Connection as SqlConnection;
            if (trx != null)
                trx.Enlist(command);
            return command.ExecuteNonQuery();
        }
 
        #endregion

        #region Transaccionalidad

        /// <summary>
        /// Resetea los Id's de los objetos que se han insertado (Save) en esta sesion
        /// la lista es generada por una implementacion de NHibernate.IInterceptor
        /// </summary>
        protected void ResetearIds()
        {
            //restablecer los id's de objetos nuevos que no fueron exitosamente insertados
            if (this.listaRestablecerId != null)
            {
                foreach (IPersistente obj in this.listaRestablecerId)
                {
                    obj.ResetearId();
                }
                this.listaRestablecerId = null;
            }

        }
		public void IniciarTransaccion()
        {
            IniciarTransaccion(IsolationLevel.Unspecified);
        }
        public void IniciarTransaccion(IsolationLevel isolationLevel)
        {
            if (trx != null)
            {
                throw new ExcepcionNegocios("Ya hay una transacción en ejecución");
            }
            try
            {
                trx = session.BeginTransaction(isolationLevel);
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public void ConfirmarTransaccion()
        {
            if (trx == null)
                throw new ExcepcionNegocios("No hay transacción en ejecución en este momento");
            if (trx.WasCommitted)
                throw new ExcepcionNegocios("La transacción ya ha sido finalizada vía commit");
            if (trx.WasRolledBack)
                throw new ExcepcionNegocios("La transacción ya ha sido finalizada vía rollback");
            try
            {
                trx.Commit();
                trx = null;
                this.listaRestablecerId = null;
            }
            catch (Exception ex)
            {
                throw WrapException(ex);
            }
        }
        public void DeshacerTransaccion()
        {
            try
            {
                ResetearIds();
                if (trx != null)
                    trx.Rollback();
            }
            catch
            {
                //LA CONSUMO
            }
            finally
            {
                trx = null;
            }
        }

        #endregion Transaccionalidad

        /// <summary>
        /// Analiza la excepción producida devuelve una excepción wrapeada
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private Exception WrapException(Exception ex)
        {
            if (ex is StaleObjectStateException)
                return new ExcepcionConcurrencia(DL.STR_ERROR_CONCURRENCIA, ex);
            else if ((ex.InnerException is SqlException) && ((ex.InnerException as SqlException).Number == 547))//violacion de foreign key
                return new ExcepcionEliminacion(DL.STR_ERROR_ELIMINAR_FK, ex);
            else if ((ex.InnerException is SqlException) && ((ex.InnerException as SqlException).Number == 2627))//violacion de unique al insertar
                return new ExcepcionInsertClaveDuplicada(DL.STR_ERROR_INSERTAR_UK, ex);
            else if ((ex.InnerException is SqlException) && ((ex.InnerException as SqlException).Number == 2601))//violacion de unique al insertar
                return new ExcepcionInsertClaveDuplicada(DL.STR_ERROR_INSERTAR_UK, ex);
            //DADO QUE SE PRODUJO UNA EXCEPCION, DEBEMOS RESETEAR LOS ID'S
            ResetearIds();
            return new ExcepcionTecnica(DL.STR_ERROR_ACCESO_DATOS, ex);
        }
        #region Miembros de IDisposable

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (session == null) { return; }
            DL.sesionesAbiertas.Remove(this);
            if (session.Connection.State == ConnectionState.Open) { session.Connection.Close(); }
            if (session.IsOpen)
            {
                session.Close();
                session = null;
            }
        }

        #endregion
	}
}
