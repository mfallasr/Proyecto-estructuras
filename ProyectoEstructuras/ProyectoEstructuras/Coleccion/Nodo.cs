using ProyectoEstructuras.entidades;
using System;
using System.Collections.Generic;

namespace ProyectoEstructuras.Coleccion
{
    public class Nodo
    {
        public List<Nodo> vecinos { get; set; }
        public Ubicacion valor { get; set; }
        public List<Path> adyacentes { get; set; }

        public Nodo(Ubicacion val)
        {
            valor = val;
            vecinos = new List<Nodo>();
            adyacentes = new List<Path>();
        }
        
    }
}
