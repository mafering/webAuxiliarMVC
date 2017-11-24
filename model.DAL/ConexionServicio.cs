using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace model.DAL
{
    public class ConexionServicio
    {
        //singleton
        private static ConexionServicio conexionObj = null;
        private OdbcConnection connObj;

        //Constructor
        private ConexionServicio()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbfAuxiliarServODBC"].ConnectionString;

            connObj = new OdbcConnection();
            connObj.ConnectionString = cs;
        }

        public static ConexionServicio estadoActual()
        {

            if (conexionObj == null)
            {
                conexionObj = new ConexionServicio();
            }
            return conexionObj;
        }



        public OdbcConnection getCon()
        {
            return connObj;
        }

        public void conexionClose()
        {
            conexionObj = null;
        }
    }
}
