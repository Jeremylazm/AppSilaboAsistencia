using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.IO;
using SpreadsheetLight;
using Ayudas;
namespace CapaPresentaciones
{
    public partial class P_DialogoAgregarAsistenciaDocente : Form
    {
        readonly E_AsistenciaDiariaDocente ObjEntidadDoc;
        readonly N_AsistenciaDiariaDocente ObjNegocioDoc;
        public readonly string LmFechaInf;
        private readonly string CodSemestre;
        private readonly string CodDepartamentoA="IF";
        public P_DialogoAgregarAsistenciaDocente()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            LmFechaInf = Semestre.Rows[0][1].ToString();
            ObjEntidadDoc = new E_AsistenciaDiariaDocente();
            ObjNegocioDoc = new N_AsistenciaDiariaDocente();

            InitializeComponent();
            cxtMotivo.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /*//agregar una fecha actual
            DataTable DocentesDA = N_Docente.MostrarDocentesDepartamento(CodDepartamentoA);
            try
            {
                foreach (DataGridViewRow dr in dgvDatos.Rows)
                {
                    if (dr.Cells[2].Value.ToString() != "00000")
                    {
                        ObjEntidadDoc.CodSemestre = CodSemestre;
                        ObjEntidadDoc.CodDepartamentoA = "IF";
                        ObjEntidadDoc.Fecha = txtFecha.Text.ToString();
                        ObjEntidadDoc.Hora = hora;
                        ObjEntidadDoc.CodDocente = dr.Cells[2].Value.ToString();
                        ObjEntidadDoc.Asistio = (dr.Cells[0].Tag.Equals(true)) ? "SI" : "NO";
                        ObjEntidadDoc.Observacion = (dr.Cells[1].Value == null) ? "" : dr.Cells[1].Value.ToString();

                        ObjNegocioDoc.RegistrarAsistenciaDiariaDocente(ObjEntidadDoc);
                    }

                }
                A_Dialogo.DialogoConfirmacion("Se ha registrado correctamente la asistencia" + Environment.NewLine + " del los Docentes");
                Program.Evento = 0;
                Close();


            }
            catch (Exception)
            {
                A_Dialogo.DialogoError("Error al insertar el registro...");
            }*/
        }
    }
}
