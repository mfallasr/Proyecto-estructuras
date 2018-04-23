using System;

namespace ProyectoEstructuras.Coleccion
{
    public class Path
    {
        public double valor { set; get; }
        public Nodo original { get; set; }
        public Nodo destino { get; set; }
        public Path(double val, Nodo orig, Nodo dest)
        {
            this.destino = dest;
            this.valor = val;
            this.original = orig;
            dest.vecinos.Add(orig);
            dest.adyacentes.Add(this);
            orig.vecinos.Add(dest);
            orig.adyacentes.Add(this);
        }
    }
}
