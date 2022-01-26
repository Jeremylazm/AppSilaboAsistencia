using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayudas
{
    public partial class A_DialogoCargando : Form
    {
        public Action Trabajador { get; set; }

        public A_DialogoCargando()
        {
            InitializeComponent();

            //if (pTrabajador == null)
            //{
            //    throw new ArgumentNullException();
            //}
            //Trabajador = pTrabajador;
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    Task.Factory.StartNew(Trabajador).ContinueWith(T => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());  
        //}
    }
}
