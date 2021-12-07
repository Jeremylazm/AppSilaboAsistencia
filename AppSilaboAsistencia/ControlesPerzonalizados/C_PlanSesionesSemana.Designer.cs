
namespace ControlesPerzonalizados
{
    partial class C_PlanSesionesSemana
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_PlanSesionesSemana));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnContenedor = new Bunifu.UI.WinForms.BunifuPanel();
            this.sbDatos = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDataGridView1 = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.txtSesion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckbTema = new System.Windows.Forms.DataGridViewImageColumn();
            this.ListaImagenes = new System.Windows.Forms.ImageList(this.components);
            this.pnContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).BeginInit();
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
            this.pnContenedor.Controls.Add(this.sbDatos);
            this.pnContenedor.Controls.Add(this.bunifuDataGridView1);
            this.pnContenedor.Controls.Add(this.lblTitulo);
            this.pnContenedor.Location = new System.Drawing.Point(1, 2);
            this.pnContenedor.Name = "pnContenedor";
            this.pnContenedor.ShowBorders = true;
            this.pnContenedor.Size = new System.Drawing.Size(719, 144);
            this.pnContenedor.TabIndex = 19;
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
            this.sbDatos.Location = new System.Drawing.Point(701, 63);
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
            this.sbDatos.Size = new System.Drawing.Size(10, 69);
            this.sbDatos.SmallChange = 1;
            this.sbDatos.TabIndex = 31;
            this.sbDatos.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.sbDatos.ThumbLength = 18;
            this.sbDatos.ThumbMargin = 1;
            this.sbDatos.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.sbDatos.Value = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AllowParentOverrides = false;
            this.lblTitulo.AutoEllipsis = false;
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTitulo.Location = new System.Drawing.Point(615, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(70, 25);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Semana ";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this.pnContenedor;
            // 
            // bunifuDataGridView1
            // 
            this.bunifuDataGridView1.AllowCustomTheming = true;
            this.bunifuDataGridView1.AllowUserToAddRows = false;
            this.bunifuDataGridView1.AllowUserToDeleteRows = false;
            this.bunifuDataGridView1.AllowUserToOrderColumns = true;
            this.bunifuDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.bunifuDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuDataGridView1.ColumnHeadersHeight = 28;
            this.bunifuDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bunifuDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSesion,
            this.txtTema,
            this.ckbTema});
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.CurrentTheme.Name = null;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuDataGridView1.EnableHeadersVisualStyles = false;
            this.bunifuDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.bunifuDataGridView1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.bunifuDataGridView1.HeaderBgColor = System.Drawing.Color.Empty;
            this.bunifuDataGridView1.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.bunifuDataGridView1.Location = new System.Drawing.Point(13, 35);
            this.bunifuDataGridView1.MultiSelect = false;
            this.bunifuDataGridView1.Name = "bunifuDataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.bunifuDataGridView1.RowHeadersVisible = false;
            this.bunifuDataGridView1.RowHeadersWidth = 28;
            this.bunifuDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.bunifuDataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDataGridView1.RowTemplate.Height = 26;
            this.bunifuDataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bunifuDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuDataGridView1.Size = new System.Drawing.Size(698, 97);
            this.bunifuDataGridView1.TabIndex = 36;
            this.bunifuDataGridView1.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Maroon;
            // 
            // txtSesion
            // 
            this.txtSesion.HeaderText = "Sesión";
            this.txtSesion.Name = "txtSesion";
            this.txtSesion.ReadOnly = true;
            // 
            // txtTema
            // 
            this.txtTema.HeaderText = "Tema";
            this.txtTema.Name = "txtTema";
            this.txtTema.ReadOnly = true;
            // 
            // ckbTema
            // 
            this.ckbTema.HeaderText = "Seleccionar";
            this.ckbTema.Image = global::ControlesPerzonalizados.Properties.Resources.Unchecked_16x16;
            this.ckbTema.Name = "ckbTema";
            // 
            // ListaImagenes
            // 
            this.ListaImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ListaImagenes.ImageSize = new System.Drawing.Size(18, 18);
            this.ListaImagenes.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // C_PlanSesionesSemana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnContenedor);
            this.Name = "C_PlanSesionesSemana";
            this.Size = new System.Drawing.Size(721, 148);
            this.pnContenedor.ResumeLayout(false);
            this.pnContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel pnContenedor;
        private Bunifu.UI.WinForms.BunifuVScrollBar sbDatos;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        public Bunifu.UI.WinForms.BunifuDataGridView bunifuDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTema;
        private System.Windows.Forms.DataGridViewImageColumn ckbTema;
        private System.Windows.Forms.ImageList ListaImagenes;
    }
}
