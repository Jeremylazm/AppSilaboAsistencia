﻿
namespace CapaPresentaciones
{
    partial class P_InicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_InicioSesion));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation1 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblUsuario = new Bunifu.UI.WinForms.BunifuLabel();
            this.txtUsuario = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtContraseña = new Bunifu.UI.WinForms.BunifuTextBox();
            this.lblContraseña = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnIngresar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.pnLogo = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblUniversidad = new Bunifu.UI.WinForms.BunifuLabel();
            this.pbLogo = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnOlvidarContraseña = new System.Windows.Forms.LinkLabel();
            this.lblErrorUsuario = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblErrorContraseña = new Bunifu.UI.WinForms.BunifuLabel();
            this.pbErrorUsuario = new Bunifu.UI.WinForms.BunifuImageButton();
            this.pbErrorContraseña = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Docker = new Bunifu.UI.WinForms.BunifuFormDock();
            this.btnMostrarOcultarContraseña = new Bunifu.UI.WinForms.BunifuImageButton();
            this.pnBienvenida = new Bunifu.UI.WinForms.BunifuPanel();
            this.TiempoDesaparicion = new System.Windows.Forms.Timer(this.components);
            this.AparicionBienvenida = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.Bienvenida = new ControlesPerzonalizados.C_Bienvenida();
            this.pnLogo.SuspendLayout();
            this.pnBienvenida.SuspendLayout();
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
            this.AparicionBienvenida.SetDecoration(this.lblTitulo, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat Alternates", 14F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(376, 87);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Sistema de Gestión de Sílabo y\r\nControl de Asistencia";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AllowParentOverrides = false;
            this.lblUsuario.AutoEllipsis = false;
            this.lblUsuario.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblUsuario.CursorType = System.Windows.Forms.Cursors.Default;
            this.AparicionBienvenida.SetDecoration(this.lblUsuario, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblUsuario.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblUsuario.Location = new System.Drawing.Point(21, 103);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUsuario.Size = new System.Drawing.Size(63, 23);
            this.lblUsuario.TabIndex = 12;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUsuario.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
            this.AparicionBienvenida.SetDecoration(this.txtUsuario, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtUsuario.DefaultFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.DefaultText = "";
            this.txtUsuario.FillColor = System.Drawing.Color.White;
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtUsuario.HideSelection = true;
            this.txtUsuario.IconLeft = global::CapaPresentaciones.Properties.Resources.Usuario;
            this.txtUsuario.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.IconPadding = 8;
            this.txtUsuario.IconRight = null;
            this.txtUsuario.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtUsuario.Lines = new string[0];
            this.txtUsuario.Location = new System.Drawing.Point(21, 129);
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
            this.txtUsuario.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtUsuario.PlaceholderText = "Escriba su usuario";
            this.txtUsuario.ReadOnly = false;
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(333, 40);
            this.txtUsuario.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsuario.TextMarginBottom = 0;
            this.txtUsuario.TextMarginLeft = 7;
            this.txtUsuario.TextMarginTop = 0;
            this.txtUsuario.TextPlaceholder = "Escriba su usuario";
            this.txtUsuario.UseSystemPasswordChar = false;
            this.txtUsuario.WordWrap = true;
            this.txtUsuario.TextChange += new System.EventHandler(this.txtUsuario_TextChange);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // txtContraseña
            // 
            this.txtContraseña.AcceptsReturn = false;
            this.txtContraseña.AcceptsTab = false;
            this.txtContraseña.AnimationSpeed = 200;
            this.txtContraseña.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtContraseña.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtContraseña.AutoSizeHeight = true;
            this.txtContraseña.BackColor = System.Drawing.Color.White;
            this.txtContraseña.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtContraseña.BackgroundImage")));
            this.txtContraseña.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtContraseña.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtContraseña.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtContraseña.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtContraseña.BorderRadius = 1;
            this.txtContraseña.BorderThickness = 1;
            this.txtContraseña.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtContraseña.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AparicionBienvenida.SetDecoration(this.txtContraseña, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.txtContraseña.DefaultFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.DefaultText = "";
            this.txtContraseña.FillColor = System.Drawing.Color.White;
            this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtContraseña.HideSelection = true;
            this.txtContraseña.IconLeft = global::CapaPresentaciones.Properties.Resources.Contraseña;
            this.txtContraseña.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContraseña.IconPadding = 8;
            this.txtContraseña.IconRight = null;
            this.txtContraseña.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContraseña.Lines = new string[0];
            this.txtContraseña.Location = new System.Drawing.Point(21, 224);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(0);
            this.txtContraseña.MaxLength = 32767;
            this.txtContraseña.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtContraseña.Modified = false;
            this.txtContraseña.Multiline = false;
            this.txtContraseña.Name = "txtContraseña";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtContraseña.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtContraseña.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtContraseña.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtContraseña.OnIdleState = stateProperties4;
            this.txtContraseña.Padding = new System.Windows.Forms.Padding(3);
            this.txtContraseña.PasswordChar = '\0';
            this.txtContraseña.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtContraseña.PlaceholderText = "Escriba su contraseña";
            this.txtContraseña.ReadOnly = false;
            this.txtContraseña.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContraseña.SelectedText = "";
            this.txtContraseña.SelectionLength = 0;
            this.txtContraseña.SelectionStart = 0;
            this.txtContraseña.ShortcutsEnabled = true;
            this.txtContraseña.Size = new System.Drawing.Size(333, 40);
            this.txtContraseña.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtContraseña.TabIndex = 1;
            this.txtContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtContraseña.TextMarginBottom = 0;
            this.txtContraseña.TextMarginLeft = 7;
            this.txtContraseña.TextMarginTop = 0;
            this.txtContraseña.TextPlaceholder = "Escriba su contraseña";
            this.txtContraseña.UseSystemPasswordChar = false;
            this.txtContraseña.WordWrap = true;
            this.txtContraseña.TextChange += new System.EventHandler(this.txtContraseña_TextChange);
            this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseña_KeyPress);
            // 
            // lblContraseña
            // 
            this.lblContraseña.AllowParentOverrides = false;
            this.lblContraseña.AutoEllipsis = false;
            this.lblContraseña.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblContraseña.CursorType = System.Windows.Forms.Cursors.Default;
            this.AparicionBienvenida.SetDecoration(this.lblContraseña, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblContraseña.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblContraseña.Location = new System.Drawing.Point(21, 198);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblContraseña.Size = new System.Drawing.Size(96, 23);
            this.lblContraseña.TabIndex = 13;
            this.lblContraseña.Text = "Contraseña";
            this.lblContraseña.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContraseña.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnIngresar
            // 
            this.btnIngresar.AllowAnimations = true;
            this.btnIngresar.AllowMouseEffects = true;
            this.btnIngresar.AllowToggling = false;
            this.btnIngresar.AnimationSpeed = 200;
            this.btnIngresar.AutoGenerateColors = false;
            this.btnIngresar.AutoRoundBorders = false;
            this.btnIngresar.AutoSizeLeftIcon = true;
            this.btnIngresar.AutoSizeRightIcon = true;
            this.btnIngresar.BackColor = System.Drawing.Color.Transparent;
            this.btnIngresar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnIngresar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIngresar.BackgroundImage")));
            this.btnIngresar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnIngresar.ButtonText = "Ingresar";
            this.btnIngresar.ButtonTextMarginLeft = 0;
            this.btnIngresar.ColorContrastOnClick = 45;
            this.btnIngresar.ColorContrastOnHover = 45;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnIngresar.CustomizableEdges = borderEdges1;
            this.AparicionBienvenida.SetDecoration(this.btnIngresar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnIngresar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnIngresar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnIngresar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnIngresar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnIngresar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnIngresar.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnIngresar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnIngresar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnIngresar.IconMarginLeft = 11;
            this.btnIngresar.IconPadding = 10;
            this.btnIngresar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnIngresar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnIngresar.IconSize = 25;
            this.btnIngresar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnIngresar.IdleBorderRadius = 15;
            this.btnIngresar.IdleBorderThickness = 1;
            this.btnIngresar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnIngresar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Ingresar;
            this.btnIngresar.IdleIconRightImage = null;
            this.btnIngresar.IndicateFocus = false;
            this.btnIngresar.Location = new System.Drawing.Point(58, 300);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnIngresar.OnDisabledState.BorderRadius = 15;
            this.btnIngresar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnIngresar.OnDisabledState.BorderThickness = 1;
            this.btnIngresar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnIngresar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnIngresar.OnDisabledState.IconLeftImage = null;
            this.btnIngresar.OnDisabledState.IconRightImage = null;
            this.btnIngresar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnIngresar.onHoverState.BorderRadius = 15;
            this.btnIngresar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnIngresar.onHoverState.BorderThickness = 1;
            this.btnIngresar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnIngresar.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnIngresar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Ingresar_2;
            this.btnIngresar.onHoverState.IconRightImage = null;
            this.btnIngresar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnIngresar.OnIdleState.BorderRadius = 15;
            this.btnIngresar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnIngresar.OnIdleState.BorderThickness = 1;
            this.btnIngresar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnIngresar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnIngresar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Ingresar;
            this.btnIngresar.OnIdleState.IconRightImage = null;
            this.btnIngresar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnIngresar.OnPressedState.BorderRadius = 15;
            this.btnIngresar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnIngresar.OnPressedState.BorderThickness = 1;
            this.btnIngresar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnIngresar.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnIngresar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Ingresar;
            this.btnIngresar.OnPressedState.IconRightImage = null;
            this.btnIngresar.Size = new System.Drawing.Size(269, 39);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnIngresar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnIngresar.TextMarginLeft = 0;
            this.btnIngresar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnIngresar.UseDefaultRadiusAndThickness = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
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
            this.AparicionBienvenida.SetDecoration(this.pnLogo, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnLogo.Location = new System.Drawing.Point(376, 0);
            this.pnLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pnLogo.Name = "pnLogo";
            this.pnLogo.ShowBorders = true;
            this.pnLogo.Size = new System.Drawing.Size(255, 388);
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
            this.AparicionBienvenida.SetDecoration(this.btnCerrar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCerrar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.ErrorImage")));
            this.btnCerrar.FadeWhenInactive = false;
            this.btnCerrar.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnCerrar.Image = global::CapaPresentaciones.Properties.Resources.Cerrar_2;
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.ImageLocation = null;
            this.btnCerrar.ImageMargin = 10;
            this.btnCerrar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCerrar.ImageZoomSize = new System.Drawing.Size(30, 30);
            this.btnCerrar.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.InitialImage")));
            this.btnCerrar.Location = new System.Drawing.Point(213, 12);
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
            this.AparicionBienvenida.SetDecoration(this.lblUniversidad, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblUniversidad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUniversidad.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblUniversidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblUniversidad.Location = new System.Drawing.Point(0, 301);
            this.lblUniversidad.Name = "lblUniversidad";
            this.lblUniversidad.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUniversidad.Size = new System.Drawing.Size(255, 87);
            this.lblUniversidad.TabIndex = 10;
            this.lblUniversidad.Text = "Universidad Nacional de \r\nSan Antonio Abad del \r\nCusco";
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
            this.AparicionBienvenida.SetDecoration(this.pbLogo, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbLogo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.pbLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.ErrorImage")));
            this.pbLogo.FadeWhenInactive = false;
            this.pbLogo.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.pbLogo.Image = global::CapaPresentaciones.Properties.Resources.Logo_UNSAAC3;
            this.pbLogo.ImageActive = null;
            this.pbLogo.ImageLocation = null;
            this.pbLogo.ImageMargin = 10;
            this.pbLogo.ImageSize = new System.Drawing.Size(202, 262);
            this.pbLogo.ImageZoomSize = new System.Drawing.Size(212, 272);
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(23, 23);
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
            // btnOlvidarContraseña
            // 
            this.btnOlvidarContraseña.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnOlvidarContraseña.AutoSize = true;
            this.AparicionBienvenida.SetDecoration(this.btnOlvidarContraseña, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnOlvidarContraseña.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOlvidarContraseña.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnOlvidarContraseña.LinkColor = System.Drawing.Color.Black;
            this.btnOlvidarContraseña.Location = new System.Drawing.Point(104, 342);
            this.btnOlvidarContraseña.Name = "btnOlvidarContraseña";
            this.btnOlvidarContraseña.Size = new System.Drawing.Size(184, 22);
            this.btnOlvidarContraseña.TabIndex = 9;
            this.btnOlvidarContraseña.TabStop = true;
            this.btnOlvidarContraseña.Text = "Olvidé mi contraseña";
            this.btnOlvidarContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOlvidarContraseña.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnOlvidarContraseña.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnOlvidarContraseña_LinkClicked);
            // 
            // lblErrorUsuario
            // 
            this.lblErrorUsuario.AllowParentOverrides = false;
            this.lblErrorUsuario.AutoEllipsis = false;
            this.lblErrorUsuario.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblErrorUsuario.CursorType = System.Windows.Forms.Cursors.Default;
            this.AparicionBienvenida.SetDecoration(this.lblErrorUsuario, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblErrorUsuario.Font = new System.Drawing.Font("Montserrat Alternates", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblErrorUsuario.Location = new System.Drawing.Point(58, 172);
            this.lblErrorUsuario.Name = "lblErrorUsuario";
            this.lblErrorUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblErrorUsuario.Size = new System.Drawing.Size(105, 19);
            this.lblErrorUsuario.TabIndex = 10;
            this.lblErrorUsuario.Text = "Error de Usuario";
            this.lblErrorUsuario.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErrorUsuario.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblErrorUsuario.Visible = false;
            // 
            // lblErrorContraseña
            // 
            this.lblErrorContraseña.AllowParentOverrides = false;
            this.lblErrorContraseña.AutoEllipsis = false;
            this.lblErrorContraseña.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblErrorContraseña.CursorType = System.Windows.Forms.Cursors.Default;
            this.AparicionBienvenida.SetDecoration(this.lblErrorContraseña, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblErrorContraseña.Font = new System.Drawing.Font("Montserrat Alternates", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblErrorContraseña.Location = new System.Drawing.Point(58, 267);
            this.lblErrorContraseña.Name = "lblErrorContraseña";
            this.lblErrorContraseña.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblErrorContraseña.Size = new System.Drawing.Size(131, 19);
            this.lblErrorContraseña.TabIndex = 11;
            this.lblErrorContraseña.Text = "Error de Contraseña";
            this.lblErrorContraseña.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErrorContraseña.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblErrorContraseña.Visible = false;
            // 
            // pbErrorUsuario
            // 
            this.pbErrorUsuario.ActiveImage = null;
            this.pbErrorUsuario.AllowAnimations = true;
            this.pbErrorUsuario.AllowBuffering = false;
            this.pbErrorUsuario.AllowToggling = false;
            this.pbErrorUsuario.AllowZooming = false;
            this.pbErrorUsuario.AllowZoomingOnFocus = false;
            this.pbErrorUsuario.BackColor = System.Drawing.Color.White;
            this.pbErrorUsuario.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AparicionBienvenida.SetDecoration(this.pbErrorUsuario, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbErrorUsuario.DialogResult = System.Windows.Forms.DialogResult.None;
            this.pbErrorUsuario.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbErrorUsuario.ErrorImage")));
            this.pbErrorUsuario.FadeWhenInactive = false;
            this.pbErrorUsuario.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.pbErrorUsuario.Image = global::CapaPresentaciones.Properties.Resources.Dialogo_Error;
            this.pbErrorUsuario.ImageActive = null;
            this.pbErrorUsuario.ImageLocation = null;
            this.pbErrorUsuario.ImageMargin = 0;
            this.pbErrorUsuario.ImageSize = new System.Drawing.Size(18, 18);
            this.pbErrorUsuario.ImageZoomSize = new System.Drawing.Size(18, 18);
            this.pbErrorUsuario.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbErrorUsuario.InitialImage")));
            this.pbErrorUsuario.Location = new System.Drawing.Point(34, 174);
            this.pbErrorUsuario.Name = "pbErrorUsuario";
            this.pbErrorUsuario.Rotation = 0;
            this.pbErrorUsuario.ShowActiveImage = false;
            this.pbErrorUsuario.ShowCursorChanges = false;
            this.pbErrorUsuario.ShowImageBorders = true;
            this.pbErrorUsuario.ShowSizeMarkers = false;
            this.pbErrorUsuario.Size = new System.Drawing.Size(18, 18);
            this.pbErrorUsuario.TabIndex = 12;
            this.pbErrorUsuario.ToolTipText = "";
            this.pbErrorUsuario.Visible = false;
            this.pbErrorUsuario.WaitOnLoad = false;
            this.pbErrorUsuario.Zoom = 0;
            this.pbErrorUsuario.ZoomSpeed = 10;
            // 
            // pbErrorContraseña
            // 
            this.pbErrorContraseña.ActiveImage = null;
            this.pbErrorContraseña.AllowAnimations = true;
            this.pbErrorContraseña.AllowBuffering = false;
            this.pbErrorContraseña.AllowToggling = false;
            this.pbErrorContraseña.AllowZooming = false;
            this.pbErrorContraseña.AllowZoomingOnFocus = false;
            this.pbErrorContraseña.BackColor = System.Drawing.Color.White;
            this.pbErrorContraseña.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AparicionBienvenida.SetDecoration(this.pbErrorContraseña, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbErrorContraseña.DialogResult = System.Windows.Forms.DialogResult.None;
            this.pbErrorContraseña.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbErrorContraseña.ErrorImage")));
            this.pbErrorContraseña.FadeWhenInactive = false;
            this.pbErrorContraseña.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.pbErrorContraseña.Image = global::CapaPresentaciones.Properties.Resources.Dialogo_Error;
            this.pbErrorContraseña.ImageActive = null;
            this.pbErrorContraseña.ImageLocation = null;
            this.pbErrorContraseña.ImageMargin = 0;
            this.pbErrorContraseña.ImageSize = new System.Drawing.Size(18, 18);
            this.pbErrorContraseña.ImageZoomSize = new System.Drawing.Size(18, 18);
            this.pbErrorContraseña.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbErrorContraseña.InitialImage")));
            this.pbErrorContraseña.Location = new System.Drawing.Point(34, 270);
            this.pbErrorContraseña.Name = "pbErrorContraseña";
            this.pbErrorContraseña.Rotation = 0;
            this.pbErrorContraseña.ShowActiveImage = false;
            this.pbErrorContraseña.ShowCursorChanges = false;
            this.pbErrorContraseña.ShowImageBorders = true;
            this.pbErrorContraseña.ShowSizeMarkers = false;
            this.pbErrorContraseña.Size = new System.Drawing.Size(18, 18);
            this.pbErrorContraseña.TabIndex = 13;
            this.pbErrorContraseña.ToolTipText = "";
            this.pbErrorContraseña.Visible = false;
            this.pbErrorContraseña.WaitOnLoad = false;
            this.pbErrorContraseña.Zoom = 0;
            this.pbErrorContraseña.ZoomSpeed = 10;
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
            // btnMostrarOcultarContraseña
            // 
            this.btnMostrarOcultarContraseña.ActiveImage = null;
            this.btnMostrarOcultarContraseña.AllowAnimations = true;
            this.btnMostrarOcultarContraseña.AllowBuffering = false;
            this.btnMostrarOcultarContraseña.AllowToggling = false;
            this.btnMostrarOcultarContraseña.AllowZooming = false;
            this.btnMostrarOcultarContraseña.AllowZoomingOnFocus = false;
            this.btnMostrarOcultarContraseña.BackColor = System.Drawing.Color.White;
            this.btnMostrarOcultarContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AparicionBienvenida.SetDecoration(this.btnMostrarOcultarContraseña, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnMostrarOcultarContraseña.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMostrarOcultarContraseña.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarOcultarContraseña.ErrorImage")));
            this.btnMostrarOcultarContraseña.FadeWhenInactive = false;
            this.btnMostrarOcultarContraseña.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnMostrarOcultarContraseña.Image = global::CapaPresentaciones.Properties.Resources.Ocultar;
            this.btnMostrarOcultarContraseña.ImageActive = null;
            this.btnMostrarOcultarContraseña.ImageLocation = null;
            this.btnMostrarOcultarContraseña.ImageMargin = 0;
            this.btnMostrarOcultarContraseña.ImageSize = new System.Drawing.Size(25, 25);
            this.btnMostrarOcultarContraseña.ImageZoomSize = new System.Drawing.Size(25, 25);
            this.btnMostrarOcultarContraseña.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnMostrarOcultarContraseña.InitialImage")));
            this.btnMostrarOcultarContraseña.Location = new System.Drawing.Point(329, 232);
            this.btnMostrarOcultarContraseña.Name = "btnMostrarOcultarContraseña";
            this.btnMostrarOcultarContraseña.Rotation = 0;
            this.btnMostrarOcultarContraseña.ShowActiveImage = false;
            this.btnMostrarOcultarContraseña.ShowCursorChanges = false;
            this.btnMostrarOcultarContraseña.ShowImageBorders = true;
            this.btnMostrarOcultarContraseña.ShowSizeMarkers = false;
            this.btnMostrarOcultarContraseña.Size = new System.Drawing.Size(25, 25);
            this.btnMostrarOcultarContraseña.TabIndex = 14;
            this.btnMostrarOcultarContraseña.ToolTipText = "";
            this.btnMostrarOcultarContraseña.WaitOnLoad = false;
            this.btnMostrarOcultarContraseña.Zoom = 0;
            this.btnMostrarOcultarContraseña.ZoomSpeed = 10;
            this.btnMostrarOcultarContraseña.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMostrarOcultarContraseña_MouseDown);
            this.btnMostrarOcultarContraseña.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMostrarOcultarContraseña_MouseUp);
            // 
            // pnBienvenida
            // 
            this.pnBienvenida.BackgroundColor = System.Drawing.Color.White;
            this.pnBienvenida.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnBienvenida.BackgroundImage")));
            this.pnBienvenida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnBienvenida.BorderColor = System.Drawing.Color.Transparent;
            this.pnBienvenida.BorderRadius = 3;
            this.pnBienvenida.BorderThickness = 1;
            this.pnBienvenida.Controls.Add(this.Bienvenida);
            this.AparicionBienvenida.SetDecoration(this.pnBienvenida, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnBienvenida.Location = new System.Drawing.Point(0, 0);
            this.pnBienvenida.Margin = new System.Windows.Forms.Padding(0);
            this.pnBienvenida.Name = "pnBienvenida";
            this.pnBienvenida.ShowBorders = true;
            this.pnBienvenida.Size = new System.Drawing.Size(23, 23);
            this.pnBienvenida.TabIndex = 15;
            this.pnBienvenida.Visible = false;
            // 
            // TiempoDesaparicion
            // 
            this.TiempoDesaparicion.Tick += new System.EventHandler(this.TiempoDesaparicion_Tick);
            // 
            // AparicionBienvenida
            // 
            this.AparicionBienvenida.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.Transparent;
            this.AparicionBienvenida.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.AparicionBienvenida.DefaultAnimation = animation1;
            // 
            // Bienvenida
            // 
            this.Bienvenida.BackColor = System.Drawing.Color.White;
            this.AparicionBienvenida.SetDecoration(this.Bienvenida, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.Bienvenida.Location = new System.Drawing.Point(0, 0);
            this.Bienvenida.Name = "Bienvenida";
            this.Bienvenida.Size = new System.Drawing.Size(1330, 768);
            this.Bienvenida.TabIndex = 0;
            // 
            // P_InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(631, 388);
            this.Controls.Add(this.pnBienvenida);
            this.Controls.Add(this.btnMostrarOcultarContraseña);
            this.Controls.Add(this.pbErrorContraseña);
            this.Controls.Add(this.pbErrorUsuario);
            this.Controls.Add(this.lblErrorContraseña);
            this.Controls.Add(this.lblErrorUsuario);
            this.Controls.Add(this.btnOlvidarContraseña);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnLogo);
            this.AparicionBienvenida.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_InicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión";
            this.pnLogo.ResumeLayout(false);
            this.pnBienvenida.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuTextBox txtUsuario;
        private Bunifu.UI.WinForms.BunifuLabel lblUsuario;
        private Bunifu.UI.WinForms.BunifuTextBox txtContraseña;
        private Bunifu.UI.WinForms.BunifuLabel lblContraseña;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnIngresar;
        private Bunifu.UI.WinForms.BunifuPanel pnLogo;
        private Bunifu.UI.WinForms.BunifuImageButton pbLogo;
        private System.Windows.Forms.LinkLabel btnOlvidarContraseña;
        private Bunifu.UI.WinForms.BunifuLabel lblUniversidad;
        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuLabel lblErrorContraseña;
        private Bunifu.UI.WinForms.BunifuLabel lblErrorUsuario;
        private Bunifu.UI.WinForms.BunifuImageButton pbErrorContraseña;
        private Bunifu.UI.WinForms.BunifuImageButton pbErrorUsuario;
        private Bunifu.UI.WinForms.BunifuFormDock Docker;
        private Bunifu.UI.WinForms.BunifuImageButton btnMostrarOcultarContraseña;
        private Bunifu.UI.WinForms.BunifuPanel pnBienvenida;
        private System.Windows.Forms.Timer TiempoDesaparicion;
        private Bunifu.UI.WinForms.BunifuTransition AparicionBienvenida;
        private ControlesPerzonalizados.C_Bienvenida Bienvenida;
    }
}