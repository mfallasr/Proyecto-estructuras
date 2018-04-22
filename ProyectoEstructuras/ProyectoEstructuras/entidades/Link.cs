using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras.entidades
{
    public class Link
    {
        public long origen{ get; set; }
        public long destino { get; set; }

        public Link(long origen, long destino)
        {
            this.origen = origen;
            this.destino = destino;
        }
    }
}
