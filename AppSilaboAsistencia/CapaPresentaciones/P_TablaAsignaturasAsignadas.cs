using System.Data;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_TablaAsignaturasAsignadas : Form
    {
        public P_TablaAsignaturasAsignadas()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));

            // Create a DataRow, add Name and Age data, and add to the DataTable
            DataRow dr = dt.NewRow();
            dr["Name"] = "Mohammad"; // or dr[0]="Mohammad";
            dr["Age"] = 24; // or dr[1]=24;
            dt.Rows.Add(dr);

            // Create another DataRow, add Name and Age data, and add to the DataTable
            dr = dt.NewRow();
            dr["Name"] = "Shahnawaz"; // or dr[0]="Shahnawaz";
            dr["Age"] = 27; // or dr[1]=24;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Perez"; // or dr[0]="Shahnawaz";
            dr["Age"] = 90; // or dr[1]=24;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Bruno"; // or dr[0]="Shahnawaz";
            dr["Age"] = 78; // or dr[1]=24;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Jaime"; // or dr[0]="Shahnawaz";
            dr["Age"] = 44; // or dr[1]=24;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Pimpon"; // or dr[0]="Shahnawaz";
            dr["Age"] = 18; // or dr[1]=24;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Mulan"; // or dr[0]="Shahnawaz";
            dr["Age"] = 45; // or dr[1]=24;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Fiorella"; // or dr[0]="Shahnawaz";
            dr["Age"] = 34; // or dr[1]=24;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Quincemil"; // or dr[0]="Shahnawaz";
            dr["Age"] = 29; // or dr[1]=24;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "Gonzalo"; // or dr[0]="Shahnawaz";
            dr["Age"] = 27; // or dr[1]=24;
            dt.Rows.Add(dr);

            dgvDatos.DataSource = dt;

            dgvDatos.FirstDisplayedScrollingRowIndex = 0;


        }
    }
}
