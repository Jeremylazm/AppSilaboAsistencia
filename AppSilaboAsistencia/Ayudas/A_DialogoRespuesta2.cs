﻿using System;
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
    public partial class A_DialogoRespuesta2 : Form
    {
        public A_DialogoRespuesta2(string Pregunta, string RespuestaVerdadera, string RespuestaFalsa)
        {
            InitializeComponent();
            Control[] Controles = { pbImagen, lblTitulo, lblPregunta };
            Docker.SubscribeControlsToDragEvents(Controles);

            lblPregunta.Text = Pregunta;
            btnVerdadero.Text = RespuestaVerdadera;
            btnFalso.Text = RespuestaFalsa;
        }

        private void P_DialogoRespuesta2_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            AparicionFormulario.Start();
        }

        private void FormAparicion_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.2;
            if (this.Opacity == 1)
            {
                AparicionFormulario.Stop();
                AparicionImagen.ShowSync(pbImagen);
                lblTitulo.Visible = true;
                lblPregunta.Visible = true;
                btnVerdadero.Visible = true;
                btnFalso.Visible = true;
            }
        }

        private void btnVerdadero_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnFalso_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
