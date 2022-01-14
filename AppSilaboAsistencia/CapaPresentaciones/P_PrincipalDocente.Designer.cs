
namespace CapaPresentaciones
{
    partial class P_PrincipalDocente
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_PrincipalDocente));
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.pnContenedor = new Bunifu.UI.WinForms.BunifuPanel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnHorario = new System.Windows.Forms.FlowLayoutPanel();
            this.pnDias = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHoras = new System.Windows.Forms.FlowLayoutPanel();
            this.pnContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AllowParentOverrides = false;
            this.lblTitulo.AutoEllipsis = false;
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(1088, 46);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Mi Horario";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pnContenedor
            // 
            this.pnContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnContenedor.BackgroundColor = System.Drawing.Color.White;
            this.pnContenedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnContenedor.BackgroundImage")));
            this.pnContenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnContenedor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.pnContenedor.BorderRadius = 20;
            this.pnContenedor.BorderThickness = 1;
            this.pnContenedor.Controls.Add(this.pnHorario);
            this.pnContenedor.Controls.Add(this.pnDias);
            this.pnContenedor.Controls.Add(this.pnHoras);
            this.pnContenedor.Controls.Add(this.lblTitulo);
            this.pnContenedor.Location = new System.Drawing.Point(6, 5);
            this.pnContenedor.Name = "pnContenedor";
            this.pnContenedor.ShowBorders = true;
            this.pnContenedor.Size = new System.Drawing.Size(1088, 660);
            this.pnContenedor.TabIndex = 17;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this.pnContenedor;
            // 
            // pnHorario
            // 
            this.pnHorario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnHorario.Location = new System.Drawing.Point(226, 100);
            this.pnHorario.Name = "pnHorario";
            this.pnHorario.Size = new System.Drawing.Size(743, 464);
            this.pnHorario.TabIndex = 65;
            // 
            // pnDias
            // 
            this.pnDias.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnDias.Location = new System.Drawing.Point(226, 65);
            this.pnDias.Name = "pnDias";
            this.pnDias.Size = new System.Drawing.Size(743, 29);
            this.pnDias.TabIndex = 66;
            // 
            // pnHoras
            // 
            this.pnHoras.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnHoras.Location = new System.Drawing.Point(114, 100);
            this.pnHoras.Name = "pnHoras";
            this.pnHoras.Size = new System.Drawing.Size(106, 464);
            this.pnHoras.TabIndex = 67;
            // 
            // P_PrincipalDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 670);
            this.Controls.Add(this.pnContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_PrincipalDocente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla de Asignaturas";
            this.Load += new System.EventHandler(this.P_PrincipalDocente_Load);
            this.pnContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuPanel pnContenedor;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private System.Windows.Forms.FlowLayoutPanel pnHorario;
        private System.Windows.Forms.FlowLayoutPanel pnDias;
        private System.Windows.Forms.FlowLayoutPanel pnHoras;
    }
}