﻿
namespace Ayudas
{
    partial class A_DialogoRespuesta1
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
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation1 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_DialogoRespuesta1));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.AparicionFormulario = new System.Windows.Forms.Timer(this.components);
            this.AparicionImagen = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.btnAceptar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.lblMensaje = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.Docker = new Bunifu.UI.WinForms.BunifuFormDock();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // Bordeado
            // 
            this.Bordeado.ElipseRadius = 15;
            this.Bordeado.TargetControl = this;
            // 
            // AparicionFormulario
            // 
            this.AparicionFormulario.Tick += new System.EventHandler(this.FormAparicion_Tick);
            // 
            // AparicionImagen
            // 
            this.AparicionImagen.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.ScaleAndRotate;
            this.AparicionImagen.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0.5F;
            animation1.RotateLimit = 0.2F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.AparicionImagen.DefaultAnimation = animation1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AllowAnimations = true;
            this.btnAceptar.AllowMouseEffects = true;
            this.btnAceptar.AllowToggling = false;
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAceptar.AnimationSpeed = 200;
            this.btnAceptar.AutoGenerateColors = false;
            this.btnAceptar.AutoRoundBorders = false;
            this.btnAceptar.AutoSizeLeftIcon = true;
            this.btnAceptar.AutoSizeRightIcon = true;
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAceptar.BackgroundImage")));
            this.btnAceptar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.ButtonText = "Aceptar";
            this.btnAceptar.ButtonTextMarginLeft = 0;
            this.btnAceptar.ColorContrastOnClick = 45;
            this.btnAceptar.ColorContrastOnHover = 45;
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAceptar.CustomizableEdges = borderEdges1;
            this.AparicionImagen.SetDecoration(this.btnAceptar, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAceptar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAceptar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAceptar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAceptar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnAceptar.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAceptar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAceptar.IconMarginLeft = 11;
            this.btnAceptar.IconPadding = 10;
            this.btnAceptar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAceptar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAceptar.IconSize = 25;
            this.btnAceptar.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.IdleBorderRadius = 15;
            this.btnAceptar.IdleBorderThickness = 1;
            this.btnAceptar.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.IdleIconLeftImage = null;
            this.btnAceptar.IdleIconRightImage = null;
            this.btnAceptar.IndicateFocus = false;
            this.btnAceptar.Location = new System.Drawing.Point(133, 324);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAceptar.OnDisabledState.BorderRadius = 15;
            this.btnAceptar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.OnDisabledState.BorderThickness = 1;
            this.btnAceptar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAceptar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAceptar.OnDisabledState.IconLeftImage = null;
            this.btnAceptar.OnDisabledState.IconRightImage = null;
            this.btnAceptar.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.onHoverState.BorderRadius = 15;
            this.btnAceptar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.onHoverState.BorderThickness = 1;
            this.btnAceptar.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.onHoverState.IconLeftImage = null;
            this.btnAceptar.onHoverState.IconRightImage = null;
            this.btnAceptar.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.OnIdleState.BorderRadius = 15;
            this.btnAceptar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.OnIdleState.BorderThickness = 1;
            this.btnAceptar.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.OnIdleState.IconLeftImage = null;
            this.btnAceptar.OnIdleState.IconRightImage = null;
            this.btnAceptar.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.OnPressedState.BorderRadius = 15;
            this.btnAceptar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnAceptar.OnPressedState.BorderThickness = 1;
            this.btnAceptar.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnAceptar.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnAceptar.OnPressedState.IconLeftImage = null;
            this.btnAceptar.OnPressedState.IconRightImage = null;
            this.btnAceptar.Size = new System.Drawing.Size(160, 39);
            this.btnAceptar.TabIndex = 62;
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAceptar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAceptar.TextMarginLeft = 0;
            this.btnAceptar.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAceptar.UseDefaultRadiusAndThickness = true;
            this.btnAceptar.Visible = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AparicionImagen.SetDecoration(this.pbImagen, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbImagen.Location = new System.Drawing.Point(135, 80);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(160, 160);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 63;
            this.pbImagen.TabStop = false;
            this.pbImagen.Visible = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AllowParentOverrides = false;
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.AutoEllipsis = false;
            this.lblMensaje.AutoSize = false;
            this.lblMensaje.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMensaje.CursorType = System.Windows.Forms.Cursors.Default;
            this.AparicionImagen.SetDecoration(this.lblMensaje, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblMensaje.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblMensaje.Location = new System.Drawing.Point(23, 228);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMensaje.Size = new System.Drawing.Size(384, 100);
            this.lblMensaje.TabIndex = 64;
            this.lblMensaje.Text = "MENSAJE\r\n";
            this.lblMensaje.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensaje.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblMensaje.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AllowParentOverrides = false;
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoEllipsis = false;
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.CursorType = System.Windows.Forms.Cursors.Default;
            this.AparicionImagen.SetDecoration(this.lblTitulo, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblTitulo.Location = new System.Drawing.Point(23, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(384, 52);
            this.lblTitulo.TabIndex = 65;
            this.lblTitulo.Text = "SISTEMA DE GESTIÓN DE SILABOS Y CONTROL DE ASISTENCIA - UNSAAC";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblTitulo.Visible = false;
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
            // A_DialogoRespuesta1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 382);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblMensaje);
            this.AparicionImagen.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "A_DialogoRespuesta1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialogo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.P_DialogoRespuesta1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private System.Windows.Forms.Timer AparicionFormulario;
        private Bunifu.UI.WinForms.BunifuTransition AparicionImagen;
        private Bunifu.UI.WinForms.BunifuFormDock Docker;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnAceptar;
        private System.Windows.Forms.PictureBox pbImagen;
        private Bunifu.UI.WinForms.BunifuLabel lblMensaje;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
    }
}