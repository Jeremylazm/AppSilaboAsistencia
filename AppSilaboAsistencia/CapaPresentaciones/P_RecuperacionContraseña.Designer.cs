﻿
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
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.Movimiento = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Redimension = new Bunifu.UI.WinForms.BunifuFormDock();
            this.lblCorreo = new Bunifu.UI.WinForms.BunifuLabel();
            this.txtCorreo = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnRecuperar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.pnLogo = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblUniversidad = new Bunifu.UI.WinForms.BunifuLabel();
            this.pbLogo = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Separador1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.lblDominio = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblMensaje = new Bunifu.UI.WinForms.BunifuLabel();
            this.Docker = new Bunifu.UI.WinForms.BunifuFormDock();
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
            this.lblCorreo.Location = new System.Drawing.Point(21, 156);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCorreo.Size = new System.Drawing.Size(161, 23);
            this.lblCorreo.TabIndex = 2;
            this.lblCorreo.Text = "Correo Institucional";
            this.lblCorreo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCorreo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtCorreo
            // 
            this.txtCorreo.AcceptsReturn = false;
            this.txtCorreo.AcceptsTab = false;
            this.txtCorreo.AnimationSpeed = 200;
            this.txtCorreo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCorreo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCorreo.AutoSizeHeight = true;
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtCorreo.BackgroundImage")));
            this.txtCorreo.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtCorreo.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtCorreo.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtCorreo.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtCorreo.BorderRadius = 1;
            this.txtCorreo.BorderThickness = 1;
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCorreo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCorreo.DefaultFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.DefaultText = "";
            this.txtCorreo.FillColor = System.Drawing.Color.White;
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtCorreo.HideSelection = true;
            this.txtCorreo.IconLeft = global::CapaPresentaciones.Properties.Resources.Correo_2;
            this.txtCorreo.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCorreo.IconPadding = 8;
            this.txtCorreo.IconRight = null;
            this.txtCorreo.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCorreo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCorreo.Lines = new string[0];
            this.txtCorreo.Location = new System.Drawing.Point(21, 182);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(0);
            this.txtCorreo.MaxLength = 32767;
            this.txtCorreo.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCorreo.Modified = false;
            this.txtCorreo.Multiline = false;
            this.txtCorreo.Name = "txtCorreo";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCorreo.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtCorreo.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCorreo.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtCorreo.OnIdleState = stateProperties4;
            this.txtCorreo.Padding = new System.Windows.Forms.Padding(3);
            this.txtCorreo.PasswordChar = '\0';
            this.txtCorreo.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtCorreo.PlaceholderText = "Código";
            this.txtCorreo.ReadOnly = false;
            this.txtCorreo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCorreo.SelectedText = "";
            this.txtCorreo.SelectionLength = 0;
            this.txtCorreo.SelectionStart = 0;
            this.txtCorreo.ShortcutsEnabled = true;
            this.txtCorreo.Size = new System.Drawing.Size(269, 40);
            this.txtCorreo.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtCorreo.TabIndex = 3;
            this.txtCorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCorreo.TextMarginBottom = 0;
            this.txtCorreo.TextMarginLeft = 7;
            this.txtCorreo.TextMarginTop = 0;
            this.txtCorreo.TextPlaceholder = "Código";
            this.txtCorreo.UseSystemPasswordChar = false;
            this.txtCorreo.WordWrap = true;
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
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnRecuperar.CustomizableEdges = borderEdges1;
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
            this.btnRecuperar.Location = new System.Drawing.Point(21, 241);
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
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click_1);
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
            // Separador1
            // 
            this.Separador1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.Separador1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Separador1.BackgroundImage")));
            this.Separador1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Separador1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.Separador1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.Separador1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.Separador1.LineThickness = 2;
            this.Separador1.Location = new System.Drawing.Point(0, 72);
            this.Separador1.Margin = new System.Windows.Forms.Padding(4);
            this.Separador1.Name = "Separador1";
            this.Separador1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.Separador1.Size = new System.Drawing.Size(311, 14);
            this.Separador1.TabIndex = 9;
            // 
            // lblDominio
            // 
            this.lblDominio.AllowParentOverrides = false;
            this.lblDominio.AutoEllipsis = false;
            this.lblDominio.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDominio.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblDominio.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDominio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblDominio.Location = new System.Drawing.Point(153, 191);
            this.lblDominio.Name = "lblDominio";
            this.lblDominio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDominio.Size = new System.Drawing.Size(137, 23);
            this.lblDominio.TabIndex = 10;
            this.lblDominio.Text = "@unsaac.edu.pe";
            this.lblDominio.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDominio.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AllowParentOverrides = false;
            this.lblMensaje.AutoEllipsis = false;
            this.lblMensaje.AutoSize = false;
            this.lblMensaje.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMensaje.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblMensaje.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblMensaje.Location = new System.Drawing.Point(21, 283);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMensaje.Size = new System.Drawing.Size(269, 68);
            this.lblMensaje.TabIndex = 134;
            this.lblMensaje.Text = "Se le envió un mensaje a su correo electrónico";
            this.lblMensaje.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensaje.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblMensaje.Visible = false;
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
            // P_RecuperacionContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(545, 360);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblDominio);
            this.Controls.Add(this.Separador1);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.txtCorreo);
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
        private Bunifu.UI.WinForms.BunifuTextBox txtCorreo;
        private Bunifu.UI.WinForms.BunifuLabel lblCorreo;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnRecuperar;
        private Bunifu.UI.WinForms.BunifuPanel pnLogo;
        private Bunifu.UI.WinForms.BunifuImageButton pbLogo;
        private Bunifu.UI.WinForms.BunifuLabel lblUniversidad;
        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuSeparator Separador1;
        private Bunifu.UI.WinForms.BunifuLabel lblDominio;
        private Bunifu.UI.WinForms.BunifuLabel lblMensaje;
        private Bunifu.UI.WinForms.BunifuFormDock Docker;
    }
}