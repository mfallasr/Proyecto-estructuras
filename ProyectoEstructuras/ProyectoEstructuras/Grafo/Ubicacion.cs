using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace ProyectoEstructuras
{
    public class Ubicacion
    {
        public PointLatLng posicion { get; set; }
        public string descripcion { get; set; }
        private double latitud { get; set; }
        private double longitud { get; set; }
        public Ubicacion(string desc, double lat, double longi)
        {
            latitud = lat;
            longitud = longi;
            posicion = new PointLatLng(this.latitud, this.longitud);
            descripcion = desc;
        }
       

    }
}
