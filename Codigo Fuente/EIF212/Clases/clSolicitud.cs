using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EIF212.Clases
{
    public class clSolicitud
    {
        public clSolicitud(string solicitud)
        {
            Descripcion = solicitud;
        }
        public string Descripcion { get; set; }

    }
}
