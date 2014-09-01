using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EIF212.Controles
{
    public partial class ucPuerta : UserControl
    {
        private Thread t;
        private Boolean bAbrir;

        public ucPuerta()
        {
            InitializeComponent();
            t = new Thread(funcion);
        }

        private void ucPuerta_Resize(object sender, EventArgs e)
        {
            pictureBox1.Size = this.Size;
        }

        private void funcion()
        {
            if (bAbrir)
            {
                pictureBox1.Image = global::EIF212.Properties.Resources.elevador1;
                Thread.Sleep(100);
                pictureBox1.Image = global::EIF212.Properties.Resources.elevador2;
                Thread.Sleep(100);
                pictureBox1.Image = global::EIF212.Properties.Resources.elevador3;
                Thread.Sleep(100);
                pictureBox1.Image = global::EIF212.Properties.Resources.elevador4;
            }
            else
            {
                pictureBox1.Image = global::EIF212.Properties.Resources.elevador4;
                Thread.Sleep(100);
                pictureBox1.Image = global::EIF212.Properties.Resources.elevador3;
                Thread.Sleep(100);
                pictureBox1.Image = global::EIF212.Properties.Resources.elevador2;
                Thread.Sleep(100);
                pictureBox1.Image = global::EIF212.Properties.Resources.elevador1;
            }
            t = new Thread(funcion);
        }
        public void Abrir()
        {
            bAbrir = true;
            t.Start();
        }
        public void Cerrar()
        {
            bAbrir = false;
            t.Start();
        }
    }
}
