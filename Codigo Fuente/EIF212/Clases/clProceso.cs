using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EIF212.Clases
{
    public class clProceso
    {
        public int origen;
        public int destino;
        public Boolean prioridad;
        public Boolean origenE;

        public clProceso(int origen, int destino, Boolean prioridad)
        {
            this.origen = origen;
            this.destino = destino;
            this.prioridad = prioridad;
        }
    }
}
