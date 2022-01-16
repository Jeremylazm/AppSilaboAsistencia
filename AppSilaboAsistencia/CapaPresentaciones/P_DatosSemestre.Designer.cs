
namespace CapaPresentaciones
{
    partial class P_DatosSemestre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_DatosSemestre));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties11 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties12 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.pnDatos = new Bunifu.UI.WinForms.BunifuPanel();
            this.lblErrorTelefono = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnLimpiar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnGuardar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.txtDenominacionSemestre = new Bunifu.UI.WinForms.BunifuTextBox();
            this.lblAPaterno = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.dpFechaInicialSemestre = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.pnDatos.SuspendLayout();
            this.SuspendLayout();
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
            this.btnCerrar.Location = new System.Drawing.Point(591, 13);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0;
            this.btnCerrar.ShowActiveImage = true;
            this.btnCerrar.ShowCursorChanges = true;
            this.btnCerrar.ShowImageBorders = true;
            this.btnCerrar.ShowSizeMarkers = false;
            this.btnCerrar.Size = new System.Drawing.Size(40, 37);
            this.btnCerrar.TabIndex = 89;
            this.btnCerrar.ToolTipText = "";
            this.btnCerrar.WaitOnLoad = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.ZoomSpeed = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
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
            this.lblTitulo.Size = new System.Drawing.Size(644, 57);
            this.lblTitulo.TabIndex = 88;
            this.lblTitulo.Text = "Semestre";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pnDatos
            // 
            this.pnDatos.BackgroundColor = System.Drawing.Color.Transparent;
            this.pnDatos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnDatos.BackgroundImage")));
            this.pnDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnDatos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.pnDatos.BorderRadius = 20;
            this.pnDatos.BorderThickness = 1;
            this.pnDatos.Controls.Add(this.dpFechaInicialSemestre);
            this.pnDatos.Controls.Add(this.bunifuLabel1);
            this.pnDatos.Controls.Add(this.lblAPaterno);
            this.pnDatos.Controls.Add(this.txtDenominacionSemestre);
            this.pnDatos.Controls.Add(this.lblErrorTelefono);
            this.pnDatos.Location = new System.Drawing.Point(47, 86);
            this.pnDatos.Margin = new System.Windows.Forms.Padding(4);
            this.pnDatos.Name = "pnDatos";
            this.pnDatos.ShowBorders = true;
            this.pnDatos.Size = new System.Drawing.Size(567, 241);
            this.pnDatos.TabIndex = 90;
            // 
            // lblErrorTelefono
            // 
            this.lblErrorTelefono.AllowParentOverrides = false;
            this.lblErrorTelefono.AutoEllipsis = false;
            this.lblErrorTelefono.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblErrorTelefono.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblErrorTelefono.Font = new System.Drawing.Font("Montserrat Alternates", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblErrorTelefono.Location = new System.Drawing.Point(347, 332);
            this.lblErrorTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblErrorTelefono.Size = new System.Drawing.Size(0, 0);
            this.lblErrorTelefono.TabIndex = 82;
            this.lblErrorTelefono.Text = "Error de Teléfono";
            this.lblErrorTelefono.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErrorTelefono.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblErrorTelefono.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AllowAnimations = true;
            this.btnLimpiar.AllowMouseEffects = true;
            this.btnLimpiar.AllowToggling = false;
            this.btnLimpiar.AnimationSpeed = 200;
            this.btnLimpiar.AutoGenerateColors = false;
            this.btnLimpiar.AutoRoundBorders = false;
            this.btnLimpiar.AutoSizeLeftIcon = true;
            this.btnLimpiar.AutoSizeRightIcon = true;
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLimpiar.ButtonText = "Limpiar";
            this.btnLimpiar.ButtonTextMarginLeft = 0;
            this.btnLimpiar.ColorContrastOnClick = 45;
            this.btnLimpiar.ColorContrastOnHover = 45;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.btnLimpiar.CustomizableEdges = borderEdges5;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLimpiar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLimpiar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLimpiar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLimpiar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnLimpiar.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnLimpiar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLimpiar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLimpiar.IconMarginLeft = 11;
            this.btnLimpiar.IconPadding = 10;
            this.btnLimpiar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLimpiar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLimpiar.IconSize = 25;
            this.btnLimpiar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnLimpiar.IdleBorderRadius = 15;
            this.btnLimpiar.IdleBorderThickness = 1;
            this.btnLimpiar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnLimpiar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Limpiar;
            this.btnLimpiar.IdleIconRightImage = null;
            this.btnLimpiar.IndicateFocus = false;
            this.btnLimpiar.Location = new System.Drawing.Point(352, 370);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLimpiar.OnDisabledState.BorderRadius = 15;
            this.btnLimpiar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLimpiar.OnDisabledState.BorderThickness = 1;
            this.btnLimpiar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLimpiar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLimpiar.OnDisabledState.IconLeftImage = null;
            this.btnLimpiar.OnDisabledState.IconRightImage = null;
            this.btnLimpiar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnLimpiar.onHoverState.BorderRadius = 15;
            this.btnLimpiar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLimpiar.onHoverState.BorderThickness = 1;
            this.btnLimpiar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnLimpiar.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnLimpiar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Limpiar_2;
            this.btnLimpiar.onHoverState.IconRightImage = null;
            this.btnLimpiar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnLimpiar.OnIdleState.BorderRadius = 15;
            this.btnLimpiar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLimpiar.OnIdleState.BorderThickness = 1;
            this.btnLimpiar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnLimpiar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnLimpiar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Limpiar;
            this.btnLimpiar.OnIdleState.IconRightImage = null;
            this.btnLimpiar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnLimpiar.OnPressedState.BorderRadius = 15;
            this.btnLimpiar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnLimpiar.OnPressedState.BorderThickness = 1;
            this.btnLimpiar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnLimpiar.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnLimpiar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Limpiar;
            this.btnLimpiar.OnPressedState.IconRightImage = null;
            this.btnLimpiar.Size = new System.Drawing.Size(227, 48);
            this.btnLimpiar.TabIndex = 92;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLimpiar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLimpiar.TextMarginLeft = 0;
            this.btnLimpiar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLimpiar.UseDefaultRadiusAndThickness = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AllowAnimations = true;
            this.btnGuardar.AllowMouseEffects = true;
            this.btnGuardar.AllowToggling = false;
            this.btnGuardar.AnimationSpeed = 200;
            this.btnGuardar.AutoGenerateColors = false;
            this.btnGuardar.AutoRoundBorders = false;
            this.btnGuardar.AutoSizeLeftIcon = true;
            this.btnGuardar.AutoSizeRightIcon = true;
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.BackgroundImage")));
            this.btnGuardar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGuardar.ButtonText = "Guardar";
            this.btnGuardar.ButtonTextMarginLeft = 0;
            this.btnGuardar.ColorContrastOnClick = 45;
            this.btnGuardar.ColorContrastOnHover = 45;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.btnGuardar.CustomizableEdges = borderEdges6;
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGuardar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGuardar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGuardar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGuardar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnGuardar.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnGuardar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnGuardar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnGuardar.IconMarginLeft = 11;
            this.btnGuardar.IconPadding = 10;
            this.btnGuardar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnGuardar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnGuardar.IconSize = 25;
            this.btnGuardar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnGuardar.IdleBorderRadius = 15;
            this.btnGuardar.IdleBorderThickness = 1;
            this.btnGuardar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnGuardar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Guardar;
            this.btnGuardar.IdleIconRightImage = null;
            this.btnGuardar.IndicateFocus = false;
            this.btnGuardar.Location = new System.Drawing.Point(67, 370);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnGuardar.OnDisabledState.BorderRadius = 15;
            this.btnGuardar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGuardar.OnDisabledState.BorderThickness = 1;
            this.btnGuardar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnGuardar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnGuardar.OnDisabledState.IconLeftImage = null;
            this.btnGuardar.OnDisabledState.IconRightImage = null;
            this.btnGuardar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnGuardar.onHoverState.BorderRadius = 15;
            this.btnGuardar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGuardar.onHoverState.BorderThickness = 1;
            this.btnGuardar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnGuardar.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnGuardar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Guardar_2;
            this.btnGuardar.onHoverState.IconRightImage = null;
            this.btnGuardar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnGuardar.OnIdleState.BorderRadius = 15;
            this.btnGuardar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGuardar.OnIdleState.BorderThickness = 1;
            this.btnGuardar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnGuardar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnGuardar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Guardar;
            this.btnGuardar.OnIdleState.IconRightImage = null;
            this.btnGuardar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnGuardar.OnPressedState.BorderRadius = 15;
            this.btnGuardar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnGuardar.OnPressedState.BorderThickness = 1;
            this.btnGuardar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnGuardar.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnGuardar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Guardar;
            this.btnGuardar.OnPressedState.IconRightImage = null;
            this.btnGuardar.Size = new System.Drawing.Size(227, 48);
            this.btnGuardar.TabIndex = 91;
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuardar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnGuardar.TextMarginLeft = 0;
            this.btnGuardar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnGuardar.UseDefaultRadiusAndThickness = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDenominacionSemestre
            // 
            this.txtDenominacionSemestre.AcceptsReturn = false;
            this.txtDenominacionSemestre.AcceptsTab = false;
            this.txtDenominacionSemestre.AnimationSpeed = 200;
            this.txtDenominacionSemestre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDenominacionSemestre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDenominacionSemestre.AutoSizeHeight = true;
            this.txtDenominacionSemestre.BackColor = System.Drawing.Color.White;
            this.txtDenominacionSemestre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtDenominacionSemestre.BackgroundImage")));
            this.txtDenominacionSemestre.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtDenominacionSemestre.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtDenominacionSemestre.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtDenominacionSemestre.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtDenominacionSemestre.BorderRadius = 1;
            this.txtDenominacionSemestre.BorderThickness = 1;
            this.txtDenominacionSemestre.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDenominacionSemestre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDenominacionSemestre.DefaultFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDenominacionSemestre.DefaultText = "";
            this.txtDenominacionSemestre.FillColor = System.Drawing.Color.White;
            this.txtDenominacionSemestre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtDenominacionSemestre.HideSelection = true;
            this.txtDenominacionSemestre.IconLeft = null;
            this.txtDenominacionSemestre.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDenominacionSemestre.IconPadding = 0;
            this.txtDenominacionSemestre.IconRight = null;
            this.txtDenominacionSemestre.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDenominacionSemestre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDenominacionSemestre.Lines = new string[0];
            this.txtDenominacionSemestre.Location = new System.Drawing.Point(22, 55);
            this.txtDenominacionSemestre.Margin = new System.Windows.Forms.Padding(0);
            this.txtDenominacionSemestre.MaxLength = 32767;
            this.txtDenominacionSemestre.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDenominacionSemestre.Modified = false;
            this.txtDenominacionSemestre.Multiline = false;
            this.txtDenominacionSemestre.Name = "txtDenominacionSemestre";
            stateProperties9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties9.FillColor = System.Drawing.Color.Empty;
            stateProperties9.ForeColor = System.Drawing.Color.Empty;
            stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDenominacionSemestre.OnActiveState = stateProperties9;
            stateProperties10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtDenominacionSemestre.OnDisabledState = stateProperties10;
            stateProperties11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties11.FillColor = System.Drawing.Color.Empty;
            stateProperties11.ForeColor = System.Drawing.Color.Empty;
            stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDenominacionSemestre.OnHoverState = stateProperties11;
            stateProperties12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties12.FillColor = System.Drawing.Color.White;
            stateProperties12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDenominacionSemestre.OnIdleState = stateProperties12;
            this.txtDenominacionSemestre.Padding = new System.Windows.Forms.Padding(4);
            this.txtDenominacionSemestre.PasswordChar = '\0';
            this.txtDenominacionSemestre.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtDenominacionSemestre.PlaceholderText = "Escriba el semestre";
            this.txtDenominacionSemestre.ReadOnly = false;
            this.txtDenominacionSemestre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDenominacionSemestre.SelectedText = "";
            this.txtDenominacionSemestre.SelectionLength = 0;
            this.txtDenominacionSemestre.SelectionStart = 0;
            this.txtDenominacionSemestre.ShortcutsEnabled = true;
            this.txtDenominacionSemestre.Size = new System.Drawing.Size(373, 49);
            this.txtDenominacionSemestre.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtDenominacionSemestre.TabIndex = 83;
            this.txtDenominacionSemestre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDenominacionSemestre.TextMarginBottom = 0;
            this.txtDenominacionSemestre.TextMarginLeft = 0;
            this.txtDenominacionSemestre.TextMarginTop = 0;
            this.txtDenominacionSemestre.TextPlaceholder = "Escriba el semestre";
            this.txtDenominacionSemestre.UseSystemPasswordChar = false;
            this.txtDenominacionSemestre.WordWrap = true;
            // 
            // lblAPaterno
            // 
            this.lblAPaterno.AllowParentOverrides = false;
            this.lblAPaterno.AutoEllipsis = false;
            this.lblAPaterno.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAPaterno.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblAPaterno.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblAPaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblAPaterno.Location = new System.Drawing.Point(22, 24);
            this.lblAPaterno.Margin = new System.Windows.Forms.Padding(4);
            this.lblAPaterno.Name = "lblAPaterno";
            this.lblAPaterno.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAPaterno.Size = new System.Drawing.Size(95, 27);
            this.lblAPaterno.TabIndex = 84;
            this.lblAPaterno.Text = "Semestre";
            this.lblAPaterno.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAPaterno.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(22, 123);
            this.bunifuLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(287, 27);
            this.bunifuLabel1.TabIndex = 85;
            this.bunifuLabel1.Text = "Fecha de inicio del semestre";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dpFechaInicialSemestre
            // 
            this.dpFechaInicialSemestre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dpFechaInicialSemestre.BackColor = System.Drawing.Color.Transparent;
            this.dpFechaInicialSemestre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dpFechaInicialSemestre.BorderRadius = 1;
            this.dpFechaInicialSemestre.CalendarFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFechaInicialSemestre.CalendarTitleBackColor = System.Drawing.Color.Aqua;
            this.dpFechaInicialSemestre.CalendarTitleForeColor = System.Drawing.Color.BlueViolet;
            this.dpFechaInicialSemestre.Color = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dpFechaInicialSemestre.CustomFormat = "dddd, dd / MM / yyyy";
            this.dpFechaInicialSemestre.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.dpFechaInicialSemestre.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Right;
            this.dpFechaInicialSemestre.DisabledColor = System.Drawing.Color.Gray;
            this.dpFechaInicialSemestre.DisplayWeekNumbers = false;
            this.dpFechaInicialSemestre.DPHeight = 0;
            this.dpFechaInicialSemestre.FillDatePicker = false;
            this.dpFechaInicialSemestre.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFechaInicialSemestre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dpFechaInicialSemestre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFechaInicialSemestre.Icon = ((System.Drawing.Image)(resources.GetObject("dpFechaInicialSemestre.Icon")));
            this.dpFechaInicialSemestre.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dpFechaInicialSemestre.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Left;
            this.dpFechaInicialSemestre.LeftTextMargin = 0;
            this.dpFechaInicialSemestre.Location = new System.Drawing.Point(22, 178);
            this.dpFechaInicialSemestre.Margin = new System.Windows.Forms.Padding(4);
            this.dpFechaInicialSemestre.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dpFechaInicialSemestre.MinimumSize = new System.Drawing.Size(4, 32);
            this.dpFechaInicialSemestre.Name = "dpFechaInicialSemestre";
            this.dpFechaInicialSemestre.Size = new System.Drawing.Size(359, 32);
            this.dpFechaInicialSemestre.TabIndex = 87;
            // 
            // P_DatosSemestre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 453);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnDatos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_DatosSemestre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P_DatosSemestre";
            this.pnDatos.ResumeLayout(false);
            this.pnDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuPanel pnDatos;
        private Bunifu.UI.WinForms.BunifuLabel lblErrorTelefono;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnLimpiar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnGuardar;
        public Bunifu.UI.WinForms.BunifuTextBox txtDenominacionSemestre;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuLabel lblAPaterno;
        private Bunifu.UI.WinForms.BunifuDatePicker dpFechaInicialSemestre;
    }
}