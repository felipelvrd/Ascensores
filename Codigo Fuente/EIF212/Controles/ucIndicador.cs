using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EIF212.Controles
{
    public partial class ucIndicador : UserControl
    {
        public int piso;
        public ucIndicador()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
        }
        /// <summary>
        /// el boton pasa de 
        ///     -> verde    a rojo = piso por donde viene
        ///     -> amarillo a rojo = piso donde llega a la solicitud
        /// </summary>
        public void Rojo() 
        {
            pictureBox1.Image = global::EIF212.Properties.Resources.luz_asensor_ocupado;
        }
        /// <summary>
        /// el boton pasa de
        ///     -> rojo     a verde = el piso esta libre de solicitud o paro
        ///     -> amarillo a verde= se llevo la solicitud
        /// </summary>
        public void verde()
        {
            pictureBox1.Image = global::EIF212.Properties.Resources.luz_asensor_libre;
        }

        private void ucIndicador_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Size = this.Size;
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Size = Size;
        }


    }
}
