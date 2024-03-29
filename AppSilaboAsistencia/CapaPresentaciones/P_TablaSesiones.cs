﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using SpreadsheetLight;
using CapaEntidades;
using CapaNegocios;
using ClosedXML.Excel;

namespace CapaPresentaciones
{
    public partial class P_TablaSesiones : Form
    {
        private DataTable Resultados;
        private XLWorkbook Libro;
        private int NroCreditos;

        public P_TablaSesiones(DataTable pResultados, XLWorkbook pLibro, string CodAsignatura, int pNroCreditos)
        {
            Resultados = pResultados;
            Libro = pLibro;
            NroCreditos = pNroCreditos;
            InitializeComponent();
            Control[] Controles = { this, lblTitulo, pbLogo };
            Docker.SubscribeControlsToDragEvents(Controles);
            lblTitulo.Text += CodAsignatura;
            Bunifu.Utils.DatagridView.BindDatagridViewScrollBar(dgvSesiones, sbDatos);
        }

        private void AjustarTabla()
        {
            // Verificar el numero de filas de los resultados
            if (dgvSesiones.Rows.Count <= 20)
            {
                sbDatos.Visible = false;
                this.Height = dgvSesiones.Rows.Count * 26 + 102;
            }
            else
            {
                sbDatos.Visible = true;
                this.Height = 622;
            }
        }

        private void P_TablaSesiones_Load(object sender, EventArgs e)
        {
            DataTable ResultadosFinales = new DataTable();
            ResultadosFinales.Columns.Add("Sesión", typeof(int));
            ResultadosFinales.Columns.Add("Tema", typeof(string));
            ResultadosFinales.Columns.Add("Fecha", typeof(string));
            ResultadosFinales.Columns.Add("Estado", typeof(string));

            int[] TemasAvanzados = new int[Resultados.Rows.Count];

            for (int i = 0; i < Resultados.Rows.Count; i++)
            {
                TemasAvanzados[i] = Convert.ToInt32(Resultados.Rows[i]["Sesión"].ToString());
                ResultadosFinales.Rows.Add(Convert.ToInt32(Resultados.Rows[i]["Sesión"].ToString()), Resultados.Rows[i]["NombreTema"].ToString(), Resultados.Rows[i]["Fecha"].ToString(), "HECHO");
            }

            int Total = 0;
            int Contador = 1;
            int NroFilas = 0;

            if (NroCreditos == 4)
                NroFilas = 61;
            else
                NroFilas = 43;

            for (int i = 9; i <= NroFilas; i++)
            {
                if (Libro.Worksheet(1).Cell("E" + Convert.ToString(i)).Value.ToString() != "")
                {
                    if (!Array.Exists(TemasAvanzados, x => x == Convert.ToInt32(Libro.Worksheet(1).Cell("B" + Convert.ToString(i)).Value.ToString())))
                    {
                        if (Total == Resultados.Rows.Count)
                            ResultadosFinales.Rows.Add(Contador, Libro.Worksheet(1).Cell("C" + Convert.ToString(i)).Value.ToString(), "", "PROGRESO");
                        else
                            ResultadosFinales.Rows.Add(Contador, Libro.Worksheet(1).Cell("C" + Convert.ToString(i)).Value.ToString(), "", "FALTA");
                    }

                    Total++;
                    Contador++;
                }
            }

            dgvSesiones.DataSource = ResultadosFinales;

            foreach (DataGridViewColumn Columna in dgvSesiones.Columns)
            {
                Columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvSesiones.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvSesiones.Columns[0].MinimumWidth = 60;
            dgvSesiones.Columns[0].Width = 60;

            dgvSesiones.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvSesiones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvSesiones.Columns[2].MinimumWidth = 120;
            dgvSesiones.Columns[2].Width = 120;

            dgvSesiones.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvSesiones.Columns[3].MinimumWidth = 120;
            dgvSesiones.Columns[3].Width = 120;

            AjustarTabla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
