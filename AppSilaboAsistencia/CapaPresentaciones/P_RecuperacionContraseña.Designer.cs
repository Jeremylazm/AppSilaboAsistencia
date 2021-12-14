
namespace CapaPresentaciones
{
    partial class P_RecuperacionContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_RecuperacionContraseña));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.Movimiento = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Redimension = new Bunifu.UI.WinForms.BunifuFormDock();
            this.lblCorreo = new Bunifu.UI.WinForms.BunifuLabel();
            this.txtUsuario = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnRecuperar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.pnLogo = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblUniversidad = new Bunifu.UI.WinForms.BunifuLabel();
            this.pbLogo = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.pnLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Movimiento
            // 
            this.Movimiento.Fixed = true;
            this.Movimiento.Horizontal = true;
            this.Movimiento.TargetControl = this.lblTitulo;
            this.Movimiento.Vertical = true;
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
            this.lblTitulo.Size = new System.Drawing.Size(311, 127);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema de Gestión de Sílabo y\r\nControl de Asistencia\r\n\r\nRecuperación de Contrase" +
    "ña\r\n";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this;
            // 
            // Redimension
            // 
            this.Redimension.AllowFormDragging = true;
            this.Redimension.AllowFormDropShadow = true;
            this.Redimension.AllowFormResizing = true;
            this.Redimension.AllowHidingBottomRegion = true;
            this.Redimension.AllowOpacityChangesWhileDragging = false;
            this.Redimension.BorderOptions.BottomBorder.BorderColor = System.Drawing.Color.Silver;
            this.Redimension.BorderOptions.BottomBorder.BorderThickness = 1;
            this.Redimension.BorderOptions.BottomBorder.ShowBorder = true;
            this.Redimension.BorderOptions.LeftBorder.BorderColor = System.Drawing.Color.Silver;
            this.Redimension.BorderOptions.LeftBorder.BorderThickness = 1;
            this.Redimension.BorderOptions.LeftBorder.ShowBorder = true;
            this.Redimension.BorderOptions.RightBorder.BorderColor = System.Drawing.Color.Silver;
            this.Redimension.BorderOptions.RightBorder.BorderThickness = 1;
            this.Redimension.BorderOptions.RightBorder.ShowBorder = true;
            this.Redimension.BorderOptions.TopBorder.BorderColor = System.Drawing.Color.Silver;
            this.Redimension.BorderOptions.TopBorder.BorderThickness = 1;
            this.Redimension.BorderOptions.TopBorder.ShowBorder = true;
            this.Redimension.ContainerControl = this;
            this.Redimension.DockingIndicatorsColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
            this.Redimension.DockingIndicatorsOpacity = 0.5D;
            this.Redimension.DockingOptions.DockAll = true;
            this.Redimension.DockingOptions.DockBottomLeft = true;
            this.Redimension.DockingOptions.DockBottomRight = true;
            this.Redimension.DockingOptions.DockFullScreen = true;
            this.Redimension.DockingOptions.DockLeft = true;
            this.Redimension.DockingOptions.DockRight = true;
            this.Redimension.DockingOptions.DockTopLeft = true;
            this.Redimension.DockingOptions.DockTopRight = true;
            this.Redimension.FormDraggingOpacity = 0.9D;
            this.Redimension.ParentForm = this;
            this.Redimension.ShowCursorChanges = true;
            this.Redimension.ShowDockingIndicators = true;
            this.Redimension.TitleBarOptions.AllowFormDragging = true;
            this.Redimension.TitleBarOptions.BunifuFormDock = this.Redimension;
            this.Redimension.TitleBarOptions.DoubleClickToExpandWindow = true;
            this.Redimension.TitleBarOptions.TitleBarControl = null;
            this.Redimension.TitleBarOptions.UseBackColorOnDockingIndicators = false;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AllowParentOverrides = false;
            this.lblCorreo.AutoEllipsis = false;
            this.lblCorreo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCorreo.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblCorreo.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblCorreo.Location = new System.Drawing.Point(21, 175);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCorreo.Size = new System.Drawing.Size(161, 23);
            this.lblCorreo.TabIndex = 2;
            this.lblCorreo.Text = "Correo Institucional";
            this.lblCorreo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCorreo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtUsuario
            // 
            this.txtUsuario.AcceptsReturn = false;
            this.txtUsuario.AcceptsTab = false;
            this.txtUsuario.AnimationSpeed = 200;
            this.txtUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUsuario.AutoSizeHeight = true;
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtUsuario.BackgroundImage")));
            this.txtUsuario.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtUsuario.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtUsuario.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtUsuario.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtUsuario.BorderRadius = 1;
            this.txtUsuario.BorderThickness = 1;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.DefaultFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.DefaultText = "";
            this.txtUsuario.FillColor = System.Drawing.Color.White;
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtUsuario.HideSelection = true;
            this.txtUsuario.IconLeft = global::CapaPresentaciones.Properties.Resources.Correo_2;
            this.txtUsuario.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.IconPadding = 8;
            this.txtUsuario.IconRight = null;
            this.txtUsuario.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtUsuario.Lines = new string[0];
            this.txtUsuario.Location = new System.Drawing.Point(21, 201);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtUsuario.Modified = false;
            this.txtUsuario.Multiline = false;
            this.txtUsuario.Name = "txtUsuario";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUsuario.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtUsuario.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUsuario.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUsuario.OnIdleState = stateProperties8;
            this.txtUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtUsuario.PlaceholderText = "Escriba su correo";
            this.txtUsuario.ReadOnly = false;
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(269, 40);
            this.txtUsuario.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsuario.TextMarginBottom = 0;
            this.txtUsuario.TextMarginLeft = 7;
            this.txtUsuario.TextMarginTop = 0;
            this.txtUsuario.TextPlaceholder = "Escriba su correo";
            this.txtUsuario.UseSystemPasswordChar = false;
            this.txtUsuario.WordWrap = true;
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.AllowAnimations = true;
            this.btnRecuperar.AllowMouseEffects = true;
            this.btnRecuperar.AllowToggling = false;
            this.btnRecuperar.AnimationSpeed = 200;
            this.btnRecuperar.AutoGenerateColors = false;
            this.btnRecuperar.AutoRoundBorders = false;
            this.btnRecuperar.AutoSizeLeftIcon = true;
            this.btnRecuperar.AutoSizeRightIcon = true;
            this.btnRecuperar.BackColor = System.Drawing.Color.Transparent;
            this.btnRecuperar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecuperar.BackgroundImage")));
            this.btnRecuperar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRecuperar.ButtonText = "Recuperar mi contraseña";
            this.btnRecuperar.ButtonTextMarginLeft = 0;
            this.btnRecuperar.ColorContrastOnClick = 45;
            this.btnRecuperar.ColorContrastOnHover = 45;
            this.btnRecuperar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnRecuperar.CustomizableEdges = borderEdges2;
            this.btnRecuperar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRecuperar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnRecuperar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnRecuperar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnRecuperar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnRecuperar.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecuperar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnRecuperar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnRecuperar.IconMarginLeft = 11;
            this.btnRecuperar.IconPadding = 10;
            this.btnRecuperar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecuperar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnRecuperar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnRecuperar.IconSize = 25;
            this.btnRecuperar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.IdleBorderRadius = 15;
            this.btnRecuperar.IdleBorderThickness = 1;
            this.btnRecuperar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Cambiar_Contraseña;
            this.btnRecuperar.IdleIconRightImage = null;
            this.btnRecuperar.IndicateFocus = false;
            this.btnRecuperar.Location = new System.Drawing.Point(21, 260);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnRecuperar.OnDisabledState.BorderRadius = 15;
            this.btnRecuperar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRecuperar.OnDisabledState.BorderThickness = 1;
            this.btnRecuperar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnRecuperar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnRecuperar.OnDisabledState.IconLeftImage = null;
            this.btnRecuperar.OnDisabledState.IconRightImage = null;
            this.btnRecuperar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.onHoverState.BorderRadius = 15;
            this.btnRecuperar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRecuperar.onHoverState.BorderThickness = 1;
            this.btnRecuperar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Cambiar_Contraseña_2;
            this.btnRecuperar.onHoverState.IconRightImage = null;
            this.btnRecuperar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.OnIdleState.BorderRadius = 15;
            this.btnRecuperar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRecuperar.OnIdleState.BorderThickness = 1;
            this.btnRecuperar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Cambiar_Contraseña;
            this.btnRecuperar.OnIdleState.IconRightImage = null;
            this.btnRecuperar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.OnPressedState.BorderRadius = 15;
            this.btnRecuperar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnRecuperar.OnPressedState.BorderThickness = 1;
            this.btnRecuperar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnRecuperar.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnRecuperar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Cambiar_Contraseña;
            this.btnRecuperar.OnPressedState.IconRightImage = null;
            this.btnRecuperar.Size = new System.Drawing.Size(269, 39);
            this.btnRecuperar.TabIndex = 7;
            this.btnRecuperar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRecuperar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnRecuperar.TextMarginLeft = 0;
            this.btnRecuperar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnRecuperar.UseDefaultRadiusAndThickness = true;
            // 
            // pnLogo
            // 
            this.pnLogo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.pnLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnLogo.BackgroundImage")));
            this.pnLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnLogo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.pnLogo.BorderRadius = 0;
            this.pnLogo.BorderThickness = 0;
            this.pnLogo.Controls.Add(this.btnCerrar);
            this.pnLogo.Controls.Add(this.lblUniversidad);
            this.pnLogo.Controls.Add(this.pbLogo);
            this.pnLogo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnLogo.Location = new System.Drawing.Point(311, 0);
            this.pnLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pnLogo.Name = "pnLogo";
            this.pnLogo.ShowBorders = true;
            this.pnLogo.Size = new System.Drawing.Size(234, 360);
            this.pnLogo.TabIndex = 8;
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
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCerrar.ErrorImage = null;
            this.btnCerrar.FadeWhenInactive = false;
            this.btnCerrar.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnCerrar.Image = global::CapaPresentaciones.Properties.Resources.Cerrar_2;
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.ImageLocation = null;
            this.btnCerrar.ImageMargin = 10;
            this.btnCerrar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCerrar.ImageZoomSize = new System.Drawing.Size(30, 30);
            this.btnCerrar.InitialImage = null;
            this.btnCerrar.Location = new System.Drawing.Point(192, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0;
            this.btnCerrar.ShowActiveImage = true;
            this.btnCerrar.ShowCursorChanges = true;
            this.btnCerrar.ShowImageBorders = true;
            this.btnCerrar.ShowSizeMarkers = false;
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.ToolTipText = "";
            this.btnCerrar.WaitOnLoad = false;
            this.btnCerrar.Zoom = 10;
            this.btnCerrar.ZoomSpeed = 10;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblUniversidad
            // 
            this.lblUniversidad.AllowParentOverrides = false;
            this.lblUniversidad.AutoEllipsis = false;
            this.lblUniversidad.AutoSize = false;
            this.lblUniversidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblUniversidad.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblUniversidad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUniversidad.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblUniversidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblUniversidad.Location = new System.Drawing.Point(0, 281);
            this.lblUniversidad.Name = "lblUniversidad";
            this.lblUniversidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUniversidad.Size = new System.Drawing.Size(234, 79);
            this.lblUniversidad.TabIndex = 10;
            this.lblUniversidad.Text = "Universidad Nacional de San Antonio Abad del Cusco";
            this.lblUniversidad.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lblUniversidad.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pbLogo
            // 
            this.pbLogo.ActiveImage = null;
            this.pbLogo.AllowAnimations = true;
            this.pbLogo.AllowBuffering = false;
            this.pbLogo.AllowToggling = false;
            this.pbLogo.AllowZooming = false;
            this.pbLogo.AllowZoomingOnFocus = false;
            this.pbLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbLogo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.pbLogo.ErrorImage = null;
            this.pbLogo.FadeWhenInactive = false;
            this.pbLogo.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.pbLogo.Image = global::CapaPresentaciones.Properties.Resources.Logo_UNSAAC3;
            this.pbLogo.ImageActive = null;
            this.pbLogo.ImageLocation = null;
            this.pbLogo.ImageMargin = 10;
            this.pbLogo.ImageSize = new System.Drawing.Size(202, 262);
            this.pbLogo.ImageZoomSize = new System.Drawing.Size(212, 272);
            this.pbLogo.InitialImage = null;
            this.pbLogo.Location = new System.Drawing.Point(10, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Rotation = 0;
            this.pbLogo.ShowActiveImage = false;
            this.pbLogo.ShowCursorChanges = false;
            this.pbLogo.ShowImageBorders = true;
            this.pbLogo.ShowSizeMarkers = false;
            this.pbLogo.Size = new System.Drawing.Size(212, 272);
            this.pbLogo.TabIndex = 9;
            this.pbLogo.ToolTipText = "";
            this.pbLogo.WaitOnLoad = false;
            this.pbLogo.Zoom = 10;
            this.pbLogo.ZoomSpeed = 10;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 72);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(311, 14);
            this.bunifuSeparator1.TabIndex = 9;
            // 
            // P_RecuperacionContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(545, 360);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_RecuperacionContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recuperación de Contraseña";
            this.pnLogo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl Movimiento;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuFormDock Redimension;
        private Bunifu.UI.WinForms.BunifuTextBox txtUsuario;
        private Bunifu.UI.WinForms.BunifuLabel lblCorreo;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnRecuperar;
        private Bunifu.UI.WinForms.BunifuPanel pnLogo;
        private Bunifu.UI.WinForms.BunifuImageButton pbLogo;
        private Bunifu.UI.WinForms.BunifuLabel lblUniversidad;
        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
    }
}