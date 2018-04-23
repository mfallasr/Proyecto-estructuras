using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ProyectoEstructuras.Coleccion;
using ProyectoEstructuras.datos;
using ProyectoEstructuras.entidades;
using ProyectoEstructuras.CustomGMap;
using System.Drawing;

namespace ProyectoEstructuras
{
    public partial class Form1 : Form
    {
        private GMapOverlay markerOverLay = new GMapOverlay("Markers");
        private GMapOverlay markerHighlight = new GMapOverlay("Highlight");
        private GMapOverlay pathsLayer = new GMapOverlay("Paths");
        private GMapOverlay capRoute = new GMapOverlay("Capa de la ruta");
        private Grafo grafito;
        private Conector connector = null;
        private Dictionary<long, LocationMarker> dictionary = new Dictionary<long, LocationMarker>();

        private double latInicial = 9.924264;
        private double longInicial = -84.1909738;

        private long[] path = new long[2];
        
        private int posA, posB;

        public Form1()
        {
            InitializeComponent();
        }

        private PointLatLng getPosicion(double lat, double lng)
        {
            return new PointLatLng(lat, lng);
        }


        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posB = e.RowIndex;
            mapita.Position = markerOverLay.Markers[posB].Position;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posA = e.RowIndex;
            mapita.Position = markerOverLay.Markers[posA].Position;
        }

        private void mapita_MouseClick_1(object sender, MouseEventArgs e)
        {
            double lat = mapita.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = mapita.FromLocalToLatLng(e.X, e.Y).Lng;

            var ubicacion = new Ubicacion(lat,lng);

            connector.SaveLocation(ubicacion);

            mapita.Refresh();
            mapita.ReloadMap();
            var marker = new GMarkerGoogle(getPosicion(lat, lng), GMarkerGoogleType.green);
            markerOverLay.Markers.Add(marker);
            markerOverLay.IsVisibile = true;
            Console.WriteLine(String.Format("Marker {0} was clicked.", "hello"));
        }

