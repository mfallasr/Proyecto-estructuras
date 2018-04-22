using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace ProyectoEstructuras.entidades
{
    public class Ubicacion
    {
        public PointLatLng posicion { get; set; }
        public string descripcion { get; set; }
        private double latitud { get; set; }
        private double longitud { get; set; }
        public long id { get; set; }

        public Ubicacion(long id, double lat, double longi, string desc)
        {
            this.id = id;
            latitud = lat;
            longitud = longi;
            posicion = new PointLatLng(this.latitud, this.longitud);
            descripcion = desc;
        }
        public Ubicacion(string desc, double lat, double longi): this(0, lat, longi, desc) { }

        public Ubicacion(double lat, double longi) : this("", lat, longi) { }
       

    }
}
