
namespace CapaPresentaciones
{
    partial class P_ReporteDocente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_ReporteDocente));
            this.pnContenedor = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.cxtTipoReporte = new Bunifu.UI.WinForms.BunifuDropdown();
            this.lblTipoReporte = new Bunifu.UI.WinForms.BunifuLabel();
            this.cxtCriterioSeleccion = new Bunifu.UI.WinForms.BunifuDropdown();
            this.lblCriterioSeleccion = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblFechaInicial = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblFechaFinal = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.pnContenedor.SuspendLayout();
            this.SuspendLayout();
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
            this.pnContenedor.Controls.Add(this.bunifuDatePicker1);
            this.pnContenedor.Controls.Add(this.lblFechaFinal);
            this.pnContenedor.Controls.Add(this.lblFechaInicial);
            this.pnContenedor.Controls.Add(this.cxtCriterioSeleccion);
            this.pnContenedor.Controls.Add(this.lblCriterioSeleccion);
            this.pnContenedor.Controls.Add(this.cxtTipoReporte);
            this.pnContenedor.Controls.Add(this.lblTipoReporte);
            this.pnContenedor.Controls.Add(this.btnCerrar);
            this.pnContenedor.Controls.Add(this.lblTitulo);
            this.pnContenedor.Location = new System.Drawing.Point(5, 5);
            this.pnContenedor.Name = "pnContenedor";
            this.pnContenedor.ShowBorders = true;
            this.pnContenedor.Size = new System.Drawing.Size(1090, 660);
            this.pnContenedor.TabIndex = 19;
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
            this.btnCerrar.Location = new System.Drawing.Point(1052, 7);
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
            this.lblTitulo.Size = new System.Drawing.Size(1090, 46);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Reportes";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this.pnContenedor;
            // 
            // cxtTipoReporte
            // 
            this.cxtTipoReporte.BackColor = System.Drawing.Color.Transparent;
            this.cxtTipoReporte.BackgroundColor = System.Drawing.Color.White;
            this.cxtTipoReporte.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtTipoReporte.BorderRadius = 1;
            this.cxtTipoReporte.Color = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtTipoReporte.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cxtTipoReporte.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cxtTipoReporte.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cxtTipoReporte.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cxtTipoReporte.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cxtTipoReporte.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cxtTipoReporte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cxtTipoReporte.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cxtTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cxtTipoReporte.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cxtTipoReporte.FillDropDown = true;
            this.cxtTipoReporte.FillIndicator = true;
            this.cxtTipoReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cxtTipoReporte.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxtTipoReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtTipoReporte.FormattingEnabled = true;
            this.cxtTipoReporte.Icon = null;
            this.cxtTipoReporte.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cxtTipoReporte.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtTipoReporte.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cxtTipoReporte.IndicatorThickness = 2;
            this.cxtTipoReporte.IsDropdownOpened = false;
            this.cxtTipoReporte.ItemBackColor = System.Drawing.Color.White;
            this.cxtTipoReporte.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtTipoReporte.ItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtTipoReporte.ItemHeight = 26;
            this.cxtTipoReporte.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.cxtTipoReporte.ItemHighLightForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtTipoReporte.Items.AddRange(new object[] {
            "NOMBRADO",
            "CONTRATADO"});
            this.cxtTipoReporte.ItemTopMargin = 3;
            this.cxtTipoReporte.Location = new System.Drawing.Point(15, 86);
            this.cxtTipoReporte.Name = "cxtTipoReporte";
            this.cxtTipoReporte.Size = new System.Drawing.Size(232, 32);
            this.cxtTipoReporte.TabIndex = 55;
            this.cxtTipoReporte.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cxtTipoReporte.TextLeftMargin = 5;
            // 
            // lblTipoReporte
            // 
            this.lblTipoReporte.AllowParentOverrides = false;
            this.lblTipoReporte.AutoEllipsis = false;
            this.lblTipoReporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTipoReporte.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblTipoReporte.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTipoReporte.Location = new System.Drawing.Point(15, 52);
            this.lblTipoReporte.Name = "lblTipoReporte";
            this.lblTipoReporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTipoReporte.Size = new System.Drawing.Size(128, 23);
            this.lblTipoReporte.TabIndex = 56;
            this.lblTipoReporte.Text = "Tipo de Reporte";
            this.lblTipoReporte.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTipoReporte.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cxtCriterioSeleccion
            // 
            this.cxtCriterioSeleccion.BackColor = System.Drawing.Color.Transparent;
            this.cxtCriterioSeleccion.BackgroundColor = System.Drawing.Color.White;
            this.cxtCriterioSeleccion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtCriterioSeleccion.BorderRadius = 1;
            this.cxtCriterioSeleccion.Color = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtCriterioSeleccion.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cxtCriterioSeleccion.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cxtCriterioSeleccion.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cxtCriterioSeleccion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cxtCriterioSeleccion.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cxtCriterioSeleccion.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cxtCriterioSeleccion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cxtCriterioSeleccion.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cxtCriterioSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cxtCriterioSeleccion.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cxtCriterioSeleccion.FillDropDown = true;
            this.cxtCriterioSeleccion.FillIndicator = true;
            this.cxtCriterioSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cxtCriterioSeleccion.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cxtCriterioSeleccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtCriterioSeleccion.FormattingEnabled = true;
            this.cxtCriterioSeleccion.Icon = null;
            this.cxtCriterioSeleccion.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cxtCriterioSeleccion.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtCriterioSeleccion.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cxtCriterioSeleccion.IndicatorThickness = 2;
            this.cxtCriterioSeleccion.IsDropdownOpened = false;
            this.cxtCriterioSeleccion.ItemBackColor = System.Drawing.Color.White;
            this.cxtCriterioSeleccion.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtCriterioSeleccion.ItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtCriterioSeleccion.ItemHeight = 26;
            this.cxtCriterioSeleccion.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.cxtCriterioSeleccion.ItemHighLightForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.cxtCriterioSeleccion.Items.AddRange(new object[] {
            "NOMBRADO",
            "CONTRATADO"});
            this.cxtCriterioSeleccion.ItemTopMargin = 3;
            this.cxtCriterioSeleccion.Location = new System.Drawing.Point(271, 86);
            this.cxtCriterioSeleccion.Name = "cxtCriterioSeleccion";
            this.cxtCriterioSeleccion.Size = new System.Drawing.Size(232, 32);
            this.cxtCriterioSeleccion.TabIndex = 57;
            this.cxtCriterioSeleccion.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cxtCriterioSeleccion.TextLeftMargin = 5;
            // 
            // lblCriterioSeleccion
            // 
            this.lblCriterioSeleccion.AllowParentOverrides = false;
            this.lblCriterioSeleccion.AutoEllipsis = false;
            this.lblCriterioSeleccion.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCriterioSeleccion.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblCriterioSeleccion.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriterioSeleccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblCriterioSeleccion.Location = new System.Drawing.Point(271, 52);
            this.lblCriterioSeleccion.Name = "lblCriterioSeleccion";
            this.lblCriterioSeleccion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCriterioSeleccion.Size = new System.Drawing.Size(165, 23);
            this.lblCriterioSeleccion.TabIndex = 58;
            this.lblCriterioSeleccion.Text = "Criterio de Selección";
            this.lblCriterioSeleccion.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCriterioSeleccion.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AllowParentOverrides = false;
            this.lblFechaInicial.AutoEllipsis = false;
            this.lblFechaInicial.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFechaInicial.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblFechaInicial.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblFechaInicial.Location = new System.Drawing.Point(524, 52);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFechaInicial.Size = new System.Drawing.Size(106, 23);
            this.lblFechaInicial.TabIndex = 59;
            this.lblFechaInicial.Text = "Fecha Inicial";
            this.lblFechaInicial.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFechaInicial.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AllowParentOverrides = false;
            this.lblFechaFinal.AutoEllipsis = false;
            this.lblFechaFinal.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFechaFinal.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblFechaFinal.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblFechaFinal.Location = new System.Drawing.Point(700, 52);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFechaFinal.Size = new System.Drawing.Size(96, 23);
            this.lblFechaFinal.TabIndex = 60;
            this.lblFechaFinal.Text = "Fecha Final";
            this.lblFechaFinal.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFechaFinal.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuDatePicker1
            // 
            this.bunifuDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDatePicker1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDatePicker1.BorderRadius = 1;
            this.bunifuDatePicker1.CalendarFont = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDatePicker1.CalendarTitleBackColor = System.Drawing.Color.Aqua;
            this.bunifuDatePicker1.CalendarTitleForeColor = System.Drawing.Color.BlueViolet;
            this.bunifuDatePicker1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDatePicker1.CustomFormat = "dd / MM / yyyy";
            this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Right;
            this.bunifuDatePicker1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.DisplayWeekNumbers = false;
            this.bunifuDatePicker1.DPHeight = 0;
            this.bunifuDatePicker1.FillDatePicker = false;
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDatePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Left;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(524, 86);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(0, 32);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(144, 32);
            this.bunifuDatePicker1.TabIndex = 61;
            // 
            // P_ReporteDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 670);
            this.Controls.Add(this.pnContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_ReporteDocente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P_ReporteDocente";
            this.pnContenedor.ResumeLayout(false);
            this.pnContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel pnContenedor;
        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker1;
        private Bunifu.UI.WinForms.BunifuLabel lblFechaFinal;
        private Bunifu.UI.WinForms.BunifuLabel lblFechaInicial;
        public Bunifu.UI.WinForms.BunifuDropdown cxtCriterioSeleccion;
        private Bunifu.UI.WinForms.BunifuLabel lblCriterioSeleccion;
        public Bunifu.UI.WinForms.BunifuDropdown cxtTipoReporte;
        private Bunifu.UI.WinForms.BunifuLabel lblTipoReporte;
    }
}