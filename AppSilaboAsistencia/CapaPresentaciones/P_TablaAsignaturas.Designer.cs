
namespace CapaPresentaciones
{
	partial class P_TablaAsignaturas
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgvMostrarAsignatura = new System.Windows.Forms.DataGridView();
			this.ELIMINAR = new System.Windows.Forms.DataGridViewButtonColumn();
			this.EDITAR = new System.Windows.Forms.DataGridViewButtonColumn();
			this.lbBuscar = new System.Windows.Forms.Label();
			this.tbxBuscar = new System.Windows.Forms.TextBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMostrarAsignatura)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Maroon;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(909, 100);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(24, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Asignaturas";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.dgvMostrarAsignatura);
			this.panel2.Controls.Add(this.lbBuscar);
			this.panel2.Controls.Add(this.tbxBuscar);
			this.panel2.Controls.Add(this.btnAgregar);
			this.panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel2.Location = new System.Drawing.Point(43, 142);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(824, 343);
			this.panel2.TabIndex = 0;
			this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			// 
			// dgvMostrarAsignatura
			// 
			this.dgvMostrarAsignatura.AllowUserToAddRows = false;
			this.dgvMostrarAsignatura.AllowUserToDeleteRows = false;
			this.dgvMostrarAsignatura.AllowUserToResizeColumns = false;
			this.dgvMostrarAsignatura.AllowUserToResizeRows = false;
			this.dgvMostrarAsignatura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvMostrarAsignatura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvMostrarAsignatura.BackgroundColor = System.Drawing.Color.White;
			this.dgvMostrarAsignatura.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvMostrarAsignatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMostrarAsignatura.ColumnHeadersVisible = false;
			this.dgvMostrarAsignatura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ELIMINAR,
            this.EDITAR});
			this.dgvMostrarAsignatura.GridColor = System.Drawing.Color.White;
			this.dgvMostrarAsignatura.Location = new System.Drawing.Point(25, 76);
			this.dgvMostrarAsignatura.MultiSelect = false;
			this.dgvMostrarAsignatura.Name = "dgvMostrarAsignatura";
			this.dgvMostrarAsignatura.ReadOnly = true;
			this.dgvMostrarAsignatura.RowHeadersVisible = false;
			this.dgvMostrarAsignatura.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvMostrarAsignatura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvMostrarAsignatura.ShowEditingIcon = false;
			this.dgvMostrarAsignatura.Size = new System.Drawing.Size(752, 246);
			this.dgvMostrarAsignatura.TabIndex = 0;
			this.dgvMostrarAsignatura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMostrarAsignatura_CellClick);
			this.dgvMostrarAsignatura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMostrarAsignatura_CellContentClick);
			// 
			// ELIMINAR
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			this.ELIMINAR.DefaultCellStyle = dataGridViewCellStyle1;
			this.ELIMINAR.HeaderText = "Eliminar";
			this.ELIMINAR.Name = "ELIMINAR";
			this.ELIMINAR.ReadOnly = true;
			this.ELIMINAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ELIMINAR.Text = "Eliminar";
			// 
			// EDITAR
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
			this.EDITAR.DefaultCellStyle = dataGridViewCellStyle2;
			this.EDITAR.HeaderText = "Editar";
			this.EDITAR.Name = "EDITAR";
			this.EDITAR.ReadOnly = true;
			this.EDITAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.EDITAR.Text = "Editar";
			// 
			// lbBuscar
			// 
			this.lbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbBuscar.AutoSize = true;
			this.lbBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lbBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbBuscar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbBuscar.Location = new System.Drawing.Point(729, 30);
			this.lbBuscar.Name = "lbBuscar";
			this.lbBuscar.Size = new System.Drawing.Size(48, 19);
			this.lbBuscar.TabIndex = 2;
			this.lbBuscar.Text = "Buscar";
			// 
			// tbxBuscar
			// 
			this.tbxBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbxBuscar.Location = new System.Drawing.Point(533, 29);
			this.tbxBuscar.Name = "tbxBuscar";
			this.tbxBuscar.Size = new System.Drawing.Size(190, 20);
			this.tbxBuscar.TabIndex = 1;
			this.tbxBuscar.TextChanged += new System.EventHandler(this.tbxBuscar_TextChanged);
			// 
			// btnAgregar
			// 
			this.btnAgregar.BackColor = System.Drawing.Color.Maroon;
			this.btnAgregar.FlatAppearance.BorderSize = 0;
			this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAgregar.Location = new System.Drawing.Point(25, 16);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(81, 33);
			this.btnAgregar.TabIndex = 0;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// P_TablaAsignaturas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(909, 512);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "P_TablaAsignaturas";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CrudAsignatura";
			this.Load += new System.EventHandler(this.P_TablaAsigaturas_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMostrarAsignatura)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox tbxBuscar;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Label lbBuscar;
		private System.Windows.Forms.DataGridView dgvMostrarAsignatura;
		private System.Windows.Forms.DataGridViewButtonColumn ELIMINAR;
		private System.Windows.Forms.DataGridViewButtonColumn EDITAR;
	}
}