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
    public partial class Panel : UserControl
    {
       
        public ucEdificio edificio;
        public ucCola cola;
        public int asencensor;
        public bool jefe =false;
        private clFuente fuente = new clFuente();

        //es para saber cual es el destino... que puede cambiar muchas veces 
        int temporal = -1;
        int origen = 0;
       
        public Panel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        
        void actualOdestino(int x) 
        {
            if (temporal != x)
            {
                temporal = x;
                if (LabOrigeOdest.Text == "Origen")
                {
                    LabOrigeOdest.Text = "Destino";
                    origen = x;
                }
                else
                {
                    LabOrigeOdest.Text = "Origen"; // se termina la solicitud                
                    edificio.fifo[asencensor].Add(new clProceso(origen,x,jefe));// aca se agrega a la lista del acensor
                    if(jefe)
                        edificio.nuevaSolicitud(asencensor,"nSP "+ origen.ToString()+"-"+x.ToString());
                    else
                        edificio.nuevaSolicitud(asencensor, "nS " + origen.ToString() + "-" + x.ToString());
                    if(jefe)
                        edificio.jefeSeMonto(false);
                    cola.update(edificio.fifo[asencensor]);
                    
                    if (jefe)
                    {
                        LabPrioridad.Text = "Normal";
                        jefe = false;
                    }
                    origen = -1;
                    temporal = -1;
                }
            }
        }
        
        //boton jege
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            
            if (LabOrigeOdest.Text == "Origen")
            {
                if (!jefe)
                {
                    LabPrioridad.Text = "Jefe";
                    edificio.jefeSeMonto(false);
                    bJefe(true);
                }
                else
                {
                    LabPrioridad.Text = "Normal";
                    edificio.jefeSeMonto(true);
                }
                jefe = !jefe;                
            }

        }
        //______________________________________________________________________________
        //boton 1
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = global::EIF212.Properties.Resources._1deshabilitado;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
                pictureBox1.Image = global::EIF212.Properties.Resources._1habilitado;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = global::EIF212.Properties.Resources._1deshabilitado;
            actualOdestino(1);
        }
        //______________________________________________________________________________
        //boton 2
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = global::EIF212.Properties.Resources._2deshabilitado;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        { 
                pictureBox2.Image = global::EIF212.Properties.Resources._2habilitado;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = global::EIF212.Properties.Resources._2deshabilitado;
            actualOdestino(2);           
        }
        //______________________________________________________________________________
        //boton 3
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = global::EIF212.Properties.Resources._3deshabilitado;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
                pictureBox3.Image = global::EIF212.Properties.Resources._3habilitado;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = global::EIF212.Properties.Resources._3deshabilitado;
            actualOdestino(3);           
        }
        //_______________________________________________________________________________
        //boton 4
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = global::EIF212.Properties.Resources._4deshabilitado;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
                pictureBox4.Image = global::EIF212.Properties.Resources._4habilitado;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = global::EIF212.Properties.Resources._4deshabilitado;
            actualOdestino(4);           
        }
        //_______________________________________________________________________________
        //boton 5
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Image = global::EIF212.Properties.Resources._5deshabilitado;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
                pictureBox5.Image = global::EIF212.Properties.Resources._5habilitado;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = global::EIF212.Properties.Resources._5deshabilitado;
            actualOdestino(5);           
        }
        //_______________________________________________________________________________
        //boton 6
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Image = global::EIF212.Properties.Resources._6deshabilitado;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
                pictureBox6.Image = global::EIF212.Properties.Resources._6habilitado;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = global::EIF212.Properties.Resources._6deshabilitado;
            actualOdestino(6);           
        }
        //_______________________________________________________________________________
        //boton 7
        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Image = global::EIF212.Properties.Resources._7deshabilitado;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
                pictureBox7.Image = global::EIF212.Properties.Resources._7habilitado;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = global::EIF212.Properties.Resources._7deshabilitado;
            actualOdestino(7);           
        }
        //_______________________________________________________________________________
        //boton 8
        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Image = global::EIF212.Properties.Resources._8deshabilitado;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
                pictureBox8.Image = global::EIF212.Properties.Resources._8habilitado;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = global::EIF212.Properties.Resources._8deshabilitado;
            actualOdestino(8);           
        }        
        //_______________________________________________________________________________
        //boton Planta baja
        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.Image = global::EIF212.Properties.Resources.PBdeshabilitado;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
                pictureBox9.Image = global::EIF212.Properties.Resources.PBhabilitado;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            actualOdestino(0);           
        }
        //_______________________________________________________________________________
        //boton azotea
        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Image = global::EIF212.Properties.Resources.AZdeshabilitado;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
                pictureBox10.Image = global::EIF212.Properties.Resources.AZhabilitado;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            actualOdestino(9);           
        }

        public void bJefe(Boolean x)
        {
            btnJefe.Enabled = x;
        }

        private void Panel_Load(object sender, EventArgs e)
        {
            
            Fuente();
        }
        public void Fuente()
        {
            fuente.CargoPrivateFontCollection();
            Label1.Font = fuente.fuente();
            Label2.Font = fuente.fuente();
            LabPrioridad.Font = fuente.fuente();
            LabOrigeOdest.Font = fuente.fuente();
        }   
    }
}
