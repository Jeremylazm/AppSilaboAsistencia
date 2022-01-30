
namespace CapaPresentaciones
{
    partial class P_SubirArchivo
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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_SubirArchivo));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties11 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties12 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSubir = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnBuscarArchivo = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Docker = new Bunifu.UI.WinForms.BunifuFormDock();
            this.txtRuta = new Bunifu.UI.WinForms.BunifuTextBox();
            this.SuspendLayout();
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
            // 
            // btnSubir
            // 
            this.btnSubir.AllowAnimations = true;
            this.btnSubir.AllowMouseEffects = true;
            this.btnSubir.AllowToggling = false;
            this.btnSubir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubir.AnimationSpeed = 200;
            this.btnSubir.AutoGenerateColors = false;
            this.btnSubir.AutoRoundBorders = false;
            this.btnSubir.AutoSizeLeftIcon = true;
            this.btnSubir.AutoSizeRightIcon = true;
            this.btnSubir.BackColor = System.Drawing.Color.Transparent;
            this.btnSubir.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnSubir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubir.BackgroundImage")));
            this.btnSubir.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSubir.ButtonText = "Subir";
            this.btnSubir.ButtonTextMarginLeft = 0;
            this.btnSubir.ColorContrastOnClick = 45;
            this.btnSubir.ColorContrastOnHover = 45;
            this.btnSubir.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.btnSubir.CustomizableEdges = borderEdges6;
            this.btnSubir.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSubir.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSubir.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSubir.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSubir.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnSubir.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubir.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSubir.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSubir.IconMarginLeft = 11;
            this.btnSubir.IconPadding = 10;
            this.btnSubir.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubir.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSubir.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSubir.IconSize = 25;
            this.btnSubir.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.IdleBorderRadius = 15;
            this.btnSubir.IdleBorderThickness = 1;
            this.btnSubir.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnSubir.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Subir;
            this.btnSubir.IdleIconRightImage = null;
            this.btnSubir.IndicateFocus = false;
            this.btnSubir.Location = new System.Drawing.Point(747, 66);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSubir.OnDisabledState.BorderRadius = 15;
            this.btnSubir.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSubir.OnDisabledState.BorderThickness = 1;
            this.btnSubir.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSubir.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSubir.OnDisabledState.IconLeftImage = null;
            this.btnSubir.OnDisabledState.IconRightImage = null;
            this.btnSubir.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnSubir.onHoverState.BorderRadius = 15;
            this.btnSubir.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSubir.onHoverState.BorderThickness = 1;
            this.btnSubir.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnSubir.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Subir_2;
            this.btnSubir.onHoverState.IconRightImage = null;
            this.btnSubir.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.OnIdleState.BorderRadius = 15;
            this.btnSubir.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSubir.OnIdleState.BorderThickness = 1;
            this.btnSubir.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnSubir.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Subir;
            this.btnSubir.OnIdleState.IconRightImage = null;
            this.btnSubir.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.OnPressedState.BorderRadius = 15;
            this.btnSubir.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSubir.OnPressedState.BorderThickness = 1;
            this.btnSubir.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnSubir.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Subir;
            this.btnSubir.OnPressedState.IconRightImage = null;
            this.btnSubir.Size = new System.Drawing.Size(170, 39);
            this.btnSubir.TabIndex = 35;
            this.btnSubir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSubir.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSubir.TextMarginLeft = 0;
            this.btnSubir.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSubir.UseDefaultRadiusAndThickness = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.AllowAnimations = true;
            this.btnBuscarArchivo.AllowBorderColorChanges = true;
            this.btnBuscarArchivo.AllowMouseEffects = true;
            this.btnBuscarArchivo.AnimationSpeed = 200;
            this.btnBuscarArchivo.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarArchivo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnBuscarArchivo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnBuscarArchivo.BorderRadius = 1;
            this.btnBuscarArchivo.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
            this.btnBuscarArchivo.BorderThickness = 1;
            this.btnBuscarArchivo.ColorContrastOnClick = 30;
            this.btnBuscarArchivo.ColorContrastOnHover = 30;
            this.btnBuscarArchivo.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.btnBuscarArchivo.CustomizableEdges = borderEdges5;
            this.btnBuscarArchivo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBuscarArchivo.Image = global::CapaPresentaciones.Properties.Resources.Buscar_Archivo;
            this.btnBuscarArchivo.ImageMargin = new System.Windows.Forms.Padding(0);
            this.btnBuscarArchivo.Location = new System.Drawing.Point(681, 68);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.RoundBorders = true;
            this.btnBuscarArchivo.ShowBorders = true;
            this.btnBuscarArchivo.Size = new System.Drawing.Size(35, 35);
            this.btnBuscarArchivo.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Round;
            this.btnBuscarArchivo.TabIndex = 34;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
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
            this.btnCerrar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCerrar.ImageZoomSize = new System.Drawing.Size(30, 30);
            this.btnCerrar.InitialImage = null;
            this.btnCerrar.Location = new System.Drawing.Point(898, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0;
            this.btnCerrar.ShowActiveImage = true;
            this.btnCerrar.ShowCursorChanges = true;
            this.btnCerrar.ShowImageBorders = true;
            this.btnCerrar.ShowSizeMarkers = false;
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 32;
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
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(940, 46);
            this.lblTitulo.TabIndex = 31;
            this.lblTitulo.Text = "Subir Archivo";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
            // txtRuta
            // 
            this.txtRuta.AcceptsReturn = false;
            this.txtRuta.AcceptsTab = false;
            this.txtRuta.AnimationSpeed = 200;
            this.txtRuta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRuta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRuta.AutoSizeHeight = true;
            this.txtRuta.BackColor = System.Drawing.Color.White;
            this.txtRuta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtRuta.BackgroundImage")));
            this.txtRuta.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtRuta.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtRuta.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.txtRuta.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtRuta.BorderRadius = 15;
            this.txtRuta.BorderThickness = 1;
            this.txtRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRuta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.DefaultFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.DefaultText = "";
            this.txtRuta.FillColor = System.Drawing.Color.White;
            this.txtRuta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtRuta.HideSelection = true;
            this.txtRuta.IconLeft = null;
            this.txtRuta.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.IconPadding = 10;
            this.txtRuta.IconRight = null;
            this.txtRuta.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRuta.Lines = new string[0];
            this.txtRuta.Location = new System.Drawing.Point(20, 64);
            this.txtRuta.Margin = new System.Windows.Forms.Padding(0);
            this.txtRuta.MaxLength = 32767;
            this.txtRuta.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRuta.Modified = false;
            this.txtRuta.Multiline = false;
            this.txtRuta.Name = "txtRuta";
            stateProperties9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties9.FillColor = System.Drawing.Color.Empty;
            stateProperties9.ForeColor = System.Drawing.Color.Empty;
            stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtRuta.OnActiveState = stateProperties9;
            stateProperties10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtRuta.OnDisabledState = stateProperties10;
            stateProperties11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties11.FillColor = System.Drawing.Color.Empty;
            stateProperties11.ForeColor = System.Drawing.Color.Empty;
            stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtRuta.OnHoverState = stateProperties11;
            stateProperties12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties12.FillColor = System.Drawing.Color.White;
            stateProperties12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtRuta.OnIdleState = stateProperties12;
            this.txtRuta.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtRuta.PasswordChar = '\0';
            this.txtRuta.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtRuta.PlaceholderText = "Ruta del archivo";
            this.txtRuta.ReadOnly = false;
            this.txtRuta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRuta.SelectedText = "";
            this.txtRuta.SelectionLength = 0;
            this.txtRuta.SelectionStart = 0;
            this.txtRuta.ShortcutsEnabled = true;
            this.txtRuta.Size = new System.Drawing.Size(702, 44);
            this.txtRuta.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtRuta.TabIndex = 36;
            this.txtRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRuta.TextMarginBottom = 0;
            this.txtRuta.TextMarginLeft = 0;
            this.txtRuta.TextMarginTop = 0;
            this.txtRuta.TextPlaceholder = "Ruta del archivo";
            this.txtRuta.UseSystemPasswordChar = false;
            this.txtRuta.WordWrap = true;
            // 
            // P_SubirArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(940, 127);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_SubirArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P_SubirSilabo";
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnSubir;
        private Bunifu.UI.WinForms.BunifuButton.BunifuIconButton btnBuscarArchivo;
        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuFormDock Docker;
        public Bunifu.UI.WinForms.BunifuTextBox txtRuta;
    }
}