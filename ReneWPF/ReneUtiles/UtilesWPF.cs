/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 04/29/2022
 * Hora: 20:22
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using Delimon.Win32.IO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
//using System.Windows.Data;


namespace ReneUtiles
{
	/// <summary>
	/// Description of UtilesWPF.
	/// </summary>
	public abstract class UtilesWPF
	{
        //public static void seleccionar_sinOnChange(ComboBox cb,int indice) {

        //    cb.SelectionChanged += (a, b) => { };

        //    SelectionChangedEventHandler evento = cb.SelectionChanged;


        //}

        public static void showDlg_Info(string mensaje) {
            System.Windows.MessageBox.Show(mensaje);
        }

        public static void ponerColorExisteArchivo(TextBox tb,Action<FileInfo> accionSiExiste=null,Predicate<FileInfo> validacionAdicional=null)
        {
            
            bool existe = false;
            try {
                FileInfo f = new FileInfo(tb.Text);
                existe = f.Exists;
                if (existe) {
                    if (validacionAdicional != null)
                    {
                        existe = validacionAdicional(f);
                    }
                    if (existe)
                    {
                        accionSiExiste?.Invoke(f);
                    }
                }
                
                
            } catch {

            }
            tb.Foreground = existe ? Brushes.Green : Brushes.Red;
        }

        public static void addExtencionFileDlg(FileDialog fd, params string[] paresExplicacionExtencion)
        {


            int length = paresExplicacionExtencion.Length;
            if (length % 2 == 0)
            {
                string extenciones = fd.Filter;
                for (int i = 0; i < length; i += 2)
                {
                    bool esPrimeraExtencion = String.IsNullOrWhiteSpace(extenciones);
                    if (esPrimeraExtencion)
                    {
                        fd.DefaultExt = paresExplicacionExtencion[i + 1];
                    }
                    extenciones += (esPrimeraExtencion ? "" : "|") + paresExplicacionExtencion[i] + "(*" + paresExplicacionExtencion[i + 1] + ")|*" + paresExplicacionExtencion[i + 1];
                    //Console.WriteLine(extenciones);
                }
                fd.Filter = extenciones;
            }


        }

        public static void buscarArchivo(
            
            Func<string> getDireccionPordefecto
            , Action<FileInfo> accionAEncontrarFichero
            ,params string[] extencionesAceptadas
            )
        {
            //openfile.Filter = "SQLite (*.acconf)|*.*";
            //string filter = "";
            //foreach (string ext in extencionesAceptadas)
            //{
            //    filter += ext.ToUpper().Replace(".","") + " ";
            //    filter += "(" + (ext.StartsWith("*") ? ext : "*" + ext) + ")";
            //    filter += "|";
            //}
            //filter += "*.*";
            //filter = Utiles.subs(filter, 0, filter.Length - 1);

            string dir = "";

            OpenFileDialog openfile = new OpenFileDialog();

            string[] pares_explicacios_extenciones = new string[extencionesAceptadas.Length*2];
            for (int i = 0; i < extencionesAceptadas.Length; i+=2)
            {
                string ext = extencionesAceptadas[i];
                pares_explicacios_extenciones[i] = ext.ToUpper().Replace(".", "");
                pares_explicacios_extenciones[i + 1] = ext;
            }

            addExtencionFileDlg(openfile, pares_explicacios_extenciones);
            //openfile.Filter = filter;
            //openfile.Filter = "SQLite (*.exe)|*.*";

            string dirAnterior = getDireccionPordefecto();
            if (dirAnterior.Length > 0)
            {
                openfile.InitialDirectory = dirAnterior;
            }
            bool? result = openfile.ShowDialog();
            if (result != null && result == true)
            {


                dir = openfile.FileName;
                accionAEncontrarFichero(new FileInfo(dir));

            }
        }

        public static void addStrings(ListBox lb, params string[] items)
        {
            
            items.ToList().ForEach(v => lb.Items.Add(v));
        }

		public static string getTextoDeW()
		{
			
			//System.Windows.Data.ObjectDataProvider
			Object O = Clipboard.GetDataObject();
			if (O != null && O is System.Windows.DataObject) {
				System.Windows.DataObject o = (System.Windows.DataObject)O;
				if (o.ContainsText()) {
					return o.GetText();
				}
			}
			return "";
			//
			//return Clipboard.GetDataObject()+"";
			//return o.ContainsText()+"";
			//return o.GetText();
		}
		public static bool isSelect(CheckBox c)
		{
			return c.IsChecked == true;
		}

        public static void setSelect(CheckBox c,bool select)
        {
             c.IsChecked = select;
        }
        public static void copiarW(string a)
		{
			Clipboard.SetDataObject(a);
			
		}
		
		public static string getText(TextBox t)
		{
			return t.Text.Replace("\r", "");
		}
		
		public static void showDlgAdvertencia(string mensaje)
		{
			MessageBox.Show(messageBoxText: mensaje);
		}
		
		public static void subpVisual(Action metodo)
		{
            //Application.Current.Dispatcher.Invoke(new Action(() => {
            //                       metodo();
            //}));
            //System.Windows.Application.Current.Dispatcher.Invoke(metodo);
            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, metodo);
        }
	}
}
