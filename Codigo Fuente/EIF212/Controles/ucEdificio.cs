using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EIF212.Controles;

using EIF212.Clases;
using System.Threading;

namespace EIF212.Controles
{
    public partial class ucEdificio : UserControl
    {
        public List<clProceso>[] fifo;
        public Boolean pausa;
        public delegate void nSolicitud(int i, string des);
        public nSolicitud nSolicit;

        ucPuerta[,] mtzPuerta;
        ucIndicador[,] mtzBoton;
        Thread[] hAscensor;
        List<clSolicitud>[] solicitudes;
        DataGridView[] dtgSolicitudes;
        int[] posicion; 
        delegate void cola(ucCola ucCola1, List<clProceso> fifo);
        cola Cola;
        ucCola[] colas;
        ucEjecutando[] ejecutandos;
        Panel[] panels;
        
        public ucEdificio()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            mtzPuerta = new ucPuerta[10,4];
            mtzBoton = new ucIndicador[10, 4];
            solicitudes = new List<clSolicitud>[4];
            dtgSolicitudes = new DataGridView[4];
            contruirPuertas();
            contruirBoton();
            fifo = new List<clProceso>[4];
            hAscensor = new Thread[4];
            posicion = new int[4];
            Cola = new cola(updateCola);
            nSolicit = new nSolicitud(nuevaSolicitud);
            colas = new ucCola[4];
            ejecutandos=new ucEjecutando[4];
            panels = new Panel[4];

            //ascensor #1
            panel1.edificio = this;
            panel1.asencensor = 0;
            panel1.cola = ucCola1;
            fifo[0] = new List<clProceso>();
            hAscensor[0] = new Thread(fAscensor1);
            colas[0] = ucCola1;
            ejecutandos[0] = ucEjecutando1;
            panels[0] = panel1;
            solicitudes[0] = new List<clSolicitud>();
            dtgSolicitudes[0] = dataGridView0;

            //ascensor #2
            panel2.edificio = this;
            panel2.asencensor = 1;
            panel2.cola = ucCola2;
            fifo[1] = new List<clProceso>();
            hAscensor[1] = new Thread(fAscensor2);
            colas[1] = ucCola2;
            ejecutandos[1] = ucEjecutando2;
            panels[1] = panel2;
            solicitudes[1] = new List<clSolicitud>();
            dtgSolicitudes[1] = dataGridView1;

            //ascensor #3
            panel3.edificio = this;
            panel3.asencensor = 2;
            panel3.cola = ucCola3;
            fifo[2] = new List<clProceso>();
            hAscensor[2] = new Thread(fAscensor3);
            colas[2] = ucCola3;
            ejecutandos[2] = ucEjecutando3;
            panels[2] = panel3;
            solicitudes[2] = new List<clSolicitud>();
            dtgSolicitudes[2] = dataGridView2;

            //ascensor #4
            panel4.edificio = this;
            panel4.asencensor = 3;
            ejecutandos[3] = ucEjecutando4;
            panel4.cola = ucCola4;
            fifo[3] = new List<clProceso>();
            hAscensor[3] = new Thread(fAscensor4);
            panels[3] = panel4;
            colas[3] = ucCola4;
            solicitudes[3] = new List<clSolicitud>();
            dtgSolicitudes[3] = dataGridView3;
        }

        private void contruirPuertas()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 4;j++ )
                {
                    ucPuerta x = new ucPuerta();
                    x.Location = new System.Drawing.Point(52 + (42 * j), 380 - (40 * i));
                    x.Size = new System.Drawing.Size(19, 16);
                    mtzPuerta[i, j] = x;
                    pEdificio.Controls.Add(x);
                }
        }

        private void contruirBoton()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 4; j++)
                {
                    ucIndicador x = new ucIndicador();
                    x.Location = new System.Drawing.Point(56+(42*j), 368 - (40 * i));
                    x.Size = new System.Drawing.Size(10, 10);
                    mtzBoton[i, j] = x;
                    if (i == 0)
                        x.Rojo();
                    pEdificio.Controls.Add(x);
                }
        }

        private void funciona(int a)
        {
            while (fifo[a].Count == 0 || pausa) { Thread.Sleep(500); }
            clProceso proceso = clFunciones.planifica(fifo[a],posicion[a]);
            ejecutandos[a].set(proceso);
            int destino = proceso.destino;
            if(!proceso.origenE)
                destino = proceso.origen;
            int dir=-1;
            if (destino > posicion[a])
            {
                dir = 1;
            }
            if (!(destino==posicion[a]))
            {
                posicion[a]+=dir;
                BeginInvoke(nSolicit,a, "aP " + posicion[a].ToString());
                mtzBoton[posicion[a], a].Rojo();
                mtzBoton[posicion[a]-dir, a].verde();
                Thread.Sleep(1000);
            }
                if (destino == posicion[a])
                {
                    mtzPuerta[destino, a].Abrir();
                    Thread.Sleep(2000);
                    mtzPuerta[destino, a].Cerrar();
                    Thread.Sleep(2000);
                    clFunciones.aceptarSolicitud(fifo[a], posicion[a],this,a);
                    ucCola1.BeginInvoke(Cola, colas[a], fifo[a]);
                }
        }
        private void fAscensor1()
        {
            funciona(0);
            hAscensor[0] = new Thread(fAscensor1);
            hAscensor[0].Start();
        }

        private void fAscensor2()
        {
            funciona(1);
            hAscensor[1] = new Thread(fAscensor2);
            hAscensor[1].Start();
        }

        private void fAscensor3()
        {
            funciona(2);
            hAscensor[2] = new Thread(fAscensor3);
            hAscensor[2].Start();
        }

        private void fAscensor4()
        {
            funciona(3);
            hAscensor[3] = new Thread(fAscensor4);
            hAscensor[3].Start();
        }
        private static void updateCola(ucCola ucCola1, List<clProceso> fifo)
        {
            ucCola1.update(fifo);
            ucCola1.Refresh();
        }

        public void death()
        {
            for (int i = 0; i < 4; i++)
                hAscensor[i].Abort();
        }
        public void jefeSeMonto(Boolean x)
        {
            for (int i = 0; i < 4; i++)
                panels[i].bJefe(x);             
        }

        public void nuevaSolicitud(int i, string des)
        {
            solicitudes[i].Add(new clSolicitud(des));
            dtgSolicitudes[i].DataSource = (from t in solicitudes[i] where t.Descripcion.Contains("S") || !chckResumen.Checked select t).ToList();
        }

        private void chckResumen_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                dtgSolicitudes[i].DataSource = (from t in solicitudes[i] where t.Descripcion.Contains("S") || !chckResumen.Checked select t).ToList();
        }

        public void inciarEdificios()
        {
            for(int i=0;i<4;i++)
                hAscensor[i].Start();
        }
    }
}
