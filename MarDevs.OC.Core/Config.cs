using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MarDevs.OC.Core
{
    public class Config
    {
        private string _server = String.Empty;
        private string _instancia = String.Empty;
		private string _puerto = String.Empty;
        private string _baseDatos = String.Empty;
        private string _versionReportada = String.Empty;

        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        public string Instancia
        {
            get { return _instancia; }
            set { _instancia = value; }
        }
        public string Puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }
        public string BaseDatos
        {
            get { return _baseDatos; }
            set { _baseDatos = value; }
        }
        public string VersionReportada
        {
            get { return _versionReportada; }
            set { _versionReportada = value; }
        }

    }
}
