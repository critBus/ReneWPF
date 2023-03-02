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
            //accionSubproseso();
            //eventos.alTerminar();
            UtilesSubprocesos.subp(
                () =>
                {
                    try
                    {
                        eventos.antesDeComenzar?.Invoke();
                        accionSubproseso();
                        eventos.alTerminar();
                        //UtilesWPF.subpVisual(eventos.alTerminar);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        eventos.siDaError(ex);
                        //UtilesWPF.subpVisual(() => eventos.siDaError(ex));

                    }
                    eventos.alConcluirSiempre?.Invoke();

                }

                        );



        }
    }
}
