using ProyectoEstructuras.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoEstructuras.datos
{
    public class Conector
    {

        private SqlConnection conn = null;
        private static Conector _instance = null;

        public static Conector instance
        {
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
            conn.Close();
        }

        public List<Ubicacion> GetLocations()
        {
            var query = "SELECT * FROM [dbo].[ubicaciones]";
            var command = new SqlCommand(query, conn);

            var resul = new List<Ubicacion>();

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    var lat = Double.Parse(reader["latitud"].ToString());
                    var longi = Double.Parse(reader["longitud"].ToString());
                    var id = Int64.Parse(reader["ubicaciones_id"].ToString());
                    var desc = reader["descripcion"].ToString();
                    resul.Add(new Ubicacion(id, lat, longi, desc));
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return resul;
        }

        public bool SaveLocation(Ubicacion ubicacion) {
            var query = "INSERT INTO [dbo].[ubicaciones] (latitud, longitud, descripcion) VALUES (@latitud, @longitud, @descripcion);";
            var command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@latitud", ubicacion.posicion.Lat);
            command.Parameters.AddWithValue("@longitud", ubicacion.posicion.Lng);
            command.Parameters.AddWithValue("@descripcion", ubicacion.descripcion);

            conn.Open();

            command.ExecuteNonQuery();

            conn.Close();

            return true;
        }


        public List<Link> GetPaths()
        {
            var query = "SELECT * FROM [dbo].[paths]";
            var command = new SqlCommand(query, conn);

            var resul = new List<Link>();

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    var origen = Int64.Parse(reader["origen_id"].ToString());
                    var destino = Int64.Parse(reader["destino_id"].ToString());
                    resul.Add(new Link(origen, destino));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            conn.Close();
            return resul;
        }

        public bool SavePath(Link link)
        {
            var query = "INSERT INTO [dbo].[paths] (origen_id, destino_id ) VALUES (@origen_id, @destino_id);";
            var command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@origen_id", link.origen);
            command.Parameters.AddWithValue("@destino_id", link.destino);

            conn.Open();

            command.ExecuteNonQuery();

            conn.Close();

            return true;
        }
    }
}
