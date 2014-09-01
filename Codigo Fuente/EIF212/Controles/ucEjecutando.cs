using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EIF212.Clases;

namespace EIF212.Controles
{
    public partial class ucEjecutando : UserControl
    {
        private Image[] habilitado;
        private Image[] ejecutando;
        public ucEjecutando()
        {
            InitializeComponent();
            habilitado = new Image[] { global::EIF212.Properties.Resources.n0, global::EIF212.Properties.Resources.n1, global::EIF212.Properties.Resources.n2, global::EIF212.Properties.Resources.n3, global::EIF212.Properties.Resources.n4, global::EIF212.Properties.Resources.n5, global::EIF212.Properties.Resources.n6, global::EIF212.Properties.Resources.n7, global::EIF212.Properties.Resources.n8, global::EIF212.Properties.Resources.n9 };
            ejecutando = new Image[] { global::EIF212.Properties.Resources.n0r, global::EIF212.Properties.Resources.n1r, global::EIF212.Properties.Resources.n2r, global::EIF212.Properties.Resources.n3r, global::EIF212.Properties.Resources.n4r, global::EIF212.Properties.Resources.n5r, global::EIF212.Properties.Resources.n6r, global::EIF212.Properties.Resources.n7r, global::EIF212.Properties.Resources.n8r, global::EIF212.Properties.Resources.n9r };
        }
        public void set(clProceso x)
        {
            if (x.prioridad)
            {
                origen.Image = ejecutando[x.origen];
                destino.Image = ejecutando[x.destino];
            }
            else
            {
                origen.Image = habilitado[x.origen];
                destino.Image = habilitado[x.destino];
            }
            if (x.origenE)
                origen.Image = global::EIF212.Properties.Resources.menosicon;
        }
    }
}
