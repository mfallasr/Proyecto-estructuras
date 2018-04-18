﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

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

            mapita.Refresh();
            mapita.ReloadMap();
            //markerOverLay = new GMapOverlay("Marcador");
            var marker = new GMarkerGoogle(getPosicion(lat, lng), GMarkerGoogleType.green);
                markerOverLay.Markers.Add(marker);
            markerOverLay.IsVisibile = true;
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
            mapita.Overlays.Add(this.markerOverLay);
            mapita.Overlays.Add(new GMapOverlay("Routes"));
            grafito = new Grafo();
            // updateMarkers();
            mapita.Zoom = mapita.Zoom + 1;
            mapita.Zoom = mapita.Zoom - 1;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            //agregar datos grid 2
            /*dataGridView3.Rows.Add("San Pedro", "9.94", "-84.20");
            dataGridView3.Rows.Add("Granadilla", "9.96", "-84.05");
            dataGridView3.Rows.Add("Montes de Oca", "9.9", "-84.15");
            dataGridView3.Rows.Add("Desamparados", "9.98", "-84.84");
            dataGridView3.Rows.Add("San Miguel", "9.85", "-84.92");

            //agregar datos grid 1
            dataGridView1.Rows.Add("San Pedro", "9.94", "-84.20");
            dataGridView1.Rows.Add("Granadilla", "9.96", "-84.05");
            dataGridView1.Rows.Add("Montes de Oca", "9.9", "-84.15");
            dataGridView1.Rows.Add("Desamparados", "9.98", "-84.84");
            dataGridView1.Rows.Add("San Miguel", "9.85", "-84.92");*/

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