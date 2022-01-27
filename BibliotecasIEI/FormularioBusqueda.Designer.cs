
using System;

namespace BibliotecasIEI
{
    partial class FormularioBusqueda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.modelDataSet = new BibliotecasIEI.ModelDataSet();
            this.bibliotecaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bibliotecaTableAdapter = new BibliotecasIEI.ModelDataSetTableAdapters.BibliotecaTableAdapter();
            this.tableAdapterManager = new BibliotecasIEI.ModelDataSetTableAdapters.TableAdapterManager();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tipoBiblioteca = new System.Windows.Forms.ComboBox();
            this.textoLocalidad = new System.Windows.Forms.TextBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.localidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.localidadTableAdapter = new BibliotecasIEI.ModelDataSetTableAdapters.LocalidadTableAdapter();
            this.resultadosLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.textoResultado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibliotecaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "ModelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bibliotecaBindingSource
            // 
            this.bibliotecaBindingSource.DataMember = "Biblioteca";
            this.bibliotecaBindingSource.DataSource = this.modelDataSet;
            // 
            // bibliotecaTableAdapter
            // 
            this.bibliotecaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BibliotecaTableAdapter = this.bibliotecaTableAdapter;
            this.tableAdapterManager.LocalidadTableAdapter = null;
            this.tableAdapterManager.ProvinciaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = BibliotecasIEI.ModelDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(391, 98);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(388, 207);
            this.gMapControl1.TabIndex = 12;
            this.gMapControl1.Zoom = 0D;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 44);
            this.label1.TabIndex = 13;
            this.label1.Text = "Buscador de bibliotecas";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Localidad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tipo de biblioteca:";
            // 
            // tipoBiblioteca
            // 
            this.tipoBiblioteca.FormattingEnabled = true;
            this.tipoBiblioteca.Items.AddRange(new object[] {
            "Publica",
            "Privada"});
            this.tipoBiblioteca.Location = new System.Drawing.Point(201, 180);
            this.tipoBiblioteca.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tipoBiblioteca.Name = "tipoBiblioteca";
            this.tipoBiblioteca.Size = new System.Drawing.Size(116, 21);
            this.tipoBiblioteca.TabIndex = 16;
            // 
            // textoLocalidad
            // 
            this.textoLocalidad.Location = new System.Drawing.Point(201, 128);
            this.textoLocalidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textoLocalidad.Name = "textoLocalidad";
            this.textoLocalidad.Size = new System.Drawing.Size(116, 20);
            this.textoLocalidad.TabIndex = 17;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(59, 243);
            this.botonBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(74, 28);
            this.botonBuscar.TabIndex = 18;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Location = new System.Drawing.Point(146, 243);
            this.botonCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(74, 28);
            this.botonCancelar.TabIndex = 19;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // localidadBindingSource
            // 
            this.localidadBindingSource.DataMember = "Localidad";
            this.localidadBindingSource.DataSource = this.modelDataSet;
            // 
            // localidadTableAdapter
            // 
            this.localidadTableAdapter.ClearBeforeFill = true;
            // 
            // resultadosLabel
            // 
            this.resultadosLabel.AutoSize = true;
            this.resultadosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultadosLabel.Location = new System.Drawing.Point(59, 317);
            this.resultadosLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultadosLabel.Name = "resultadosLabel";
            this.resultadosLabel.Size = new System.Drawing.Size(191, 20);
            this.resultadosLabel.TabIndex = 20;
            this.resultadosLabel.Text = "Resultados de búsqueda:";
            // 
            // textoResultado
            // 
            this.textoResultado.AllowDrop = true;
            this.textoResultado.AutoEllipsis = true;
            this.textoResultado.AutoSize = true;
            this.textoResultado.Location = new System.Drawing.Point(61, 355);
            this.textoResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.textoResultado.Name = "textoResultado";
            this.textoResultado.Size = new System.Drawing.Size(242, 13);
            this.textoResultado.TabIndex = 21;
            this.textoResultado.Text = "Aquí se mostrarán los resultados de su búsqueda.";
            this.textoResultado.Click += new System.EventHandler(this.textoResultado_Click);
            // 
            // FormularioBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 585);
            this.Controls.Add(this.textoResultado);
            this.Controls.Add(this.resultadosLabel);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.textoLocalidad);
            this.Controls.Add(this.tipoBiblioteca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gMapControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormularioBusqueda";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormularioBusqueda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibliotecaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textoResultado_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private ModelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource bibliotecaBindingSource;
        private ModelDataSetTableAdapters.BibliotecaTableAdapter bibliotecaTableAdapter;
        private ModelDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tipoBiblioteca;
        private System.Windows.Forms.TextBox textoLocalidad;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.BindingSource localidadBindingSource;
        private ModelDataSetTableAdapters.LocalidadTableAdapter localidadTableAdapter;
        private System.Windows.Forms.Label resultadosLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label textoResultado;
    }
}