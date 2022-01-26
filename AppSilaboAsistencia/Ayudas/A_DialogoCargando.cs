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

        public void Mostrar()
        {
            this.TopMost = true;
            this.Show();
            this.Opacity = 0.0;
            AparicionFormulario.Start();
        }

        private void A_DialogoCargando_Load(object sender, EventArgs e)
        {
            
        }

        private void AparicionFormulario_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.2;
            if (this.Opacity == 1)
            {
                AparicionFormulario.Stop();
                pbProgreso.Visible = true;
                lblTitulo.Visible = true;
                lblMensaje.Visible = true;
            }
        }

        public void Ocultar()
        {
            this.TopMost = false;
            this.Hide();
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    Task.Factory.StartNew(Trabajador).ContinueWith(T => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());  
        //}
    }
}
