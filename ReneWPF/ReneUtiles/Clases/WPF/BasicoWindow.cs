/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 04/29/2022
 * Hora: 13:19
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;


using System.Windows;
using System.Windows.Controls;


using ReneUtiles;


namespace ReneUtiles.Clases.WPF
{
	/// <summary>
	/// Description of BasicoWindow.
	/// </summary>
	public static  class BasicoWindow
	{


        //public static void addStrings(ListBox lb, params string[] items)
        //{

        //    items.ToList().ForEach(v => lb.Items.Add(v));
        //}
        public static void showDlg_Info(this Page w, string mensaje)
        {
            UtilesWPF.showDlg_Info(mensaje);
        }
        public static void showDlg_Info(this Window w, string mensaje)
        {
            UtilesWPF.showDlg_Info(mensaje);
        }
        public static void addStrings(this Page w, ListBox lb, params string[] items)
        {
            UtilesWPF.addStrings(lb, items);
        }
        public static void addStrings(this Window w, ListBox lb, params string[] items)
        {
             UtilesWPF.addStrings(lb,items);
        }

        public static void cwl(this Window w,object o)
        {
            UtilesConsola.cwl(o);
        }
        public static void cwl(this Window w)
        {
            UtilesConsola.cwl();
        }

        public static void cwl(this Page w, object o)
        {
            UtilesConsola.cwl(o);
        }
        public static void cwl(this Page w)
        {
            UtilesConsola.cwl();
        }

        public static void copiarW(this Window w, string o)
        {
            UtilesWPF.copiarW(o);
        }
        public static string getTextoDeW(this Window w)
        {
            return UtilesWPF.getTextoDeW();
        }
        public static string getText(this Window w, TextBox t)
        {
            return UtilesWPF.getText(t);
        }
        public static void setText(this Window w, TextBox t, string a)
        {
            t.Text = a;
        }

        public static int inT(this Window w, string a)
        {
            return Utiles.inT(a);
        }
        public static bool esNumero(this Window w, string a)
        {
            return Utiles.esNumero(a);
        }
        public static string remplazarAll<T>(this Window w, string a, string nuevo, params T[] olds)
        {
            return Utiles.remplazarAll<T>(a, nuevo, olds);
        }
        public static bool containsOR(this Window w, string palabra, params string[] A)
        {
            return Utiles.containsOR(palabra, A);
        }

        public static void showDlgAdvertencia(this Window w, string mensaje)
        {
            UtilesWPF.showDlgAdvertencia(mensaje);
        }
        public static bool isSelect(this Window w, CheckBox c)
        {
            return UtilesWPF.isSelect(c);
        }
        public static void setSelect(this Window w, CheckBox c, bool select)
        {
            UtilesWPF.setSelect(c, select);
        }



    }
}
