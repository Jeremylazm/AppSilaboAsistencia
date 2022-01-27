
namespace CapaPresentaciones
{
    partial class P_Bienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_Bienvenida));
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Docker = new Bunifu.UI.WinForms.BunifuFormDock();
            this.lblPie = new Bunifu.UI.WinForms.BunifuLabel();
            this.pbLogo = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblBienvenida = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblDatos = new Bunifu.UI.WinForms.BunifuLabel();
            this.pbProgreso = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.TiempoAparicion = new System.Windows.Forms.Timer(this.components);
            this.TiempoDesaparicion = new System.Windows.Forms.Timer(this.components);
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
            this.lblTitulo.Size = new System.Drawing.Size(1330, 46);
            this.lblTitulo.TabIndex = 21;
            this.lblTitulo.Text = "Sistema de Gestión de Sílabo y Control de Asistencia - Universidad Nacional de Sa" +
    "n Antonio Abad del Cusco";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this;
            // 
            // Docker
            // 
            this.Docker.AllowFormDragging = true;
            this.Docker.AllowFormDropShadow = true;
            this.Docker.AllowFormResizing = false;
            this.Docker.AllowHidingBottomRegion = true;
            this.Docker.AllowOpacityChangesWhileDragging = false;
            this.Docker.BorderOptions.BottomBorder.BorderColor = System.Drawing.Color.Silver;
            this.Docker.BorderOptions.BottomBorder.BorderThickness = 1;
            this.Docker.BorderOptions.BottomBorder.ShowBorder = true;
            this.Docker.BorderOptions.LeftBorder.BorderColor = System.Drawing.Color.Silver;
            this.Docker.BorderOptions.LeftBorder.BorderThickness = 1;
            this.Docker.BorderOptions.LeftBorder.ShowBorder = true;
            this.Docker.BorderOptions.RightBorder.BorderColor = System.Drawing.Color.Silver;
            this.Docker.BorderOptions.RightBorder.BorderThickness = 1;
            this.Docker.BorderOptions.RightBorder.ShowBorder = true;
            this.Docker.BorderOptions.TopBorder.BorderColor = System.Drawing.Color.Silver;
            this.Docker.BorderOptions.TopBorder.BorderThickness = 1;
            this.Docker.BorderOptions.TopBorder.ShowBorder = true;
            this.Docker.ContainerControl = this;
            this.Docker.DockingIndicatorsColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
            this.Docker.DockingIndicatorsOpacity = 0.5D;
            this.Docker.DockingOptions.DockAll = false;
            this.Docker.DockingOptions.DockBottomLeft = false;
            this.Docker.DockingOptions.DockBottomRight = false;
            this.Docker.DockingOptions.DockFullScreen = false;
            this.Docker.DockingOptions.DockLeft = false;
            this.Docker.DockingOptions.DockRight = false;
            this.Docker.DockingOptions.DockTopLeft = false;
            this.Docker.DockingOptions.DockTopRight = false;
            this.Docker.FormDraggingOpacity = 0.9D;
            this.Docker.ParentForm = this;
            this.Docker.ShowCursorChanges = true;
            this.Docker.ShowDockingIndicators = false;
            this.Docker.TitleBarOptions.AllowFormDragging = true;
            this.Docker.TitleBarOptions.BunifuFormDock = this.Docker;
            this.Docker.TitleBarOptions.DoubleClickToExpandWindow = true;
            this.Docker.TitleBarOptions.TitleBarControl = null;
            this.Docker.TitleBarOptions.UseBackColorOnDockingIndicators = false;
            // 
            // lblPie
            // 
            this.lblPie.AllowParentOverrides = false;
            this.lblPie.AutoEllipsis = false;
            this.lblPie.AutoSize = false;
            this.lblPie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblPie.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPie.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPie.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblPie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblPie.Location = new System.Drawing.Point(0, 680);
            this.lblPie.Name = "lblPie";
            this.lblPie.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPie.Size = new System.Drawing.Size(1330, 46);
            this.lblPie.TabIndex = 22;
            this.lblPie.Text = "Realizado por estudiantes de la Escuela Profesional de Ingeniería Informática y d" +
    "e Sistemas";
            this.lblPie.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPie.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pbLogo
            // 
            this.pbLogo.ActiveImage = null;
            this.pbLogo.AllowAnimations = true;
            this.pbLogo.AllowBuffering = false;
            this.pbLogo.AllowToggling = false;
            this.pbLogo.AllowZooming = false;
            this.pbLogo.AllowZoomingOnFocus = false;
            this.pbLogo.BackColor = System.Drawing.Color.White;
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbLogo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.pbLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.ErrorImage")));
            this.pbLogo.FadeWhenInactive = false;
            this.pbLogo.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.pbLogo.Image = global::CapaPresentaciones.Properties.Resources.Logo_UNSAAC3;
            this.pbLogo.ImageActive = null;
            this.pbLogo.ImageLocation = null;
            this.pbLogo.ImageMargin = 0;
            this.pbLogo.ImageSize = new System.Drawing.Size(438, 588);
            this.pbLogo.ImageZoomSize = new System.Drawing.Size(438, 588);
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(110, 68);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Rotation = 0;
            this.pbLogo.ShowActiveImage = false;
            this.pbLogo.ShowCursorChanges = false;
            this.pbLogo.ShowImageBorders = true;
            this.pbLogo.ShowSizeMarkers = false;
            this.pbLogo.Size = new System.Drawing.Size(438, 588);
            this.pbLogo.TabIndex = 23;
            this.pbLogo.ToolTipText = "";
            this.pbLogo.WaitOnLoad = false;
            this.pbLogo.Zoom = 0;
            this.pbLogo.ZoomSpeed = 10;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AllowParentOverrides = false;
            this.lblBienvenida.AutoEllipsis = false;
            this.lblBienvenida.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBienvenida.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblBienvenida.Font = new System.Drawing.Font("Montserrat Alternates", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblBienvenida.Location = new System.Drawing.Point(769, 82);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBienvenida.Size = new System.Drawing.Size(390, 78);
            this.lblBienvenida.TabIndex = 24;
            this.lblBienvenida.Text = "Bienvenid@";
            this.lblBienvenida.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBienvenida.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblBienvenida.Visible = false;
            // 
            // lblDatos
            // 
            this.lblDatos.AllowParentOverrides = false;
            this.lblDatos.AutoEllipsis = false;
            this.lblDatos.AutoSize = false;
            this.lblDatos.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDatos.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblDatos.Font = new System.Drawing.Font("Montserrat Alternates", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblDatos.Location = new System.Drawing.Point(754, 159);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDatos.Size = new System.Drawing.Size(405, 126);
            this.lblDatos.TabIndex = 25;
            this.lblDatos.Text = "DATOS";
            this.lblDatos.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDatos.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblDatos.Visible = false;
            // 
            // pbProgreso
            // 
            this.pbProgreso.Animated = true;
            this.pbProgreso.AnimationInterval = 5;
            this.pbProgreso.AnimationSpeed = 1;
            this.pbProgreso.BackColor = System.Drawing.Color.White;
            this.pbProgreso.CircleMargin = 10;
            this.pbProgreso.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbProgreso.ForeColor = System.Drawing.Color.White;
            this.pbProgreso.IsPercentage = false;
            this.pbProgreso.LineProgressThickness = 20;
            this.pbProgreso.LineThickness = 5;
            this.pbProgreso.Location = new System.Drawing.Point(803, 314);
            this.pbProgreso.Name = "pbProgreso";
            this.pbProgreso.ProgressAnimationSpeed = 200;
            this.pbProgreso.ProgressBackColor = System.Drawing.Color.White;
            this.pbProgreso.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.pbProgreso.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.pbProgreso.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.pbProgreso.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Gradient;
            this.pbProgreso.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.pbProgreso.SecondaryFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbProgreso.Size = new System.Drawing.Size(317, 317);
            this.pbProgreso.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pbProgreso.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.pbProgreso.SubScriptText = "";
            this.pbProgreso.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pbProgreso.SuperScriptMargin = new System.Windows.Forms.Padding(5, 20, 0, 0);
            this.pbProgreso.SuperScriptText = "";
            this.pbProgreso.TabIndex = 26;
            this.pbProgreso.Text = "30";
            this.pbProgreso.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pbProgreso.Value = 30;
            this.pbProgreso.ValueByTransition = 30;
            this.pbProgreso.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pbProgreso.Visible = false;
            // 
            // TiempoAparicion
            // 
            this.TiempoAparicion.Tick += new System.EventHandler(this.TiempoAparicion_Tick);
            // 
            // TiempoDesaparicion
            // 
            this.TiempoDesaparicion.Tick += new System.EventHandler(this.TiempoDesaparicion_Tick);
            // 
            // P_Bienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1330, 726);
            this.Controls.Add(this.pbProgreso);
            this.Controls.Add(this.lblDatos);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblPie);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_Bienvenida";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenid@";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.UI.WinForms.BunifuFormDock Docker;
        private Bunifu.UI.WinForms.BunifuLabel lblPie;
        private Bunifu.UI.WinForms.BunifuImageButton pbLogo;
        private Bunifu.UI.WinForms.BunifuLabel lblDatos;
        private Bunifu.UI.WinForms.BunifuLabel lblBienvenida;
        private Bunifu.UI.WinForms.BunifuCircleProgress pbProgreso;
        private System.Windows.Forms.Timer TiempoAparicion;
        private System.Windows.Forms.Timer TiempoDesaparicion;
    }
}