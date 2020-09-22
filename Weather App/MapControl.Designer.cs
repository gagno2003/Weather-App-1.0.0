namespace Weather_App
{
    partial class MapControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MapPR = new GMap.NET.WindowsForms.GMapControl();
            this.lonlatreset = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MapPR
            // 
            this.MapPR.Bearing = 0F;
            this.MapPR.CanDragMap = true;
            this.MapPR.EmptyTileColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MapPR.GrayScaleMode = false;
            this.MapPR.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MapPR.LevelsKeepInMemory = 5;
            this.MapPR.Location = new System.Drawing.Point(0, 0);
            this.MapPR.MarkersEnabled = true;
            this.MapPR.MaxZoom = 100;
            this.MapPR.MinZoom = 2;
            this.MapPR.MouseWheelZoomEnabled = true;
            this.MapPR.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MapPR.Name = "MapPR";
            this.MapPR.NegativeMode = false;
            this.MapPR.PolygonsEnabled = true;
            this.MapPR.RetryLoadTile = 0;
            this.MapPR.RoutesEnabled = true;
            this.MapPR.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MapPR.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MapPR.ShowTileGridLines = false;
            this.MapPR.Size = new System.Drawing.Size(720, 331);
            this.MapPR.TabIndex = 0;
            this.MapPR.Zoom = 0D;
            // 
            // lonlatreset
            // 
            this.lonlatreset.Tick += new System.EventHandler(this.lonlatreset_Tick);
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.MapPR);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(720, 331);
            this.Load += new System.EventHandler(this.MapControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl MapPR;
        private System.Windows.Forms.Timer lonlatreset;
    }
}
