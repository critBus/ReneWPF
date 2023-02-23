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
    class EventosEnSubprocesoWPF : EventosEnSubproceso
    {
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
