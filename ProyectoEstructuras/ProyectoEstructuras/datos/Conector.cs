using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.datos
{
    public class Conector
    {

        private SqlConnection conn = null;
        private static Conector _instance = null;

        public static Conector instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new Conector();
                }

                return _instance;
            }
        }

        public Conector()
        {
            conn = new SqlConnection();
            conn.ConnectionString =
                "Data Source=localhost;" +
                "Initial Catalog=estructuras;" +
                "User id=SA;" +
                "Password=4682000Leo;";
        }


    }
}
