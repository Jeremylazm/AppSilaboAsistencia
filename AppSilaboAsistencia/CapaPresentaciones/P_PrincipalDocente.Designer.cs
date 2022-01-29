
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
            this.btnMostrarPlanSesiones = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lnAsignatura = new Bunifu.UI.WinForms.BunifuSeparator();
            this.txtAsignatura = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblAsignatura = new Bunifu.UI.WinForms.BunifuLabel();
            this.pnHorario = new System.Windows.Forms.FlowLayoutPanel();
            this.pnDias = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHoras = new System.Windows.Forms.FlowLayoutPanel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
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
            this.pnContenedor.Controls.Add(this.btnMostrarPlanSesiones);
            this.pnContenedor.Controls.Add(this.lnAsignatura);
            this.pnContenedor.Controls.Add(this.txtAsignatura);
            this.pnContenedor.Controls.Add(this.lblAsignatura);
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
            // btnMostrarPlanSesiones
            // 
            this.btnMostrarPlanSesiones.ActiveImage = null;
            this.btnMostrarPlanSesiones.AllowAnimations = true;
            this.btnMostrarPlanSesiones.AllowBuffering = false;
            this.btnMostrarPlanSesiones.AllowToggling = false;
            this.btnMostrarPlanSesiones.AllowZooming = true;
            this.btnMostrarPlanSesiones.AllowZoomingOnFocus = false;
            this.btnMostrarPlanSesiones.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMostrarPlanSesiones.BackColor = System.Drawing.Color.White;
            this.btnMostrarPlanSesiones.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMostrarPlanSesiones.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarPlanSesiones.ErrorImage")));
            this.btnMostrarPlanSesiones.FadeWhenInactive = false;
            this.btnMostrarPlanSesiones.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnMostrarPlanSesiones.Image = global::CapaPresentaciones.Properties.Resources.Mostrar;
            this.btnMostrarPlanSesiones.ImageActive = null;
            this.btnMostrarPlanSesiones.ImageLocation = null;
            this.btnMostrarPlanSesiones.ImageMargin = 10;
            this.btnMostrarPlanSesiones.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMostrarPlanSesiones.ImageZoomSize = new System.Drawing.Size(30, 30);
            this.btnMostrarPlanSesiones.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarPlanSesiones.InitialImage")));
            this.btnMostrarPlanSesiones.Location = new System.Drawing.Point(995, 607);
            this.btnMostrarPlanSesiones.Name = "btnMostrarPlanSesiones";
            this.btnMostrarPlanSesiones.Rotation = 0;
            this.btnMostrarPlanSesiones.ShowActiveImage = true;
            this.btnMostrarPlanSesiones.ShowCursorChanges = true;
            this.btnMostrarPlanSesiones.ShowImageBorders = true;
            this.btnMostrarPlanSesiones.ShowSizeMarkers = false;
            this.btnMostrarPlanSesiones.Size = new System.Drawing.Size(30, 30);
            this.btnMostrarPlanSesiones.TabIndex = 81;
            this.btnMostrarPlanSesiones.ToolTipText = "";
            this.btnMostrarPlanSesiones.WaitOnLoad = false;
            this.btnMostrarPlanSesiones.Zoom = 10;
            this.btnMostrarPlanSesiones.ZoomSpeed = 10;
            this.btnMostrarPlanSesiones.Click += new System.EventHandler(this.btnMostrarPlanSesiones_Click);
            // 
            // lnAsignatura
            // 
            this.lnAsignatura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnAsignatura.BackColor = System.Drawing.Color.Transparent;
            this.lnAsignatura.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lnAsignatura.BackgroundImage")));
            this.lnAsignatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lnAsignatura.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.lnAsignatura.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lnAsignatura.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.lnAsignatura.LineThickness = 1;
            this.lnAsignatura.Location = new System.Drawing.Point(294, 634);
            this.lnAsignatura.Name = "lnAsignatura";
            this.lnAsignatura.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.lnAsignatura.Size = new System.Drawing.Size(164, 10);
            this.lnAsignatura.TabIndex = 79;
            // 
            // txtAsignatura
            // 
            this.txtAsignatura.AllowParentOverrides = false;
            this.txtAsignatura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAsignatura.AutoEllipsis = false;
            this.txtAsignatura.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtAsignatura.CursorType = System.Windows.Forms.Cursors.Default;
            this.txtAsignatura.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsignatura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtAsignatura.Location = new System.Drawing.Point(294, 610);
            this.txtAsignatura.Name = "txtAsignatura";
            this.txtAsignatura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAsignatura.Size = new System.Drawing.Size(164, 22);
            this.txtAsignatura.TabIndex = 80;
            this.txtAsignatura.Text = "Valor de Asignatura";
            this.txtAsignatura.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtAsignatura.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AllowParentOverrides = false;
            this.lblAsignatura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAsignatura.AutoEllipsis = false;
            this.lblAsignatura.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAsignatura.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblAsignatura.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignatura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblAsignatura.Location = new System.Drawing.Point(101, 610);
            this.lblAsignatura.Name = "lblAsignatura";
            this.lblAsignatura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAsignatura.Size = new System.Drawing.Size(180, 23);
            this.lblAsignatura.TabIndex = 68;
            this.lblAsignatura.Text = "Asignatura en Curso:";
            this.lblAsignatura.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAsignatura.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pnHorario
            // 
            this.pnHorario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnHorario.Location = new System.Drawing.Point(218, 101);
            this.pnHorario.Name = "pnHorario";
            this.pnHorario.Size = new System.Drawing.Size(726, 434);
            this.pnHorario.TabIndex = 65;
            // 
            // pnDias
            // 
            this.pnDias.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnDias.Location = new System.Drawing.Point(218, 64);
            this.pnDias.Name = "pnDias";
            this.pnDias.Size = new System.Drawing.Size(726, 31);
            this.pnDias.TabIndex = 66;
            // 
            // pnHoras
            // 
            this.pnHoras.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnHoras.Location = new System.Drawing.Point(91, 101);
            this.pnHoras.Name = "pnHoras";
            this.pnHoras.Size = new System.Drawing.Size(121, 434);
            this.pnHoras.TabIndex = 67;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this.pnContenedor;
            // 
            // HoraFecha
            // 
            this.HoraFecha.Tick += new System.EventHandler(this.HoraFecha_Tick);
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
            this.pnContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuPanel pnContenedor;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private System.Windows.Forms.FlowLayoutPanel pnHorario;
        private System.Windows.Forms.FlowLayoutPanel pnDias;
        private System.Windows.Forms.FlowLayoutPanel pnHoras;
        private Bunifu.UI.WinForms.BunifuLabel lblAsignatura;
        private Bunifu.UI.WinForms.BunifuSeparator lnAsignatura;
        public Bunifu.UI.WinForms.BunifuLabel txtAsignatura;
        public System.Windows.Forms.Timer HoraFecha;
        private Bunifu.UI.WinForms.BunifuImageButton btnMostrarPlanSesiones;
    }
}