using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EIF212
{
    public partial class FrmCant : Form
    {
        public FrmCant()
        {
            InitializeComponent();
        }

        private void FrmCant_Load(object sender, EventArgs e)
        {
            cbCant.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbCant.SelectedIndex != -1)
            {
                Cursor = Cursors.WaitCursor;
                new FrmPrincipal(cbCant.SelectedIndex).Show();
                this.Hide();
            }
        }
    }
}
