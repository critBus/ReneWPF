using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReneUtiles;
using ReneUtiles.Clases;


using ReneUtiles.Clases.Subprocesos;  



namespace ReneUtiles.Clases.WPF
{
    public class EventosEnSubprocesoWPF : EventosEnSubproceso
    {
        public EventosEnSubprocesoWPF(Action antesDeComenzar, Action alTerminar, Action<Exception> siDaError, Action alConcluirSiempre)
            :base(antesDeComenzar,alTerminar, siDaError, alConcluirSiempre)
        {
            this.antesDeComenzar = () => {
                if (antesDeComenzar!=null) {
                    subpVisual(antesDeComenzar);
                }
            };

            this.alTerminar = () =>
            {
                subpVisual(alTerminar);
            };

            this.siDaError = (e) =>
            {
                subpVisual(siDaError, e);
            };

            this.alConcluirSiempre = () => {
                if (alConcluirSiempre != null)
                {
                    subpVisual(alConcluirSiempre);
                }
            };

            
        }
        public EventosEnSubprocesoWPF(Action alTerminar, Action<Exception> siDaError) : base(alTerminar, siDaError)
            {

            this.alTerminar = () =>
            {
                subpVisual(alTerminar);
            };

            this.siDaError = (e) =>
            {
                subpVisual(siDaError, e);
            };


        }

        public static void subpVisual(Action metodo)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                metodo();
            }));
        }

        public static void subpVisual(Action<Exception> metodo, Exception e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                metodo(e);
            }));
        }
    }
}
