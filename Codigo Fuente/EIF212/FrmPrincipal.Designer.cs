namespace EIF212
{
    partial class FrmPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.chckPausa = new System.Windows.Forms.CheckBox();
            this.ucEdificio3 = new EIF212.Controles.ucEdificio();
            this.ucEdificio2 = new EIF212.Controles.ucEdificio();
            this.ucEdificio1 = new EIF212.Controles.ucEdificio();
            this.SuspendLayout();
            // 
            // chckPausa
            // 
            this.chckPausa.AutoSize = true;
            this.chckPausa.Location = new System.Drawing.Point(12, 695);
            this.chckPausa.Name = "chckPausa";
            this.chckPausa.Size = new System.Drawing.Size(154, 17);
            this.chckPausa.TabIndex = 1;
            this.chckPausa.Text = "Pausar Todos Los Edificios";
            this.chckPausa.UseVisualStyleBackColor = true;
            this.chckPausa.CheckedChanged += new System.EventHandler(this.chckPausa_CheckedChanged);
            // 
            // ucEdificio3
            // 
            this.ucEdificio3.BackColor = System.Drawing.Color.Transparent;
            this.ucEdificio3.Location = new System.Drawing.Point(890, 8);
            this.ucEdificio3.Name = "ucEdificio3";
            this.ucEdificio3.Size = new System.Drawing.Size(435, 684);
            this.ucEdificio3.TabIndex = 3;
            this.ucEdificio3.Visible = false;
            // 
            // ucEdificio2
            // 
            this.ucEdificio2.BackColor = System.Drawing.Color.Transparent;
            this.ucEdificio2.Location = new System.Drawing.Point(449, 8);
            this.ucEdificio2.Name = "ucEdificio2";
            this.ucEdificio2.Size = new System.Drawing.Size(435, 684);
            this.ucEdificio2.TabIndex = 2;
            this.ucEdificio2.Visible = false;
            // 
            // ucEdificio1
            // 
            this.ucEdificio1.BackColor = System.Drawing.Color.Transparent;
            this.ucEdificio1.Location = new System.Drawing.Point(8, 8);
            this.ucEdificio1.Name = "ucEdificio1";
            this.ucEdificio1.Size = new System.Drawing.Size(435, 684);
            this.ucEdificio1.TabIndex = 0;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1344, 717);
            this.Controls.Add(this.ucEdificio3);
            this.Controls.Add(this.ucEdificio2);
            this.Controls.Add(this.chckPausa);
            this.Controls.Add(this.ucEdificio1);
            this.Name = "FrmPrincipal";
            this.Text = "EIF212";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion 

        private Controles.ucEdificio ucEdificio1;
        private System.Windows.Forms.CheckBox chckPausa;
        private Controles.ucEdificio ucEdificio2;
        private Controles.ucEdificio ucEdificio3;



    }
}

