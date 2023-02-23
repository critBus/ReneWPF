using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
namespace ReneUtiles.Clases.WPF
{
    public class ManagerSelectionIndex
    {
        public SelectionChangedEventHandler evento;
        public Selector seleccionador;

        public ManagerSelectionIndex(SelectionChangedEventHandler evento, Selector seleccionador)
        {
            this.evento = evento;
            this.seleccionador = seleccionador;
        }

        private void ejecutarAccion(Action accion) {
            this.seleccionador.SelectionChanged -= this.evento;
            accion();
            this.seleccionador.SelectionChanged += this.evento;
        }

        public virtual void selectIndex(int indice) {
            ejecutarAccion(()=> this.seleccionador.SelectedIndex = indice);
            
            
        }

        public virtual void add(ICollection<string> items)
        {
            ejecutarAccion(() => {
                foreach (string item in items)
                {
                    this.seleccionador.Items.Add(item);
                }
            });


        }
        public void clear()
        {
            ejecutarAccion(() => this.seleccionador.Items.Clear());


        }
    }
}
