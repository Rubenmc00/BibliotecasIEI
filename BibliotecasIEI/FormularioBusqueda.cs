using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Windows.Forms;

namespace BibliotecasIEI
{
    public partial class FormularioBusqueda : Form
    {

        GMapOverlay markers = new GMapOverlay("markers");

        public FormularioBusqueda()
        {
            InitializeComponent();
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(40.4167, -3.70325);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 5;
            tipoBiblioteca.SelectedIndex = 0;
        }


        private void bibliotecaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bibliotecaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.modelDataSet);

        }

        private void FormularioBusqueda_Load(object sender, EventArgs e)
        {// TODO: esta línea de código carga datos en la tabla 'modelDataSet.Localidad' Puede moverla o quitarla según sea necesario.
            this.localidadTableAdapter.Fill(this.modelDataSet.Localidad);
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet.Biblioteca' Puede moverla o quitarla según sea necesario.
            this.bibliotecaTableAdapter.Fill(this.modelDataSet.Biblioteca);

        }


        private async void botonBuscar_Click(object sender, EventArgs e)
        {
            markers.Clear();/*
            using (HttpClient client = new HttpClient())
            {
                                
                var response = await client.GetAsync("http://localhost:63554/Busqueda");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);

                    this.bibliotecaTableAdapter.Fill(this.modelDataSet.Biblioteca);
                    //this.provinciaTableAdapter.Fill(this.modelDataSet.Provincia);
                    this.localidadTableAdapter.Fill(this.modelDataSet.Localidad);

                }
                else
                {
                    Console.WriteLine($"response error code: {response.StatusCode}");
                }
            }*/
            
            String codMun = "";
            textoResultado.Text = "";

            DataRowCollection filas1 = this.localidadTableAdapter.GetData().Rows;
            DataRowCollection filas2 = this.bibliotecaTableAdapter.GetData().Rows;

            foreach (DataRow row1 in filas1)
            { 
                if (row1.ItemArray[1].ToString().Contains(textoLocalidad.Text))
                {
                    codMun = row1.ItemArray[0].ToString();
                    foreach(DataRow row in filas2)
            {
                        if (row.ItemArray[9].ToString().Equals(codMun))
                        {
                            if (row.ItemArray[7].ToString().Equals(tipoBiblioteca.SelectedItem.ToString()))
                            {
                                double longi = double.Parse(row.ItemArray[5].ToString().Replace(".", ","));
                                double lat = double.Parse(row.ItemArray[6].ToString().Replace(".", ","));
                                GMapMarker marker = new GMarkerGoogle(
                                   new PointLatLng(lat, longi),
                                   GMarkerGoogleType.blue_pushpin);
                                gMapControl1.Position = new PointLatLng(lat, longi);

                                marker.ToolTipMode = MarkerTooltipMode.Always;
                                marker.ToolTipText = string.Format(row.ItemArray[0].ToString());

                                markers.Markers.Add(marker);
                                gMapControl1.Overlays.Add(markers);

                                textoResultado.Text += row.ItemArray[0].ToString() + " en " +
                                    row.ItemArray[3].ToString() + ". Descripción: " + row.ItemArray[8] +
                                    ". Email: " + row.ItemArray[2].ToString() + "  Tlf: " + row.ItemArray[1].ToString() + "\n";
                            }

                        }
                    }
                }
            }

            
            if (markers.Markers.Count == 0)
            {
                textoResultado.Text = "No se han encontrado resultados asociados a esta búsqueda.";
            }
        }

    }
}
