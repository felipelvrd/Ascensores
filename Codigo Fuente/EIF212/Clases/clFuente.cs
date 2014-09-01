using System.Runtime.InteropServices;
using System.Drawing.Text;
using System;
using System.Drawing;

namespace EIF212.Clases
{
    public class clFuente
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily ff;
        Font font;
        public void CargoPrivateFontCollection()
        {
            // CREO EL BYTE[] Y TOMO SU LONGITUD
            byte[] fontArray = EIF212.Properties.Resources.Fipps_Regular;
            int dataLength = EIF212.Properties.Resources.Fipps_Regular.Length;


            // ASIGNO MEMORIA Y COPIO BYTE[] EN LA DIRECCION
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);


            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            //PASO LA FUENTE A LA PRIVATEFONTCOLLECTION
            pfc.AddMemoryFont(ptrData, dataLength);

            //LIBERO LA MEMORIA "UNSAFE"
            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Bold);
        }

        private Font CargoEtiqueta(Font font)
        {
            FontStyle fontStyle = FontStyle.Regular;
            return new System.Drawing.Font(ff, 5.2F, fontStyle);
        }

        public Font fuente()
        {
            return CargoEtiqueta(font);
        }
    }
}