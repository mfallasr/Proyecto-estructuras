namespace ProyectoEstructuras
{
    partial class Form1
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
            this.mapita = new GMap.NET.WindowsForms.GMapControl();
            this.routeDataGrid = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.originSelector = new System.Windows.Forms.ComboBox();
            this.stopSelector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.distanciaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.routeDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // mapita
            // 
            this.mapita.Bearing = 0F;
            this.mapita.CanDragMap = true;
            this.mapita.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapita.GrayScaleMode = false;
            this.mapita.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapita.LevelsKeepInMemmory = 5;
            this.mapita.Location = new System.Drawing.Point(12, 12);
            this.mapita.MarkersEnabled = true;
            this.mapita.MaxZoom = 2;
            this.mapita.MinZoom = 2;
            this.mapita.MouseWheelZoomEnabled = true;
            this.mapita.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapita.Name = "mapita";
            this.mapita.NegativeMode = false;
            this.mapita.PolygonsEnabled = true;
            this.mapita.RetryLoadTile = 0;
            this.mapita.RoutesEnabled = true;
            this.mapita.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapita.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapita.ShowTileGridLines = false;
            this.mapita.Size = new System.Drawing.Size(858, 319);
            this.mapita.TabIndex = 0;
            this.mapita.Zoom = 0D;
            // 
            // routeDataGrid
            // 
            this.routeDataGrid.AllowUserToAddRows = false;
            this.routeDataGrid.AllowUserToDeleteRows = false;
            this.routeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column5});
            this.routeDataGrid.Location = new System.Drawing.Point(230, 390);
            this.routeDataGrid.Name = "routeDataGrid";
            this.routeDataGrid.ReadOnly = true;
            this.routeDataGrid.Size = new System.Drawing.Size(359, 150);
            this.routeDataGrid.TabIndex = 12;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Lugar A";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Lugar B";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Distancia";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Crear ruta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ruta";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column8});
            this.dataGridView3.Location = new System.Drawing.Point(629, 390);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(245, 150);
            this.dataGridView3.TabIndex = 18;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick_1);
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Distancia";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Lugar";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destino:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Origen:";
            // 
            // originSelector
            // 
            this.originSelector.FormattingEnabled = true;
            this.originSelector.Location = new System.Drawing.Point(80, 391);
            this.originSelector.Name = "originSelector";
            this.originSelector.Size = new System.Drawing.Size(121, 21);
            this.originSelector.TabIndex = 22;
            // 
            // stopSelector
            // 
            this.stopSelector.FormattingEnabled = true;
            this.stopSelector.Location = new System.Drawing.Point(80, 417);
            this.stopSelector.Name = "stopSelector";
            this.stopSelector.Size = new System.Drawing.Size(121, 21);
            this.stopSelector.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(626, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ubicaciones adyacentes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Creación de ruta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(12, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Distancia total:";
            // 
            // distanciaLabel
            // 
            this.distanciaLabel.AutoSize = true;
            this.distanciaLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.distanciaLabel.Location = new System.Drawing.Point(95, 493);
            this.distanciaLabel.Name = "distanciaLabel";
            this.distanciaLabel.Size = new System.Drawing.Size(0, 13);
            this.distanciaLabel.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 554);
            this.Controls.Add(this.distanciaLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stopSelector);
            this.Controls.Add(this.originSelector);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.routeDataGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mapita);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.routeDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapita;
        private System.Windows.Forms.DataGridView routeDataGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox originSelector;
        private System.Windows.Forms.ComboBox stopSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label distanciaLabel;
    }
}

