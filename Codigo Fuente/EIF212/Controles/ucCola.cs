using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EIF212.Clases;
using System.Threading;

namespace EIF212.Controles
{
    public partial class ucCola : UserControl
    {
        private int p = 0;
        public ucCola()
        {
            InitializeComponent();
           // CheckForIllegalCrossThreadCalls = false;
        }

        private void addItem(clProceso x){
            ucEjecutando solicitud = new ucEjecutando();

            solicitud.Location = new System.Drawing.Point(0, p);

            solicitud.set(x);

            p += 31;

            panel1.Size = new System.Drawing.Size(panel1.Size.Width, panel1.Size.Height + 31);

            
            panel1.Controls.Add(solicitud);
        }

        public void update(List<clProceso> lista)
        {
            p = 0;
            panel1.Size = new System.Drawing.Size(panel1.Size.Width, 10);
            panel1.Controls.Clear();
            for (int i = 0; i < lista.Count; i++)
                addItem(lista.ElementAt(i));
        }
    }
}
