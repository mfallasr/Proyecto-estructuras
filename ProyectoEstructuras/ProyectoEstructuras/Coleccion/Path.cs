using System;

namespace ProyectoEstructuras.Coleccion
{
    public class Path
    {
        public string valor;
        public Nodo original, destino;
        private Path siguiente;
        public double distancia, costo;
        public Path(string val, Nodo orig, Nodo dest)
        {
            this.destino = dest;
            this.valor = val;
            this.original = orig;
            this.destino.setPredecessor(this);
            this.original.setSucessor(this);
        }
        public Path getSiguiente()
        {
            return siguiente;
        }

        public string getValor()
        {
            return valor;
        }
        public Nodo getOrigen()
        {
            return original;
        }
        public void setOrigen(Nodo orig)
        {
            this.original = orig;
        }
        public void setSiguiente(Path sig)
        {
            this.siguiente = sig;
        }
        public void setValor(string val)
        {
            this.valor = val;
        }
        public void setCosto(double cost)
        {
            this.costo = cost;
        }
        public void setDistancia(double dist)
        {
            this.distancia = dist;
        }
        public double getCosto()
        {
            return costo;
        }
        public double getDistancia()
        {
            return distancia;
        }



        public String toString()
        {
            String info = "Distancia: " + valor + "\n";
            info += "Origen:\n            " + this.original.toString();
            info += "Destino:\n           " + this.destino.toString();
            if (this.siguiente != null)
            {
                info += "Siguiente: \n" +
                        "           " + this.siguiente.toString();
            }

            return info;
        }
    }
}
