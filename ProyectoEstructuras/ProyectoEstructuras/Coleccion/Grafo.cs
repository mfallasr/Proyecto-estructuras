using System;
using System.Collections.Generic;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using ProyectoEstructuras.entidades;

namespace ProyectoEstructuras.Coleccion
{
    public class Grafo
    {
        private List<Path> PathList { get; set; }
        private Dictionary<long,Nodo> vertices { get; set; }
        public Grafo() {
            PathList = new List<Path>();
            vertices = new Dictionary<long, Nodo>();
        }

        public void agregarVertice(Ubicacion valor)
        {
            if(!vertices.ContainsKey(valor.id))
            {
                var nodo = new Nodo(valor);
                vertices.Add(valor.id, nodo);
            }
        }

        public void eliminarPath(string key)
        {
            
        }
        
        public void agregarPath(long llaveOrigen, long llaveDestino, double valor)
        {
            Nodo origin = this.buscarVertice(llaveOrigen);
            Nodo destination = this.buscarVertice(llaveDestino);
            Path newPath = new Path(valor, origin, destination);
            PathList.Add(newPath);
        }


        public List<Path> getAllPaths()
        {
            return this.PathList;
        }

        public List<Path> ObtenerPathsAdyacentes(long id)
        {
            var list = new List<Path>();
                foreach(var path in PathList)
                {
                    if (path.original.valor.id == id)
                    {
                        if(path.destino != null)
                        {
                            list.Add(path);
                        }
                    } else if(path.destino != null && path.destino.valor.id== id)
                    {
                        list.Add(path);
                    }
                }

            return list;
        }

        public List<long> RutaMasCorta(long start, long finish)
        {
            var previous = new Dictionary<long, long>();
            var distances = new Dictionary<long, int>();
            var nodes = new List<long>();

            List<long> path = null;

            foreach (var vertice in vertices)
            {
                if (vertice.Key == start)
                {
                    distances[vertice.Key] = 0;
                }
                else
                {
                    distances[vertice.Key] = int.MaxValue;
                }

                nodes.Add(vertice.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<long>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest].vecinos)
                {
                    var linkPath = BuscarPath(vertices[smallest].valor.id, neighbor.valor.id);
                    var alt = distances[smallest] + linkPath.valor;
                    if (alt < distances[neighbor.valor.id])
                    {
                        distances[neighbor.valor.id] = (int)alt;
                        previous[neighbor.valor.id] = smallest;
                    }
                }
            }

            return path;
        }

        public void RemovePath(String key)
        {

        }

        public Path BuscarPath(long llave1, long llave2)
        {
            foreach(var path in PathList)
            {
                if((path.original.valor.id == llave1 || path.original.valor.id == llave2) &&
                    (path.destino.valor.id == llave1 || path.destino.valor.id == llave2))
                {
                    return path;
                }
            }
            return null;
        }
        public Nodo buscarVertice(long llave)
        {
            return vertices[llave];
        }
    }
}
