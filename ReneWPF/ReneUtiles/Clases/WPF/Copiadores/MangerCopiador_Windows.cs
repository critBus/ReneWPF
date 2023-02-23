using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReneUtiles;
using ReneUtiles.Clases;
using ReneUtiles.Clases.Copiador;
using Microsoft.VisualBasic.FileIO;
using Delimon.Win32.IO;

using ReneUtiles.Clases.Basicos;

namespace ReneUtiles.Clases.WPF.Copiadores
{
    public class MangerCopiador_Windows:MangerCopiador
    {
        RArrayList<Direcciones_Y_Destino> direccionesACopiar=new RArrayList<Direcciones_Y_Destino>();
        public bool copiando = false;

        public override void addDirecciones(params Direcciones_Y_Destino[] direcciones) {
            direccionesACopiar.AddRange(direcciones);
            if (!copiando) {
                UtilesSubprocesos.subp(() => {
                    copiando = true;
                    foreach (Direcciones_Y_Destino dd in direccionesACopiar)
                    {
                        foreach (string url in dd.sources)
                        {
                            if (Archivos.esCarpeta(url))
                            {
                                FileSystem.CopyDirectory(url, dd.destino, UIOption.AllDialogs, UICancelOption.DoNothing);

                            }
                            else if (Archivos.esArchivo(url))
                            {
                                FileSystem.CopyFile(url, dd.destino + "/" + new FileInfo(url).Name, UIOption.AllDialogs, UICancelOption.DoNothing);
                            }
                        }

                    }
                    direccionesACopiar.Clear();
                    copiando = false;
                });
            }
            
            
        }
    }
}
