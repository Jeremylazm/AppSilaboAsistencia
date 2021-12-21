
namespace CapaPresentaciones
{
    partial class P_TablaSesiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_TablaSesiones));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.pbLogo = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Docker = new Bunifu.UI.WinForms.BunifuFormDock();
            this.txtBuscar = new Bunifu.UI.WinForms.BunifuTextBox();
            this.sbDatos = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.btnAceptar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.dgvSesiones = new Bunifu.UI.WinForms.BunifuDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSesiones)).BeginInit();
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
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(1055, 57);
            this.lblTitulo.TabIndex = 20;
            this.lblTitulo.Text = "Tabla de Sesiones - ";
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
            this.btnCerrar.Location = new System.Drawing.Point(1001, 9);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0;
            this.btnCerrar.ShowActiveImage = true;
            this.btnCerrar.ShowCursorChanges = true;
            this.btnCerrar.ShowImageBorders = true;
            this.btnCerrar.ShowSizeMarkers = false;
            this.btnCerrar.Size = new System.Drawing.Size(40, 37);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.ToolTipText = "";
            this.btnCerrar.WaitOnLoad = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.ZoomSpeed = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.ActiveImage = null;
            this.pbLogo.AllowAnimations = true;
            this.pbLogo.AllowBuffering = false;
            this.pbLogo.AllowToggling = false;
            this.pbLogo.AllowZooming = false;
            this.pbLogo.AllowZoomingOnFocus = false;
            this.pbLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbLogo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.pbLogo.ErrorImage = null;
            this.pbLogo.FadeWhenInactive = false;
            this.pbLogo.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.pbLogo.Image = global::CapaPresentaciones.Properties.Resources.Logo_UNSAAC3;
            this.pbLogo.ImageActive = null;
            this.pbLogo.ImageLocation = null;
            this.pbLogo.ImageMargin = 0;
            this.pbLogo.ImageSize = new System.Drawing.Size(32, 37);
            this.pbLogo.ImageZoomSize = new System.Drawing.Size(32, 37);
            this.pbLogo.InitialImage = null;
            this.pbLogo.Location = new System.Drawing.Point(11, 9);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Rotation = 0;
            this.pbLogo.ShowActiveImage = false;
            this.pbLogo.ShowCursorChanges = false;
            this.pbLogo.ShowImageBorders = true;
            this.pbLogo.ShowSizeMarkers = false;
            this.pbLogo.Size = new System.Drawing.Size(32, 37);
            this.pbLogo.TabIndex = 13;
            this.pbLogo.ToolTipText = "";
            this.pbLogo.WaitOnLoad = false;
            this.pbLogo.Zoom = 0;
            this.pbLogo.ZoomSpeed = 10;
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
            this.Docker.AllowFormResizing = true;
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
            // txtBuscar
            // 
            this.txtBuscar.AcceptsReturn = false;
            this.txtBuscar.AcceptsTab = false;
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.AnimationSpeed = 200;
            this.txtBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBuscar.AutoSizeHeight = true;
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtBuscar.BackgroundImage")));
            this.txtBuscar.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtBuscar.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtBuscar.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtBuscar.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtBuscar.BorderRadius = 1;
            this.txtBuscar.BorderThickness = 1;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.DefaultFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.DefaultText = "";
            this.txtBuscar.FillColor = System.Drawing.Color.White;
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtBuscar.HideSelection = true;
            this.txtBuscar.IconLeft = global::CapaPresentaciones.Properties.Resources.Buscar_2;
            this.txtBuscar.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.IconPadding = 8;
            this.txtBuscar.IconRight = null;
            this.txtBuscar.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtBuscar.Lines = new string[0];
            this.txtBuscar.Location = new System.Drawing.Point(12, 57);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.txtBuscar.MaxLength = 32767;
            this.txtBuscar.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBuscar.Modified = false;
            this.txtBuscar.Multiline = false;
            this.txtBuscar.Name = "txtBuscar";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscar.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtBuscar.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscar.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscar.OnIdleState = stateProperties4;
            this.txtBuscar.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBuscar.PlaceholderText = "Buscar...";
            this.txtBuscar.ReadOnly = false;
            this.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.ShortcutsEnabled = true;
            this.txtBuscar.Size = new System.Drawing.Size(1031, 49);
            this.txtBuscar.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtBuscar.TabIndex = 30;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscar.TextMarginBottom = 0;
            this.txtBuscar.TextMarginLeft = 7;
            this.txtBuscar.TextMarginTop = 0;
            this.txtBuscar.TextPlaceholder = "Buscar...";
            this.txtBuscar.UseSystemPasswordChar = false;
            this.txtBuscar.WordWrap = true;
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
            this.sbDatos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.sbDatos.BorderRadius = 0;
            this.sbDatos.BorderThickness = 1;
            this.sbDatos.DurationBeforeShrink = 2000;
            this.sbDatos.LargeChange = 10;
            this.sbDatos.Location = new System.Drawing.Point(1030, 115);
            this.sbDatos.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            this.sbDatos.Size = new System.Drawing.Size(13, 604);
            this.sbDatos.SmallChange = 1;
            this.sbDatos.TabIndex = 33;
            this.sbDatos.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.sbDatos.ThumbLength = 59;
            this.sbDatos.ThumbMargin = 1;
            this.sbDatos.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.sbDatos.Value = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AllowAnimations = true;
            this.btnAceptar.AllowMouseEffects = true;
            this.btnAceptar.AllowToggling = false;
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.AnimationSpeed = 200;
            this.btnAceptar.AutoGenerateColors = false;
            this.btnAceptar.AutoRoundBorders = false;
            this.btnAceptar.AutoSizeLeftIcon = true;
            this.btnAceptar.AutoSizeRightIcon = true;
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.ButtonText = "Aceptar";
            this.btnAceptar.ButtonTextMarginLeft = 0;
            this.btnAceptar.ColorContrastOnClick = 45;
            this.btnAceptar.ColorContrastOnHover = 45;
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAceptar.CustomizableEdges = borderEdges1;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAceptar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAceptar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAceptar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAceptar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAceptar.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAceptar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAceptar.IconMarginLeft = 11;
            this.btnAceptar.IconPadding = 10;
            this.btnAceptar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAceptar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAceptar.IconSize = 25;
            this.btnAceptar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.IdleBorderRadius = 15;
            this.btnAceptar.IdleBorderThickness = 1;
            this.btnAceptar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar;
            this.btnAceptar.IdleIconRightImage = null;
            this.btnAceptar.IndicateFocus = false;
            this.btnAceptar.Location = new System.Drawing.Point(815, 727);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAceptar.OnDisabledState.BorderRadius = 15;
            this.btnAceptar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.OnDisabledState.BorderThickness = 1;
            this.btnAceptar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAceptar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAceptar.OnDisabledState.IconLeftImage = null;
            this.btnAceptar.OnDisabledState.IconRightImage = null;
            this.btnAceptar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.onHoverState.BorderRadius = 15;
            this.btnAceptar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.onHoverState.BorderThickness = 1;
            this.btnAceptar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar_2;
            this.btnAceptar.onHoverState.IconRightImage = null;
            this.btnAceptar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.OnIdleState.BorderRadius = 15;
            this.btnAceptar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.OnIdleState.BorderThickness = 1;
            this.btnAceptar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar;
            this.btnAceptar.OnIdleState.IconRightImage = null;
            this.btnAceptar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.OnPressedState.BorderRadius = 15;
            this.btnAceptar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.OnPressedState.BorderThickness = 1;
            this.btnAceptar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar;
            this.btnAceptar.OnPressedState.IconRightImage = null;
            this.btnAceptar.Size = new System.Drawing.Size(227, 48);
            this.btnAceptar.TabIndex = 35;
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAceptar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAceptar.TextMarginLeft = 0;
            this.btnAceptar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnAceptar.UseDefaultRadiusAndThickness = true;
            // 
            // dgvSesiones
            // 
            this.dgvSesiones.AllowCustomTheming = true;
            this.dgvSesiones.AllowUserToAddRows = false;
            this.dgvSesiones.AllowUserToDeleteRows = false;
            this.dgvSesiones.AllowUserToOrderColumns = true;
            this.dgvSesiones.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSesiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSesiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSesiones.BackgroundColor = System.Drawing.Color.White;
            this.dgvSesiones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSesiones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSesiones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSesiones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSesiones.ColumnHeadersHeight = 28;
            this.dgvSesiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSesiones.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.dgvSesiones.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSesiones.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvSesiones.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dgvSesiones.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSesiones.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvSesiones.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.CurrentTheme.Name = null;
            this.dgvSesiones.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dgvSesiones.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.dgvSesiones.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvSesiones.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSesiones.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSesiones.EnableHeadersVisualStyles = false;
            this.dgvSesiones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dgvSesiones.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvSesiones.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvSesiones.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvSesiones.Location = new System.Drawing.Point(31, 126);
            this.dgvSesiones.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSesiones.MultiSelect = false;
            this.dgvSesiones.Name = "dgvSesiones";
            this.dgvSesiones.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSesiones.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSesiones.RowHeadersVisible = false;
            this.dgvSesiones.RowHeadersWidth = 28;
            this.dgvSesiones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSesiones.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSesiones.RowTemplate.Height = 26;
            this.dgvSesiones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSesiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSesiones.Size = new System.Drawing.Size(1010, 593);
            this.dgvSesiones.TabIndex = 37;
            this.dgvSesiones.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Maroon;
            // 
            // P_TablaSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 788);
            this.Controls.Add(this.sbDatos);
            this.Controls.Add(this.dgvSesiones);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "P_TablaSesiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla de Sesiones - ASIGNATURA";
            this.Load += new System.EventHandler(this.P_TablaSesiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSesiones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuImageButton pbLogo;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.UI.WinForms.BunifuFormDock Docker;
        private Bunifu.UI.WinForms.BunifuTextBox txtBuscar;
        private Bunifu.UI.WinForms.BunifuVScrollBar sbDatos;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAceptar;
        public Bunifu.UI.WinForms.BunifuDataGridView dgvSesiones;
    }
}