﻿
namespace CapaPresentaciones
{
    partial class P_SeleccionadoAsignaturaAsignada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_SeleccionadoAsignaturaAsignada));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties11 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties12 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.btnCerrar = new Bunifu.UI.WinForms.BunifuImageButton();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.sbDatos = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.dgvDatos = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.txtBuscar = new Bunifu.UI.WinForms.BunifuTextBox();
            this.Movimiento = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
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
            this.btnCerrar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.ErrorImage")));
            this.btnCerrar.FadeWhenInactive = false;
            this.btnCerrar.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnCerrar.Image = global::CapaPresentaciones.Properties.Resources.Cerrar;
            this.btnCerrar.ImageActive = null;
            this.btnCerrar.ImageLocation = null;
            this.btnCerrar.ImageMargin = 10;
            this.btnCerrar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCerrar.ImageZoomSize = new System.Drawing.Size(30, 30);
            this.btnCerrar.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnCerrar.InitialImage")));
            this.btnCerrar.Location = new System.Drawing.Point(845, 7);
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
            this.lblTitulo.Size = new System.Drawing.Size(883, 46);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Text = "Haga doble click para seleccionar una asignatura asignada";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this;
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
            this.sbDatos.Location = new System.Drawing.Point(864, 127);
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
            this.sbDatos.Size = new System.Drawing.Size(10, 315);
            this.sbDatos.SmallChange = 1;
            this.sbDatos.TabIndex = 34;
            this.sbDatos.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.sbDatos.ThumbLength = 30;
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
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dgvDatos.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.dgvDatos.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvDatos.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.dgvDatos.Location = new System.Drawing.Point(9, 101);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 28;
            this.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDatos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.RowTemplate.Height = 26;
            this.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(865, 341);
            this.dgvDatos.TabIndex = 35;
            this.dgvDatos.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Maroon;
            this.dgvDatos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentDoubleClick);
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
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
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
            this.txtBuscar.Location = new System.Drawing.Point(9, 50);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.txtBuscar.MaxLength = 32767;
            this.txtBuscar.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtBuscar.Modified = false;
            this.txtBuscar.Multiline = false;
            this.txtBuscar.Name = "txtBuscar";
            stateProperties9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties9.FillColor = System.Drawing.Color.Empty;
            stateProperties9.ForeColor = System.Drawing.Color.Empty;
            stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscar.OnActiveState = stateProperties9;
            stateProperties10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtBuscar.OnDisabledState = stateProperties10;
            stateProperties11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            stateProperties11.FillColor = System.Drawing.Color.Empty;
            stateProperties11.ForeColor = System.Drawing.Color.Empty;
            stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscar.OnHoverState = stateProperties11;
            stateProperties12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties12.FillColor = System.Drawing.Color.White;
            stateProperties12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtBuscar.OnIdleState = stateProperties12;
            this.txtBuscar.Padding = new System.Windows.Forms.Padding(3);
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txtBuscar.PlaceholderText = "BUSCAR";
            this.txtBuscar.ReadOnly = false;
            this.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.ShortcutsEnabled = true;
            this.txtBuscar.Size = new System.Drawing.Size(865, 40);
            this.txtBuscar.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtBuscar.TabIndex = 33;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscar.TextMarginBottom = 0;
            this.txtBuscar.TextMarginLeft = 7;
            this.txtBuscar.TextMarginTop = 0;
            this.txtBuscar.TextPlaceholder = "BUSCAR";
            this.txtBuscar.UseSystemPasswordChar = false;
            this.txtBuscar.WordWrap = true;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // Movimiento
            // 
            this.Movimiento.Fixed = true;
            this.Movimiento.Horizontal = true;
            this.Movimiento.TargetControl = this.lblTitulo;
            this.Movimiento.Vertical = true;
            // 
            // P_SeleccionadoAsignaturaAsignada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 454);
            this.Controls.Add(this.sbDatos);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_SeleccionadoAsignaturaAsignada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P_SeleccionadoAsignaturaAsignada";
            this.Load += new System.EventHandler(this.P_SeleccionadoAsignaturaAsignada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton btnCerrar;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private Bunifu.UI.WinForms.BunifuVScrollBar sbDatos;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvDatos;
        private Bunifu.UI.WinForms.BunifuTextBox txtBuscar;
        private Bunifu.Framework.UI.BunifuDragControl Movimiento;
    }
}