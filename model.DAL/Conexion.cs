using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace model.DAL
{
    public class Conexion
    {
        //singleton
        private static Conexion conexionObj = null;
        private OdbcConnection connObj;

        //Constructor
        private Conexion()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbfAuxiliarObraODBC"].ConnectionString;
                
            connObj = new OdbcConnection();
            connObj.ConnectionString = cs;
        }

        public static Conexion estadoActual()
        {

            if (conexionObj == null)
            {
                conexionObj = new Conexion();
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
