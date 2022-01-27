using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarDevs.Gestion.Core
{
    public class ServicioEjecucionAsincrona
    {
        public ServicioEjecucionAsincrona()
        {

        }

        public void EjectutarAsincronico(Func<Task> delegado)
        {
            try
            {
                delegado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<T> EjectutarAsincronico<T>(Func<Task<T>> delegado)
        {
            try
            {
                return delegado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
  
}
