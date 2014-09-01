namespace EIF212.Controles
{
    partial class ucEjecutando
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.origen = new System.Windows.Forms.PictureBox();
            this.destino = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.origen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destino)).BeginInit();
            this.SuspendLayout();
            // 
            // origen
            // 
            this.origen.BackColor = System.Drawing.Color.Transparent;
            this.origen.Image = global::EIF212.Properties.Resources.n8r;
            this.origen.Location = new System.Drawing.Point(6, 6);
            this.origen.Name = "origen";
            this.origen.Size = new System.Drawing.Size(20, 20);
            this.origen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.origen.TabIndex = 1;
            this.origen.TabStop = false;
            // 
            // destino
            // 
            this.destino.BackColor = System.Drawing.Color.Transparent;
            this.destino.Image = global::EIF212.Properties.Resources.n8r;
            this.destino.Location = new System.Drawing.Point(29, 6);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(20, 20);
            this.destino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.destino.TabIndex = 2;
            this.destino.TabStop = false;
            // 
            // ucEjecutando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EIF212.Properties.Resources.marco;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.destino);
            this.Controls.Add(this.origen);
            this.DoubleBuffered = true;
            this.Name = "ucEjecutando";
            this.Size = new System.Drawing.Size(54, 30);
            ((System.ComponentModel.ISupportInitialize)(this.origen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destino)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox origen;
        private System.Windows.Forms.PictureBox destino;


    }
}
