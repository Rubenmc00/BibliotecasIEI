using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Data;
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


        private void botonBuscar_Click(object sender, EventArgs e)
        {
            markers.Clear();

            String codMun = "";
            textoResultado.Text = "";

            foreach (DataRow row in this.localidadTableAdapter.GetData().Rows)
            { 
                if (row.ItemArray[1].ToString().Contains(textoLocalidad.Text))
                {
                    codMun = row.ItemArray[0].ToString();
                }
            }

            foreach (DataRow row in this.bibliotecaTableAdapter.GetData().Rows)
            {
                if (row.ItemArray[9].ToString().Equals(codMun)) {
                    if (row.ItemArray[7].ToString().Equals(tipoBiblioteca.SelectedItem.ToString())) {
                        double longi = double.Parse(row.ItemArray[5].ToString().Replace(".", ","));
                        double lat = double.Parse(row.ItemArray[6].ToString().Replace(".", ","));
                        GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(lat, longi),
                           GMarkerGoogleType.blue_pushpin);
                        gMapControl1.Position = new PointLatLng(lat, longi);
                        markers.Markers.Add(marker);
                        gMapControl1.Overlays.Add(markers);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        marker.ToolTipText = string.Format(row.ItemArray[0].ToString());
                
                        textoResultado.Text += row.ItemArray[0].ToString() + " en " +
                            row.ItemArray[3].ToString() + ". Descripción: " + row.ItemArray[8] +
                            ". Email: " + row.ItemArray[2].ToString() + "  Tlf: " + row.ItemArray[1].ToString() + "\n";
                    }

                }             
            }
            if (markers.Markers.Count == 0)
            {
                textoResultado.Text = "No se han encontrado resultados asociados a esta búsqueda.";
            }
        }

        private void textoResultado_Click(object sender, EventArgs e)
        {

        }
    }
}
