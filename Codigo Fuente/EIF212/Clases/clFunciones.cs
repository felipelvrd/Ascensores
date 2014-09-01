using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EIF212.Controles;

namespace EIF212.Clases
{
    public class clFunciones
    {
        //esto busca un proceso de prioridad jefe
        private static clProceso chkpriprocess(List<clProceso> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista.ElementAt(i).prioridad == true)
                {
                    return lista.ElementAt(i);
                }
            }
            return null;
        }

        //lista los pisos quie se encuentran en el rango entre el asensor y el piso destino
        public static clProceso solicitudIntermedia(List<clProceso> listaTotal, int acensor)
        {
            Boolean cambio=false;
            int destino = listaTotal.ElementAt(0).origen;
            if (listaTotal.ElementAt(0).origenE) 
            {
                destino = listaTotal.ElementAt(0).destino;
            }
            List<clProceso> listaRango = new List<clProceso>();
            clProceso actual;

            // es por si acaso el acensor baja
            if (acensor > destino)
            {
                cambio = true;
                int aux = destino;
                destino = acensor;
                acensor = aux;
            }

            for (int i = 0; i <listaTotal.Count; i++)
            {
                actual = listaTotal.ElementAt(i);
                if (actual.origenE) // si es cierto ya se ejecuto el origen
                {
                    if ((acensor <= actual.destino) && (actual.destino <= destino)) //si es cierto este proceso si esta en el rango
                    {
                        listaRango.Add(actual);
                    }
                }
                else
                {
                    if ((acensor <= actual.origen) && (actual.origen <= destino))
                    {
                        listaRango.Add(actual);
                    }
                }

            }
            //de esta lista retornar el mas cercano
            //restar rango i - pos acensor 

            if (cambio)
            {
                int aux = destino;
                destino = acensor;
                acensor = aux;
            }

            int absMenor=13;
            clProceso masCercano=null;
            for (int i = 0; i <= listaRango.Count - 1; i++)
            { 
                if(listaRango.ElementAt(i).origenE)
                {
                    int calculo=Math.Abs(listaRango.ElementAt(i).destino - acensor);
                    if (absMenor > calculo)
                    { 
                        absMenor=calculo;
                        masCercano = listaRango.ElementAt(i);
                    }
                }
                else
                {
                    int calculo = Math.Abs(listaRango.ElementAt(i).origen - acensor);
                    if (absMenor > calculo)
                    {
                        absMenor = calculo;
                        masCercano = listaRango.ElementAt(i);
                    }                    
                }
            }
            return masCercano;
        }
        
        
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List<T> class
        //     that is empty and has the default initial capacity.
        public static void aceptarSolicitud(List<clProceso> lista, int piso, ucEdificio edificio, int iEdificio)
        {
            //lista
            //entero del piso
            //de esa lista actualizo o elimino los procesos que tienen que ver con ese piso
            clProceso actual;
            for (int i = 0; i < lista.Count; i++)
            {
                actual = lista.ElementAt(i);                
                if (actual.origenE && actual.destino==piso) //ya se ejecuto el origen y pertenece a piso
                {
                    if (lista.ElementAt(i).prioridad)
                        edificio.jefeSeMonto(true);
                    edificio.BeginInvoke(edificio.nSolicit, iEdificio, "eS 100% " + lista.ElementAt(i).origen + "-" + lista.ElementAt(i).destino);
                    //edificio.nuevaSolicitud(iEdificio, "eS 100% " + lista.ElementAt(i).origen + "-" + lista.ElementAt(i).destino);
                    lista.RemoveAt(i);
                    i = -1;
                }
                if (!actual.origenE && actual.origen==piso) //no se ha ejecutado y el origen pertecese a este piso
                {
                    edificio.BeginInvoke(edificio.nSolicit, iEdificio, "eS 50% " + lista.ElementAt(i).origen + "-" + lista.ElementAt(i).destino);
                    lista.ElementAt(i).origenE = true;
                }
            }
            
                                
        }

        public static clProceso planifica(List<clProceso> lista,int ascensor){

            clProceso proceso = chkpriprocess(lista);
            if (proceso != null)
                return proceso;

            proceso = solicitudIntermedia(lista, ascensor);
            if (proceso != null)
                return proceso;

            return lista.ElementAt(0);
        }
    }
}
