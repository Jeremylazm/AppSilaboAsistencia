
namespace CapaPresentaciones
{
    partial class P_DialogoAgregarAsistenciaDocente
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_DialogoAgregarAsistenciaDocente));
			Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
			this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
			this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
			this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
			this.lblMotivo = new Bunifu.UI.WinForms.BunifuLabel();
			this.cxtMotivo = new Bunifu.UI.WinForms.BunifuDropdown();
			this.lblFecha = new Bunifu.UI.WinForms.BunifuLabel();
			this.dpFecha = new Bunifu.UI.WinForms.BunifuDatePicker();
			this.btnGuardar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
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
			this.btnCerrar.ImageSize = new System.Drawing.Size(20, 20);
			this.btnCerrar.ImageZoomSize = new System.Drawing.Size(30, 30);
			this.btnCerrar.InitialImage = null;
			this.btnCerrar.Location = new System.Drawing.Point(472, 7);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Rotation = 0;
			this.btnCerrar.ShowActiveImage = true;
			this.btnCerrar.ShowCursorChanges = true;
			this.btnCerrar.ShowImageBorders = true;
			this.btnCerrar.ShowSizeMarkers = false;
			this.btnCerrar.Size = new System.Drawing.Size(30, 30);
			this.btnCerrar.TabIndex = 13;
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
			this.lblTitulo.Size = new System.Drawing.Size(510, 46);
			this.lblTitulo.TabIndex = 12;
			this.lblTitulo.Text = "AGREGAR - Feriados o Suspensiones";
			this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			// 
			// Bordeado
			// 
			this.Bordeado.ElipseRadius = 15;
			this.Bordeado.TargetControl = this;
			// 
			// lblMotivo
			// 
			this.lblMotivo.AllowParentOverrides = false;
			this.lblMotivo.AutoEllipsis = false;
			this.lblMotivo.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblMotivo.CursorType = System.Windows.Forms.Cursors.Default;
			this.lblMotivo.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.lblMotivo.Location = new System.Drawing.Point(23, 65);
			this.lblMotivo.Name = "lblMotivo";
			this.lblMotivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblMotivo.Size = new System.Drawing.Size(59, 23);
			this.lblMotivo.TabIndex = 58;
			this.lblMotivo.Text = "Motivo";
			this.lblMotivo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMotivo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			// 
			// cxtMotivo
			// 
			this.cxtMotivo.BackColor = System.Drawing.Color.Transparent;
			this.cxtMotivo.BackgroundColor = System.Drawing.Color.White;
			this.cxtMotivo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.cxtMotivo.BorderRadius = 1;
			this.cxtMotivo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.cxtMotivo.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
			this.cxtMotivo.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.cxtMotivo.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.cxtMotivo.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.cxtMotivo.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.cxtMotivo.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
			this.cxtMotivo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cxtMotivo.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
			this.cxtMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cxtMotivo.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
			this.cxtMotivo.FillDropDown = true;
			this.cxtMotivo.FillIndicator = true;
			this.cxtMotivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cxtMotivo.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cxtMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.cxtMotivo.FormattingEnabled = true;
			this.cxtMotivo.Icon = null;
			this.cxtMotivo.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
			this.cxtMotivo.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.cxtMotivo.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
			this.cxtMotivo.IndicatorThickness = 2;
			this.cxtMotivo.IsDropdownOpened = false;
			this.cxtMotivo.ItemBackColor = System.Drawing.Color.White;
			this.cxtMotivo.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.cxtMotivo.ItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.cxtMotivo.ItemHeight = 26;
			this.cxtMotivo.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
			this.cxtMotivo.ItemHighLightForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.cxtMotivo.Items.AddRange(new object[] {
            "FERIADO",
            "SUSPENSION"});
			this.cxtMotivo.ItemTopMargin = 3;
			this.cxtMotivo.Location = new System.Drawing.Point(23, 96);
			this.cxtMotivo.Name = "cxtMotivo";
			this.cxtMotivo.Size = new System.Drawing.Size(156, 32);
			this.cxtMotivo.TabIndex = 57;
			this.cxtMotivo.Text = null;
			this.cxtMotivo.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
			this.cxtMotivo.TextLeftMargin = 5;
			// 
			// lblFecha
			// 
			this.lblFecha.AllowParentOverrides = false;
			this.lblFecha.AutoEllipsis = false;
			this.lblFecha.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblFecha.CursorType = System.Windows.Forms.Cursors.Default;
			this.lblFecha.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.lblFecha.Location = new System.Drawing.Point(216, 65);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblFecha.Size = new System.Drawing.Size(51, 23);
			this.lblFecha.TabIndex = 62;
			this.lblFecha.Text = "Fecha";
			this.lblFecha.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblFecha.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
			// 
			// dpFecha
			// 
			this.dpFecha.BackColor = System.Drawing.Color.Transparent;
			this.dpFecha.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.dpFecha.BorderRadius = 1;
			this.dpFecha.CalendarFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dpFecha.CalendarTitleBackColor = System.Drawing.Color.Aqua;
			this.dpFecha.CalendarTitleForeColor = System.Drawing.Color.BlueViolet;
			this.dpFecha.Color = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.dpFecha.CustomFormat = "dddd, dd / MM / yyyy";
			this.dpFecha.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
			this.dpFecha.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Right;
			this.dpFecha.DisabledColor = System.Drawing.Color.Gray;
			this.dpFecha.DisplayWeekNumbers = false;
			this.dpFecha.DPHeight = 0;
			this.dpFecha.FillDatePicker = false;
			this.dpFecha.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dpFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dpFecha.Icon = ((System.Drawing.Image)(resources.GetObject("dpFecha.Icon")));
			this.dpFecha.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
			this.dpFecha.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Left;
			this.dpFecha.LeftTextMargin = 0;
			this.dpFecha.Location = new System.Drawing.Point(216, 96);
			this.dpFecha.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
			this.dpFecha.MinimumSize = new System.Drawing.Size(4, 32);
			this.dpFecha.Name = "dpFecha";
			this.dpFecha.Size = new System.Drawing.Size(270, 32);
			this.dpFecha.TabIndex = 63;
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
			borderEdges1.BottomLeft = true;
			borderEdges1.BottomRight = true;
			borderEdges1.TopLeft = true;
			borderEdges1.TopRight = true;
			this.btnGuardar.CustomizableEdges = borderEdges1;
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
			this.btnGuardar.Location = new System.Drawing.Point(176, 151);
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
			this.btnGuardar.Size = new System.Drawing.Size(170, 39);
			this.btnGuardar.TabIndex = 64;
			this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnGuardar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.btnGuardar.TextMarginLeft = 0;
			this.btnGuardar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.btnGuardar.UseDefaultRadiusAndThickness = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// P_DialogoAgregarAsistenciaDocente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(510, 207);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.lblFecha);
			this.Controls.Add(this.dpFecha);
			this.Controls.Add(this.lblMotivo);
			this.Controls.Add(this.cxtMotivo);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.lblTitulo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "P_DialogoAgregarAsistenciaDocente";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "P_SeleccionadoAsignaturaAsignada";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.UI.WinForms.BunifuLabel lblMotivo;
        public Bunifu.UI.WinForms.BunifuDropdown cxtMotivo;
        private Bunifu.UI.WinForms.BunifuLabel lblFecha;
        private Bunifu.UI.WinForms.BunifuDatePicker dpFecha;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnGuardar;
    }
}