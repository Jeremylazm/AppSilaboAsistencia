
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_SubirArchivo));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnContenedor = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnSubir = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnBuscarArchivo = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
            this.txtRuta = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Movimiento = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnContenedor.SuspendLayout();
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
            // pnContenedor
            // 
            this.pnContenedor.BackgroundColor = System.Drawing.Color.White;
            this.pnContenedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnContenedor.BackgroundImage")));
            this.pnContenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnContenedor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.pnContenedor.BorderRadius = 20;
            this.pnContenedor.BorderThickness = 1;
            this.pnContenedor.Controls.Add(this.btnSubir);
            this.pnContenedor.Controls.Add(this.btnBuscarArchivo);
            this.pnContenedor.Controls.Add(this.txtRuta);
            this.pnContenedor.Controls.Add(this.btnCerrar);
            this.pnContenedor.Controls.Add(this.lblTitulo);
            this.pnContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnContenedor.Name = "pnContenedor";
            this.pnContenedor.ShowBorders = true;
            this.pnContenedor.Size = new System.Drawing.Size(808, 199);
            this.pnContenedor.TabIndex = 20;
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
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSubir.CustomizableEdges = borderEdges1;
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
            this.btnSubir.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Ingresar;
            this.btnSubir.IdleIconRightImage = null;
            this.btnSubir.IndicateFocus = false;
            this.btnSubir.Location = new System.Drawing.Point(607, 138);
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
            this.btnSubir.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Ingresar_2;
            this.btnSubir.onHoverState.IconRightImage = null;
            this.btnSubir.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.OnIdleState.BorderRadius = 15;
            this.btnSubir.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSubir.OnIdleState.BorderThickness = 1;
            this.btnSubir.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnSubir.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Ingresar;
            this.btnSubir.OnIdleState.IconRightImage = null;
            this.btnSubir.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.OnPressedState.BorderRadius = 15;
            this.btnSubir.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSubir.OnPressedState.BorderThickness = 1;
            this.btnSubir.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnSubir.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnSubir.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Ingresar;
            this.btnSubir.OnPressedState.IconRightImage = null;
            this.btnSubir.Size = new System.Drawing.Size(170, 39);
            this.btnSubir.TabIndex = 30;
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
            this.btnBuscarArchivo.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarArchivo.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarArchivo.BorderRadius = 1;
            this.btnBuscarArchivo.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
            this.btnBuscarArchivo.BorderThickness = 1;
            this.btnBuscarArchivo.ColorContrastOnClick = 30;
            this.btnBuscarArchivo.ColorContrastOnHover = 30;
            this.btnBuscarArchivo.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnBuscarArchivo.CustomizableEdges = borderEdges2;
            this.btnBuscarArchivo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBuscarArchivo.Image = global::CapaPresentaciones.Properties.Resources.buscar_archivo;
            this.btnBuscarArchivo.ImageMargin = new System.Windows.Forms.Padding(0);
            this.btnBuscarArchivo.Location = new System.Drawing.Point(737, 81);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.RoundBorders = true;
            this.btnBuscarArchivo.ShowBorders = true;
            this.btnBuscarArchivo.Size = new System.Drawing.Size(35, 35);
            this.btnBuscarArchivo.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Round;
            this.btnBuscarArchivo.TabIndex = 14;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.AcceptsReturn = false;
            this.txtRuta.AcceptsTab = false;
            this.txtRuta.AnimationSpeed = 200;
            this.txtRuta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRuta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRuta.AutoSizeHeight = true;
            this.txtRuta.BackColor = System.Drawing.Color.Transparent;
            this.txtRuta.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtRuta.BackgroundImage")));
            this.txtRuta.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtRuta.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtRuta.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtRuta.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtRuta.BorderRadius = 1;
            this.txtRuta.BorderThickness = 1;
            this.txtRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRuta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.DefaultFont = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.DefaultText = "";
            this.txtRuta.FillColor = System.Drawing.Color.White;
            this.txtRuta.HideSelection = true;
            this.txtRuta.IconLeft = null;
            this.txtRuta.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.IconPadding = 10;
            this.txtRuta.IconRight = null;
            this.txtRuta.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.Lines = new string[0];
            this.txtRuta.Location = new System.Drawing.Point(12, 75);
            this.txtRuta.MaxLength = 32767;
            this.txtRuta.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtRuta.Modified = false;
            this.txtRuta.Multiline = false;
            this.txtRuta.Name = "txtRuta";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtRuta.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtRuta.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtRuta.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtRuta.OnIdleState = stateProperties4;
            this.txtRuta.Padding = new System.Windows.Forms.Padding(3);
            this.txtRuta.PasswordChar = '\0';
            this.txtRuta.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtRuta.PlaceholderText = "Ruta del archivo";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRuta.SelectedText = "";
            this.txtRuta.SelectionLength = 0;
            this.txtRuta.SelectionStart = 0;
            this.txtRuta.ShortcutsEnabled = true;
            this.txtRuta.Size = new System.Drawing.Size(765, 45);
            this.txtRuta.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtRuta.TabIndex = 12;
            this.txtRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRuta.TextMarginBottom = 0;
            this.txtRuta.TextMarginLeft = 3;
            this.txtRuta.TextMarginTop = 1;
            this.txtRuta.TextPlaceholder = "Ruta del archivo";
            this.txtRuta.UseSystemPasswordChar = false;
            this.txtRuta.WordWrap = true;
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
            this.btnCerrar.Location = new System.Drawing.Point(770, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0;
            this.btnCerrar.ShowActiveImage = true;
            this.btnCerrar.ShowCursorChanges = true;
            this.btnCerrar.ShowImageBorders = true;
            this.btnCerrar.ShowSizeMarkers = false;
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 11;
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
            this.lblTitulo.Size = new System.Drawing.Size(808, 46);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Subir";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Movimiento
            // 
            this.Movimiento.Fixed = true;
            this.Movimiento.Horizontal = true;
            this.Movimiento.TargetControl = this.lblTitulo;
            this.Movimiento.Vertical = true;
            // 
            // P_SubirArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 199);
            this.Controls.Add(this.pnContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_SubirArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P_SubirSilabo";
            this.pnContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Bunifu.UI.WinForms.BunifuPanel pnContenedor;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnSubir;
        private Bunifu.UI.WinForms.BunifuButton.BunifuIconButton btnBuscarArchivo;
        private Bunifu.UI.WinForms.BunifuTextBox txtRuta;
        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.Framework.UI.BunifuDragControl Movimiento;
    }
}