
namespace CapaPresentaciones
{
    partial class P_TablaSemestre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_TablaSemestre));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.pnContenedor = new Bunifu.UI.WinForms.BunifuPanel();
            this.txtSemestreActivo = new Bunifu.UI.WinForms.BunifuLabel();
            this.lnSemestre = new Bunifu.UI.WinForms.BunifuSeparator();
            this.btnEditar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.lblSemestre = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnAgregar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.sbDatos = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.dgvDatos = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
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
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(1055, 57);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Tabla de Semestres";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ActiveImage = null;
            this.btnCerrar.AllowAnimations = true;
            this.btnCerrar.AllowBuffering = false;
            this.btnCerrar.AllowToggling = false;
            this.btnCerrar.AllowZooming = true;
            this.btnCerrar.AllowZoomingOnFocus = false;
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCerrar.ErrorImage = null;
            this.btnCerrar.FadeWhenInactive = false;
            this.btnCerrar.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnCerrar.Image = global::CapaPresentaciones.Properties.Resources.Cerrar;
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.ImageLocation = null;
            this.btnCerrar.ImageMargin = 10;
            this.btnCerrar.ImageSize = new System.Drawing.Size(30, 27);
            this.btnCerrar.ImageZoomSize = new System.Drawing.Size(40, 37);
            this.btnCerrar.InitialImage = null;
            this.btnCerrar.Location = new System.Drawing.Point(1004, 9);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0;
            this.btnCerrar.ShowActiveImage = true;
            this.btnCerrar.ShowCursorChanges = true;
            this.btnCerrar.ShowImageBorders = true;
            this.btnCerrar.ShowSizeMarkers = false;
            this.btnCerrar.Size = new System.Drawing.Size(40, 37);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.ToolTipText = "";
            this.btnCerrar.WaitOnLoad = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.ZoomSpeed = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
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
            this.pnContenedor.Controls.Add(this.txtSemestreActivo);
            this.pnContenedor.Controls.Add(this.lnSemestre);
            this.pnContenedor.Controls.Add(this.btnEditar);
            this.pnContenedor.Controls.Add(this.lblSemestre);
            this.pnContenedor.Controls.Add(this.btnAgregar);
            this.pnContenedor.Controls.Add(this.sbDatos);
            this.pnContenedor.Controls.Add(this.dgvDatos);
            this.pnContenedor.Controls.Add(this.btnCerrar);
            this.pnContenedor.Controls.Add(this.lblTitulo);
            this.pnContenedor.Location = new System.Drawing.Point(8, 6);
            this.pnContenedor.Margin = new System.Windows.Forms.Padding(4);
            this.pnContenedor.Name = "pnContenedor";
            this.pnContenedor.ShowBorders = true;
            this.pnContenedor.Size = new System.Drawing.Size(1055, 558);
            this.pnContenedor.TabIndex = 17;
            // 
            // txtSemestreActivo
            // 
            this.txtSemestreActivo.AllowParentOverrides = false;
            this.txtSemestreActivo.AutoEllipsis = false;
            this.txtSemestreActivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSemestreActivo.CursorType = System.Windows.Forms.Cursors.Default;
            this.txtSemestreActivo.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSemestreActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtSemestreActivo.Location = new System.Drawing.Point(308, 505);
            this.txtSemestreActivo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSemestreActivo.Name = "txtSemestreActivo";
            this.txtSemestreActivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSemestreActivo.Size = new System.Drawing.Size(86, 27);
            this.txtSemestreActivo.TabIndex = 71;
            this.txtSemestreActivo.Text = "2088 - II";
            this.txtSemestreActivo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtSemestreActivo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lnSemestre
            // 
            this.lnSemestre.BackColor = System.Drawing.Color.Transparent;
            this.lnSemestre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lnSemestre.BackgroundImage")));
            this.lnSemestre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lnSemestre.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.lnSemestre.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lnSemestre.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.lnSemestre.LineThickness = 1;
            this.lnSemestre.Location = new System.Drawing.Point(308, 534);
            this.lnSemestre.Margin = new System.Windows.Forms.Padding(5);
            this.lnSemestre.Name = "lnSemestre";
            this.lnSemestre.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.lnSemestre.Size = new System.Drawing.Size(91, 12);
            this.lnSemestre.TabIndex = 70;
            // 
            // btnEditar
            // 
            this.btnEditar.AllowAnimations = true;
            this.btnEditar.AllowMouseEffects = true;
            this.btnEditar.AllowToggling = false;
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.AnimationSpeed = 200;
            this.btnEditar.AutoGenerateColors = false;
            this.btnEditar.AutoRoundBorders = false;
            this.btnEditar.AutoSizeLeftIcon = true;
            this.btnEditar.AutoSizeRightIcon = true;
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditar.BackgroundImage")));
            this.btnEditar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.ButtonText = "Editar";
            this.btnEditar.ButtonTextMarginLeft = 0;
            this.btnEditar.ColorContrastOnClick = 45;
            this.btnEditar.ColorContrastOnHover = 45;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnEditar.CustomizableEdges = borderEdges3;
            this.btnEditar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEditar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEditar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEditar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEditar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnEditar.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnEditar.IconMarginLeft = 11;
            this.btnEditar.IconPadding = 10;
            this.btnEditar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnEditar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnEditar.IconSize = 25;
            this.btnEditar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditar.IdleBorderRadius = 15;
            this.btnEditar.IdleBorderThickness = 1;
            this.btnEditar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Editar;
            this.btnEditar.IdleIconRightImage = null;
            this.btnEditar.IndicateFocus = false;
            this.btnEditar.Location = new System.Drawing.Point(437, 497);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnEditar.OnDisabledState.BorderRadius = 15;
            this.btnEditar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.OnDisabledState.BorderThickness = 1;
            this.btnEditar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnEditar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnEditar.OnDisabledState.IconLeftImage = null;
            this.btnEditar.OnDisabledState.IconRightImage = null;
            this.btnEditar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditar.onHoverState.BorderRadius = 15;
            this.btnEditar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.onHoverState.BorderThickness = 1;
            this.btnEditar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditar.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar_2;
            this.btnEditar.onHoverState.IconRightImage = null;
            this.btnEditar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditar.OnIdleState.BorderRadius = 15;
            this.btnEditar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.OnIdleState.BorderThickness = 1;
            this.btnEditar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Editar;
            this.btnEditar.OnIdleState.IconRightImage = null;
            this.btnEditar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditar.OnPressedState.BorderRadius = 15;
            this.btnEditar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnEditar.OnPressedState.BorderThickness = 1;
            this.btnEditar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnEditar.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnEditar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar;
            this.btnEditar.OnPressedState.IconRightImage = null;
            this.btnEditar.Size = new System.Drawing.Size(227, 48);
            this.btnEditar.TabIndex = 35;
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEditar.TextMarginLeft = 0;
            this.btnEditar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnEditar.UseDefaultRadiusAndThickness = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblSemestre
            // 
            this.lblSemestre.AllowParentOverrides = false;
            this.lblSemestre.AutoEllipsis = false;
            this.lblSemestre.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSemestre.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblSemestre.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemestre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblSemestre.Location = new System.Drawing.Point(112, 503);
            this.lblSemestre.Margin = new System.Windows.Forms.Padding(4);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSemestre.Size = new System.Drawing.Size(168, 27);
            this.lblSemestre.TabIndex = 34;
            this.lblSemestre.Text = "Semestre Activo: ";
            this.lblSemestre.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSemestre.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AllowAnimations = true;
            this.btnAgregar.AllowMouseEffects = true;
            this.btnAgregar.AllowToggling = false;
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.AnimationSpeed = 200;
            this.btnAgregar.AutoGenerateColors = false;
            this.btnAgregar.AutoRoundBorders = false;
            this.btnAgregar.AutoSizeLeftIcon = true;
            this.btnAgregar.AutoSizeRightIcon = true;
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.ButtonText = "Agregar";
            this.btnAgregar.ButtonTextMarginLeft = 0;
            this.btnAgregar.ColorContrastOnClick = 45;
            this.btnAgregar.ColorContrastOnHover = 45;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnAgregar.CustomizableEdges = borderEdges4;
            this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAgregar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAgregar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAgregar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAgregar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAgregar.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAgregar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAgregar.IconMarginLeft = 11;
            this.btnAgregar.IconPadding = 10;
            this.btnAgregar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAgregar.IconSize = 25;
            this.btnAgregar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAgregar.IdleBorderRadius = 15;
            this.btnAgregar.IdleBorderThickness = 1;
            this.btnAgregar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAgregar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar;
            this.btnAgregar.IdleIconRightImage = null;
            this.btnAgregar.IndicateFocus = false;
            this.btnAgregar.Location = new System.Drawing.Point(696, 497);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAgregar.OnDisabledState.BorderRadius = 15;
            this.btnAgregar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.OnDisabledState.BorderThickness = 1;
            this.btnAgregar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAgregar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAgregar.OnDisabledState.IconLeftImage = null;
            this.btnAgregar.OnDisabledState.IconRightImage = null;
            this.btnAgregar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAgregar.onHoverState.BorderRadius = 15;
            this.btnAgregar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.onHoverState.BorderThickness = 1;
            this.btnAgregar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAgregar.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAgregar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar_2;
            this.btnAgregar.onHoverState.IconRightImage = null;
            this.btnAgregar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAgregar.OnIdleState.BorderRadius = 15;
            this.btnAgregar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.OnIdleState.BorderThickness = 1;
            this.btnAgregar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAgregar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAgregar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar;
            this.btnAgregar.OnIdleState.IconRightImage = null;
            this.btnAgregar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAgregar.OnPressedState.BorderRadius = 15;
            this.btnAgregar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAgregar.OnPressedState.BorderThickness = 1;
            this.btnAgregar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAgregar.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAgregar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar;
            this.btnAgregar.OnPressedState.IconRightImage = null;
            this.btnAgregar.Size = new System.Drawing.Size(227, 48);
            this.btnAgregar.TabIndex = 33;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAgregar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAgregar.TextMarginLeft = 0;
            this.btnAgregar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnAgregar.UseDefaultRadiusAndThickness = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // sbDatos
            // 
            this.sbDatos.AllowCursorChanges = true;
            this.sbDatos.AllowHomeEndKeysDetection = false;
            this.sbDatos.AllowIncrementalClickMoves = true;
            this.sbDatos.AllowMouseDownEffects = true;
            this.sbDatos.AllowMouseHoverEffects = true;
            this.sbDatos.AllowScrollingAnimations = true;
            this.sbDatos.AllowScrollKeysDetection = true;
            this.sbDatos.AllowScrollOptionsMenu = true;
            this.sbDatos.AllowShrinkingOnFocusLost = false;
            this.sbDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.sbDatos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbDatos.BackgroundImage")));
            this.sbDatos.BindingContainer = null;
            this.sbDatos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.sbDatos.BorderRadius = 0;
            this.sbDatos.BorderThickness = 1;
            this.sbDatos.DurationBeforeShrink = 2000;
            this.sbDatos.LargeChange = 10;
            this.sbDatos.Location = new System.Drawing.Point(1031, 96);
            this.sbDatos.Margin = new System.Windows.Forms.Padding(5);
            this.sbDatos.Maximum = 100;
            this.sbDatos.Minimum = 0;
            this.sbDatos.MinimumThumbLength = 18;
            this.sbDatos.Name = "sbDatos";
            this.sbDatos.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.sbDatos.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.sbDatos.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.sbDatos.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.sbDatos.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.sbDatos.ShrinkSizeLimit = 3;
            this.sbDatos.Size = new System.Drawing.Size(13, 394);
            this.sbDatos.SmallChange = 1;
            this.sbDatos.TabIndex = 31;
            this.sbDatos.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.sbDatos.ThumbLength = 38;
            this.sbDatos.ThumbMargin = 1;
            this.sbDatos.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.sbDatos.Value = 0;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowCustomTheming = true;
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToOrderColumns = true;
            this.dgvDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatos.ColumnHeadersHeight = 28;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatos.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.dgvDatos.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvDatos.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dgvDatos.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvDatos.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.CurrentTheme.Name = null;
            this.dgvDatos.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dgvDatos.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.dgvDatos.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvDatos.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dgvDatos.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvDatos.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvDatos.Location = new System.Drawing.Point(13, 64);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 28;
            this.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDatos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.RowTemplate.Height = 26;
            this.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1031, 426);
            this.dgvDatos.TabIndex = 32;
            this.dgvDatos.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Maroon;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this.pnContenedor;
            // 
            // P_TablaSemestre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1071, 570);
            this.Controls.Add(this.pnContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "P_TablaSemestre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla de Asignaturas Asignadas - Asistencias";
            this.Load += new System.EventHandler(this.P_TablaSemestre_Load);
            this.pnContenedor.ResumeLayout(false);
            this.pnContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuPanel pnContenedor;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.UI.WinForms.BunifuVScrollBar sbDatos;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvDatos;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAgregar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnEditar;
        private Bunifu.UI.WinForms.BunifuLabel lblSemestre;
        public Bunifu.UI.WinForms.BunifuLabel txtSemestreActivo;
        private Bunifu.UI.WinForms.BunifuSeparator lnSemestre;
    }
}