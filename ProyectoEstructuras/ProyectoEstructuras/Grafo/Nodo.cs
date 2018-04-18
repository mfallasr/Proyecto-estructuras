using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstructuras
{
    public class Nodo
    {
        public Path predecessor, sucessor;
        public Nodo siguienteNodo;
        public Ubicacion valor;

        public Nodo(Ubicacion val)
        {
            this.valor = val;
        }
        public void setPredecessor(Path predecessor)
        {
            this.predecessor = predecessor;
        }

        public void setSucessor(Path sucessor)
        {
            if (this.getSucessor() == null)
            {
                this.sucessor = sucessor;
            }
            else
            {
                Path aux = this.getSucessor();
                while (aux != null)
                {
                    if (aux.getSiguiente() == null)
                    {
                        aux.setSiguiente(sucessor);
                        break;
                    }
                    aux = aux.getSiguiente();
                }
            }
        }

        public void setSiguienteNodo(Nodo sigNodo)
        {
            this.siguienteNodo = sigNodo;
        }

        public void setValor(Ubicacion val)
        {
            this.valor = val;
        }

        public Path getPredecessor()
        {

            return predecessor;
        }

        public Path getSucessor()
        {
            return sucessor;
        }

        public Nodo getSiguienteNodo()
        {
            return siguienteNodo;
        }

        public Ubicacion getValor()
        {
            return valor;
        }
        public String mostrarPath()
        {
            return this.sucessor.ToString();
        }

        public String toString()
        {
            String info = "-------------Vertice-------------------\n";
            info += "Value: " + this.valor + "\n";
            return info;
        }
    }
}