        private void gmap_OnMarkerClick(GMapMarker marker, MouseEventArgs e)
        {
            var id = Int64.Parse(marker.Tag.ToString());
            LocationMarker locationMarker;
            dictionary.TryGetValue(id, out locationMarker);
            var adyacencias = grafito.ObtenerPathsAdyacentes(locationMarker.Location.id);
            dataGridView3.Rows.Clear();
            markerHighlight.Clear();
            capRoute.Clear();
            foreach (var path in adyacencias)
            {
                Ubicacion ubicacion1;

                if(path.original.valor.id == id)
                {
                    ubicacion1 = path.destino.valor;
                }
                else
                {
                    ubicacion1 = path.original.valor;
                }

                dataGridView3.Rows.Add(path.valor, ubicacion1.id);
                var newMarker = new GmapMarkerWithLabel(ubicacion1.posicion, "", GMarkerGoogleType.red);
                newMarker.Tag = ubicacion1.descripcion;
                markerHighlight.Markers.Add(newMarker);

                var list = new List<PointLatLng>();
                list.Add(path.original.valor.posicion);
                list.Add(path.destino.valor.posicion);
                var polygon = new GMapPolygon(list, path.valor.ToString());
                polygon.Stroke = new Pen(Color.Red, 1);
                capRoute.Polygons.Add(polygon);

            }

            mapita.Refresh();
        }

      
        private void Form1_Load_1(object sender, EventArgs e)
        {
            mapita.DragButton = MouseButtons.Left;
            mapita.CanDragMap = true;
            mapita.MapProvider = GMapProviders.GoogleMap;
            mapita.Position = new PointLatLng(this.latInicial, this.longInicial);
            mapita.MinZoom = 0;
            mapita.MaxZoom = 24;
            mapita.Zoom = 9;
            mapita.AutoScroll = true;
            mapita.Overlays.Add(pathsLayer);
            mapita.Overlays.Add(capRoute);
            mapita.Overlays.Add(markerOverLay);
            mapita.Overlays.Add(markerHighlight);
            grafito = new Grafo();
            mapita.Zoom = mapita.Zoom + 1;
            mapita.Zoom = mapita.Zoom - 1;
            mapita.OnMarkerClick += gmap_OnMarkerClick;

            connector = Conector.instance;
            
            foreach (var ubicacion in connector.GetLocations())
            {
                var marker = new GmapMarkerWithLabel(ubicacion.posicion, ubicacion.descripcion, GMarkerGoogleType.green);
                marker.Tag = ubicacion.id;
                markerOverLay.Markers.Add(marker);
                markerOverLay.IsVisibile = true;

                grafito.agregarVertice(ubicacion);
                dictionary.Add(ubicacion.id, new LocationMarker(ubicacion, marker));


                var item = new ComboboxItem(ubicacion.descripcion, ubicacion);

                originSelector.Items.Add(item);
                stopSelector.Items.Add(item);
            }

            foreach (var link in connector.GetPaths())
            {

                Ubicacion ubicacion1;
                Ubicacion ubicacion2;
                LocationMarker locationMarker;

                var list = new List<PointLatLng>();

                locationMarker = dictionary[link.origen];
                ubicacion1 = locationMarker.Location;
                locationMarker = dictionary[link.destino];
                ubicacion2 = locationMarker.Location;

                list.Add(ubicacion1.posicion);
                list.Add(ubicacion2.posicion);

                var polygon = new GMapPolygon(list, "");

                grafito.agregarPath(ubicacion1.id, ubicacion2.id, polygon.Distance);

                
                pathsLayer.Polygons.Add(polygon);
            }

            mapita.Refresh();
            mapita.ReloadMap();

        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            posA = e.RowIndex;
            mapita.Position = markerOverLay.Markers[posA].Position;
        }

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            posB = e.RowIndex;
            mapita.Position = markerOverLay.Markers[posB].Position;
        }

        private void aniadirPathAlGrid()
        {
            
        }


        private class LocationMarker
        {
            public Ubicacion Location { get; set; }
            public GMapMarker Marker { set; get; }
            public LocationMarker():this(null,null) { }
            public LocationMarker(Ubicacion ubicacion, GMapMarker mapMarker)
            {
                Location = ubicacion;
                Marker = mapMarker;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long inicio, fin;
            var item = (ComboboxItem)originSelector.SelectedItem;
            inicio = ((Ubicacion)item.Value).id;
            item = (ComboboxItem)stopSelector.SelectedItem;
            fin = ((Ubicacion)item.Value).id;

            var ruta = grafito.RutaMasCorta(fin, inicio);

            markerHighlight.Clear();
            routeDataGrid.Rows.Clear();
            capRoute.Clear();

            var marker = new GmapMarkerWithLabel(dictionary[inicio].Location.posicion, "", GMarkerGoogleType.blue);
            markerHighlight.Markers.Add(marker);
            marker = new GmapMarkerWithLabel(dictionary[fin].Location.posicion, "", GMarkerGoogleType.blue);
            markerHighlight.Markers.Add(marker);

            var anterior = inicio;
            Path path;

            var distanciaTotal = 0.0;

            foreach (var punto in ruta)
            {
                if(punto != anterior)
                {
                    path = grafito.BuscarPath(anterior, punto);
                    DrawLine(path);
                    marker = new GmapMarkerWithLabel(dictionary[punto].Location.posicion, "", GMarkerGoogleType.red);
                    markerHighlight.Markers.Add(marker);
                    routeDataGrid.Rows.Add(dictionary[anterior].Location.descripcion, dictionary[punto].Location.descripcion, path.valor);
                    distanciaTotal += path.valor;
                    anterior = punto;
                }
            }

            path = grafito.BuscarPath(anterior, fin);
            DrawLine(path);
            distanciaTotal += path.valor;

            distanciaLabel.Text = distanciaTotal.ToString();


            routeDataGrid.Rows.Add(dictionary[anterior].Location.descripcion, dictionary[fin].Location.descripcion, path.valor);


        }

        private void DrawLine(Path path)
        {
            var list = new List<PointLatLng>()
                    {
                        path.original.valor.posicion,
                        path.destino.valor.posicion
                    };

            var polygon = new GMapPolygon(list, "");

            polygon.Stroke = new Pen(Color.Red);

            capRoute.Polygons.Add(polygon);
        }

        private class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public ComboboxItem() : this(null, null) { }
            public ComboboxItem(string text, object value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
