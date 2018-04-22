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

namespace ProyectoEstructuras
{
    public partial class Form1 : Form
    {
        private GMapOverlay markerOverLay;
        private double latInicial = 9.924264;
        private double longInicial = -84.1909738;
        private int posA, posB;
        private GMapOverlay capRoute = new GMapOverlay("Capa de la ruta");
        private Grafo grafito;
        private string markerName;
        private int markerPoss = 0;
        Conector connector = null;
        long[] path = new long[2];
        Dictionary<long, Ubicacion> dictionary = new Dictionary<long, Ubicacion>();

        public Form1()
        {
            InitializeComponent();
        }
        private void actualizarRutas()
        {
            mapita.Overlays[1].Routes.Clear();
            mapita.Overlays.Add(grafito.setRutas(mapita.Overlays[1]));
            mapita.Zoom = mapita.Zoom + 1;
            mapita.Zoom = mapita.Zoom - 1;
        }

        private PointLatLng getPosicion(double lat, double lng)
        {
            return new PointLatLng(lat, lng);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                var marker = markerOverLay.Markers[markerPoss];
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = "Lugar: "+textBox1.Text;
                dataGridView1.Rows.Add(textBox1.Text, marker.Position.Lat, marker.Position.Lng);
                markerPoss++;
                grafito.agregarVertice(new Ubicacion(textBox1.Text, marker.Position.Lat, marker.Position.Lng));
                //dataGridView2.Rows.Add(textBox1.Text);
                dataGridView3.Rows.Add(textBox1.Text, marker.Position.Lat, marker.Position.Lng);
                Limpiar(); 
        }

        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;
            markerPoss = index;
            markerName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = markerName;
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
            textBox2.Text = lat.ToString();
            textBox3.Text = lng.ToString();

            var ubicacion = new Ubicacion(lat,lng);

            connector.SaveLocation(ubicacion);

            mapita.Refresh();
            mapita.ReloadMap();
            //markerOverLay = new GMapOverlay("Marcador");
            var marker = new GMarkerGoogle(getPosicion(lat, lng), GMarkerGoogleType.green);
                markerOverLay.Markers.Add(marker);
            markerOverLay.IsVisibile = true;
            Console.WriteLine(String.Format("Marker {0} was clicked.", "hello"));
        }

        private void gmap_OnMarkerClick(GMapMarker marker, MouseEventArgs e)
        {
            var id = Int64.Parse(marker.Tag.ToString());
            Ubicacion ubicacion;
            dictionary.TryGetValue(id, out ubicacion);
            //grafito.

            Console.WriteLine(String.Format("Marker {0} was clicked.", marker.Tag));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                //buscar
                grafito.agregarPath(dataGridView1.Rows[posA].Cells[0].Value.ToString(), dataGridView3.Rows[posB].Cells[0].Value.ToString(), textBox4.Text);
                mapita.Zoom = mapita.Zoom + 1;
                mapita.Zoom = mapita.Zoom - 1;
                //actualizarRutas();
                aniadirPathAlGrid();
                Limpiar();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Lo siento :( ocurrio un error intente de nuevo");
            }
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
            this.markerOverLay = new GMapOverlay("Markers");
            mapita.Overlays.Add(capRoute);
            mapita.Overlays.Add(this.markerOverLay);
            grafito = new Grafo();
            // updateMarkers();
            mapita.Zoom = mapita.Zoom + 1;
            mapita.Zoom = mapita.Zoom - 1;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            mapita.OnMarkerClick += gmap_OnMarkerClick;
            //mapita.MouseClick += mapita_MouseClick_1;

            connector = Conector.instance;
            
            foreach (var ubicacion in connector.GetLocations())
            {
                grafito.agregarVertice(ubicacion);

                dictionary.Add(ubicacion.id, ubicacion);

                var marker = new GMarkerGoogle(ubicacion.posicion, GMarkerGoogleType.green);
                marker.Tag = ubicacion.id;
                markerOverLay.Markers.Add(marker);
                markerOverLay.IsVisibile = true;
            }

            foreach (var link in connector.GetPaths())
            {

                var list = new List<PointLatLng>();
                Ubicacion ubicacion1;
                Ubicacion ubicacion2;
                dictionary.TryGetValue(link.origen, out ubicacion1);
                dictionary.TryGetValue(link.destino, out ubicacion2);
                list.Add(ubicacion1.posicion);
                list.Add(ubicacion2.posicion);

                var polygon = new GMapPolygon(list, "");

                grafito.agregarPath(ubicacion1.descripcion, ubicacion2.descripcion, polygon.Distance.ToString());

                
                capRoute.Polygons.Add(polygon);
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
        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            actualizarRutas();
            aniadirPathAlGrid();
        }
        private void aniadirPathAlGrid()
        {
            dataGridView2.Rows.Clear();
            var listOfLists = grafito.getAllPaths();
            foreach (var list in listOfLists)
            {
                foreach (var path in list)
                {
                    dataGridView2.Rows.Add(path.original.getValor().descripcion, path.destino.getValor().descripcion, path.costo+"00", path.distancia+"km");
                }
            }
        }
    }
}
