using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ReneUtiles.Clases.WPF
{
    public class MangerColumnaChB<E>
    {
        private bool actualizar_desde_CB = true;
        private bool actualizar_ToB_SeleccionarTodos = true;

        List<E> elementos;
        public ToggleButton TB_Todos;

        public Action<E, bool> metodo_SetSeleccionado;
        public Func<E,bool,bool> metodo_CoincideSeleccion;
        public Predicate<E> metodo_IsSeleccionado;

        public Action<E> metodo_alCambiarEstado;//cuando cambian varias se llama una ves al final

        public Selector listaVisual;

        public MangerColumnaChB(List<E> elementos, Selector listaVisual, ToggleButton TB_Todos,string nombrePropiedad, Action<E> metodo_alCambiarEstado) {
            this.elementos = elementos;
            this.TB_Todos = TB_Todos;

            metodo_SetSeleccionado = (v, seleccionado) => UtilesReflexion.setValuePropiedad(v, nombrePropiedad, seleccionado);
            metodo_IsSeleccionado = v => UtilesReflexion.getValuePropiedad<E,bool>(v, nombrePropiedad);
            metodo_CoincideSeleccion = (v, seleccionado) => metodo_IsSeleccionado(v)==seleccionado;
            this.metodo_alCambiarEstado = metodo_alCambiarEstado;
            this.listaVisual = listaVisual;
        }

        public void alApretar_TB_MarcarTodos(bool chequed)
        {
            if (actualizar_ToB_SeleccionarTodos)
            {
                actualizar_desde_CB = false;
                this.elementos.ForEach(v =>
                {
                    if (!this.metodo_CoincideSeleccion(v, chequed))
                    {
                        //v.seleccionado = chequed;
                        this.metodo_SetSeleccionado(v,chequed);
                    }
                    //if (v.seleccionado != chequed)
                    //{
                    //    v.seleccionado = chequed;
                    //}
                });
                //actualizar_TB_espacio_que_ocupan_las_series_del_paquete_seleccionadas2();
                metodo_alCambiarEstado(default(E));
                actualizar_desde_CB = true;
            }

        }

        private void actualizar_ToB_SeleccionarTodos_deSerNecesario()
        {
            bool estado = true;
            foreach (E s in elementos)
            {
                if (!metodo_IsSeleccionado(s))
                {
                    estado = false;
                    break;
                }
            }
            if (estado != TB_Todos.IsChecked)
            {
                actualizar_ToB_SeleccionarTodos = false;
                TB_Todos.IsChecked = estado;
                actualizar_ToB_SeleccionarTodos = true;
            }
        }


        public void Alseleccionar_Elemento()
        {
            if (actualizar_desde_CB)
            {
                metodo_alCambiarEstado(listaVisual.SelectedIndex!=-1?(E) listaVisual.SelectedItem:default(E));
                actualizar_ToB_SeleccionarTodos_deSerNecesario();
            }

        }
    }
}
