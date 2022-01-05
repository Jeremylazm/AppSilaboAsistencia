using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPerzonalizados
{
    public partial class C_Campo : UserControl
    {
        public C_Campo(string Titulo, string Valor)
        {
            InitializeComponent();

            lblTitulo.Text = Titulo;
            txtValor.Text = Valor;

            if (txtValor.Width > lblTitulo.Width)
            {
                this.Width = txtValor.Width + 27;
                lnValor.Width = txtValor.Width;
            }
            else
            {
                this.Width = lblTitulo.Width + 27;
                lnValor.Width = lblTitulo.Width;
            }
        }
    }
}
