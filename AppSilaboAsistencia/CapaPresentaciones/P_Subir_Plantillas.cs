using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace CapaPresentaciones
{
    public partial class P_Subir_Plantillas : Form
    {
        //readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        public P_Subir_Plantillas()
        {
            InitializeComponent();
        }

        private void btnPlantillaSilabo_Click(object sender, EventArgs e)
        {
            P_SubirArchivo sa = new P_SubirArchivo("Plantilla Silabo");
            sa.ShowDialog();
            sa.Dispose();
        }

        private void btnPlanDeSesiones2y3_Click(object sender, EventArgs e)
        {
            P_SubirArchivo sa = new P_SubirArchivo("Plantilla Sesiones 2 y 3 créditos");
            sa.ShowDialog();
            sa.Dispose();
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            P_SubirArchivo sa = new P_SubirArchivo("Plantilla Sesiones 4 créditos");
            sa.ShowDialog();
            sa.Dispose();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
