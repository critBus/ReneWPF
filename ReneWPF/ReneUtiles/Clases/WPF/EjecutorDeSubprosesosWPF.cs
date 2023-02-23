using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReneUtiles.Clases.Subprocesos;

namespace ReneUtiles.Clases.WPF
{
    public class EjecutorDeSubprosesosWPF : EjecutorDeSubprosesos
    {
        public override void ejecutar(EventosEnSubproceso eventos, Action accionSubproseso)
        {
            accionSubproseso();
            eventos.alTerminar();
            //UtilesSubprocesos.subp(
            //    () =>
            //    {
            //        try
            //        {
            //            accionSubproseso();
            //            UtilesWPF.subpVisual(eventos.alTerminar);

            //        }
            //        catch (Exception ex)
            //        {


            //            UtilesWPF.subpVisual(() => eventos.siDaError(ex));

            //        }


            //    }

            //            );



        }
    }
}
