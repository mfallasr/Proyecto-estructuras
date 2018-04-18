﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace ProyectoEstructuras
{
    public class Grafo
    {
        public Nodo cabeza;
        public Grafo()
        {
        }
        public void agregarVertice(Ubicacion valor)
        {
            if (this.cabeza == null)
            {
                this.cabeza = new Nodo(valor);
            }
            else
            {
                Nodo aux = cabeza;
                while (aux != null)
                {
                    if (aux.getSiguienteNodo() == null)
                    {
                        aux.setSiguienteNodo(new Nodo(valor));
                        break;
                    }
                    aux = aux.getSiguienteNodo();
                }
            }
        }

        public void eliminarPath(string key)
        {
            var aux = cabeza;
            while (aux != null)
            {
                var path = aux.getSucessor();
                if (path != null)
                {
                    if (path.valor == key)
                    {
                        aux.sucessor = null;
                        aux.setSucessor(path.getSiguiente());
                        break;
                    }
                    var pathToDel = path.getSiguiente();
                    while (pathToDel != null)
                    {
                        if (pathToDel.valor == key)
                        {
                            path.setSiguiente(pathToDel.getSiguiente());
                        }

                        path = pathToDel;
                        pathToDel = pathToDel.getSiguiente();
                    }

                }
                aux = aux.getSiguienteNodo();
            }
        }
        public GMapOverlay setRutas(GMapOverlay rutas)
        {
            var aux = this.cabeza;
            while (aux != null)
            {
                var path = aux.getSucessor();
                while (path != null)
                {
                    var direccion = this.agregarRuta(path.getOrigen().getValor().posicion, path.destino.getValor().posicion);
                    GMapRoute route = new GMapRoute(direccion.Route, "Route");
                    path.distancia= Math.Round(route.Distance);
                    //path.costo = Math.Round(path.distancia* 0.1);
                    path.costo = (path.distancia);
                    rutas.Routes.Add(route);
                    path = path.getSiguiente();
                }

                aux = aux.getSiguienteNodo();
            }
            return rutas;
        }
        public GDirections agregarRuta(PointLatLng lugarA, PointLatLng lugarB)
        {

            GDirections direccion;
            var routes = GMapProviders.GoogleMap.GetDirections(out direccion, lugarA,
                lugarB, false, false, false, false, false);
            GMapRoute route = new GMapRoute(direccion.Route, "Route");
            return direccion;
        }
        public void agregarPath(string llaveOrigen, string llaveDestino, string valor)
        {
            Nodo origin = this.buscarVertice(llaveOrigen);
            Nodo destination = this.buscarVertice(llaveDestino);
            Path newPath = new Path(valor, origin, destination);
        }
        public void mostrarGrafo()
        {
            Nodo aux = cabeza;
            while (aux != null)
            {
                if (aux.getSucessor() != null)
                {
                    Console.WriteLine(aux.mostrarPath());
                }
                aux = aux.getSiguienteNodo();
            }
        }

        public List<List<Path>> getAllPaths()
        {
            var list = new List<List<Path>>();
            var aux = this.cabeza;
            while (aux != null)
            {
                list.Add(getPathsDelVertice(aux));
                aux = aux.getSiguienteNodo();
            }
            return list;
        }

        public void RemovePath(String key)
        {

        }
        public List<Path> getPathsDelVertice(Nodo verice)
        {
            var list = new List<Path>();
            var aux = verice.getSucessor();
            while (aux != null)
            {
                list.Add(aux);
                aux = aux.getSiguiente();
            }
            return list;
        }
        public Nodo buscarVertice(string llave)
        {
            Nodo aux = cabeza;
            while (aux != null)
            {
                if (aux.getValor().descripcion == llave)
                {
                    return aux;
                }
                aux = aux.getSiguienteNodo();
            }
            return null;
        }
    }
}