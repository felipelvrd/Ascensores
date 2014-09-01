using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EIF212.Clases;


namespace EIF212
{
    public partial class FrmPrincipal : Form
    {
        private int cant;
        public FrmPrincipal(int cant)
        {
            this.cant = cant;
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucEdificio1.death();
            ucEdificio2.death();
            ucEdificio3.death();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switch (cant)
            {
                case 0:
                    ucEdificio1.inciarEdificios();
                    break;
                case 1:
                    ucEdificio1.inciarEdificios();
                    ucEdificio2.Visible = true;
                    ucEdificio2.inciarEdificios();
                    break;
                case 2:
                    ucEdificio1.inciarEdificios();
                    ucEdificio2.Visible = true;
                    ucEdificio2.inciarEdificios();
                    ucEdificio3.Visible = true;
                    ucEdificio3.inciarEdificios();
                    break;
            }
        }

        private void chckPausa_CheckedChanged(object sender, EventArgs e)
        {
            ucEdificio1.pausa = chckPausa.Checked;
            ucEdificio2.pausa = chckPausa.Checked;
            ucEdificio3.pausa = chckPausa.Checked;
        }

    }
}
