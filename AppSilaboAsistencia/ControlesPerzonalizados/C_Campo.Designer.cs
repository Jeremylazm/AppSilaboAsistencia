
namespace ControlesPerzonalizados
{
    partial class C_Campo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_Campo));
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.txtValor = new Bunifu.UI.WinForms.BunifuLabel();
            this.lnValor = new Bunifu.UI.WinForms.BunifuSeparator();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AllowParentOverrides = false;
            this.lblTitulo.AutoEllipsis = false;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTitulo.Location = new System.Drawing.Point(13, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(45, 23);
            this.lblTitulo.TabIndex = 76;
            this.lblTitulo.Text = "Título";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtValor
            // 
            this.txtValor.AllowParentOverrides = false;
            this.txtValor.AutoEllipsis = false;
            this.txtValor.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtValor.CursorType = System.Windows.Forms.Cursors.Default;
            this.txtValor.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.txtValor.Location = new System.Drawing.Point(13, 41);
            this.txtValor.Name = "txtValor";
            this.txtValor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValor.Size = new System.Drawing.Size(43, 22);
            this.txtValor.TabIndex = 78;
            this.txtValor.Text = "Valor";
            this.txtValor.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.txtValor.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lnValor
            // 
            this.lnValor.BackColor = System.Drawing.Color.Transparent;
            this.lnValor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lnValor.BackgroundImage")));
            this.lnValor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lnValor.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.lnValor.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lnValor.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.lnValor.LineThickness = 1;
            this.lnValor.Location = new System.Drawing.Point(13, 65);
            this.lnValor.Name = "lnValor";
            this.lnValor.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.lnValor.Size = new System.Drawing.Size(319, 10);
            this.lnValor.TabIndex = 77;
            // 
            // C_Campo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lnValor);
            this.Controls.Add(this.txtValor);
            this.Name = "C_Campo";
            this.Size = new System.Drawing.Size(346, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuSeparator lnValor;
        public Bunifu.UI.WinForms.BunifuLabel txtValor;
    }
}
