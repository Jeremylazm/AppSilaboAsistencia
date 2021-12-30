
namespace Ayudas
{
    partial class A_DialogoRespuesta2
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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation1 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_DialogoRespuesta2));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.Bordeado = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.AparicionFormulario = new System.Windows.Forms.Timer(this.components);
            this.btnVerdadero = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.AparicionImagen = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.btnFalso = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblPregunta = new Bunifu.UI.WinForms.BunifuLabel();
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
            // btnVerdadero
            // 
            this.btnVerdadero.AllowAnimations = true;
            this.btnVerdadero.AllowMouseEffects = true;
            this.btnVerdadero.AllowToggling = false;
            this.btnVerdadero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnVerdadero.AnimationSpeed = 200;
            this.btnVerdadero.AutoGenerateColors = false;
            this.btnVerdadero.AutoRoundBorders = false;
            this.btnVerdadero.AutoSizeLeftIcon = true;
            this.btnVerdadero.AutoSizeRightIcon = true;
            this.btnVerdadero.BackColor = System.Drawing.Color.Transparent;
            this.btnVerdadero.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerdadero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerdadero.BackgroundImage")));
            this.btnVerdadero.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnVerdadero.ButtonText = "Aceptar";
            this.btnVerdadero.ButtonTextMarginLeft = 0;
            this.btnVerdadero.ColorContrastOnClick = 45;
            this.btnVerdadero.ColorContrastOnHover = 45;
            this.btnVerdadero.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnVerdadero.CustomizableEdges = borderEdges2;
            this.AparicionImagen.SetDecoration(this.btnVerdadero, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnVerdadero.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnVerdadero.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnVerdadero.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnVerdadero.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnVerdadero.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnVerdadero.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerdadero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerdadero.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerdadero.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnVerdadero.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnVerdadero.IconMarginLeft = 11;
            this.btnVerdadero.IconPadding = 10;
            this.btnVerdadero.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerdadero.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnVerdadero.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnVerdadero.IconSize = 25;
            this.btnVerdadero.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerdadero.IdleBorderRadius = 15;
            this.btnVerdadero.IdleBorderThickness = 1;
            this.btnVerdadero.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerdadero.IdleIconLeftImage = null;
            this.btnVerdadero.IdleIconRightImage = null;
            this.btnVerdadero.IndicateFocus = false;
            this.btnVerdadero.Location = new System.Drawing.Point(50, 324);
            this.btnVerdadero.Name = "btnVerdadero";
            this.btnVerdadero.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnVerdadero.OnDisabledState.BorderRadius = 15;
            this.btnVerdadero.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnVerdadero.OnDisabledState.BorderThickness = 1;
            this.btnVerdadero.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnVerdadero.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnVerdadero.OnDisabledState.IconLeftImage = null;
            this.btnVerdadero.OnDisabledState.IconRightImage = null;
            this.btnVerdadero.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerdadero.onHoverState.BorderRadius = 15;
            this.btnVerdadero.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnVerdadero.onHoverState.BorderThickness = 1;
            this.btnVerdadero.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerdadero.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerdadero.onHoverState.IconLeftImage = null;
            this.btnVerdadero.onHoverState.IconRightImage = null;
            this.btnVerdadero.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerdadero.OnIdleState.BorderRadius = 15;
            this.btnVerdadero.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnVerdadero.OnIdleState.BorderThickness = 1;
            this.btnVerdadero.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerdadero.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerdadero.OnIdleState.IconLeftImage = null;
            this.btnVerdadero.OnIdleState.IconRightImage = null;
            this.btnVerdadero.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerdadero.OnPressedState.BorderRadius = 15;
            this.btnVerdadero.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnVerdadero.OnPressedState.BorderThickness = 1;
            this.btnVerdadero.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnVerdadero.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnVerdadero.OnPressedState.IconLeftImage = null;
            this.btnVerdadero.OnPressedState.IconRightImage = null;
            this.btnVerdadero.Size = new System.Drawing.Size(120, 39);
            this.btnVerdadero.TabIndex = 51;
            this.btnVerdadero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVerdadero.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnVerdadero.TextMarginLeft = 0;
            this.btnVerdadero.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnVerdadero.UseDefaultRadiusAndThickness = true;
            this.btnVerdadero.Visible = false;
            this.btnVerdadero.Click += new System.EventHandler(this.btnVerdadero_Click);
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
            // btnFalso
            // 
            this.btnFalso.AllowAnimations = true;
            this.btnFalso.AllowMouseEffects = true;
            this.btnFalso.AllowToggling = false;
            this.btnFalso.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFalso.AnimationSpeed = 200;
            this.btnFalso.AutoGenerateColors = false;
            this.btnFalso.AutoRoundBorders = false;
            this.btnFalso.AutoSizeLeftIcon = true;
            this.btnFalso.AutoSizeRightIcon = true;
            this.btnFalso.BackColor = System.Drawing.Color.Transparent;
            this.btnFalso.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnFalso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFalso.BackgroundImage")));
            this.btnFalso.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnFalso.ButtonText = "Cancelar";
            this.btnFalso.ButtonTextMarginLeft = 0;
            this.btnFalso.ColorContrastOnClick = 45;
            this.btnFalso.ColorContrastOnHover = 45;
            this.btnFalso.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnFalso.CustomizableEdges = borderEdges1;
            this.AparicionImagen.SetDecoration(this.btnFalso, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnFalso.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFalso.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnFalso.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnFalso.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnFalso.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnFalso.Font = new System.Drawing.Font("Montserrat Alternates", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFalso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnFalso.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFalso.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnFalso.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnFalso.IconMarginLeft = 11;
            this.btnFalso.IconPadding = 10;
            this.btnFalso.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFalso.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnFalso.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnFalso.IconSize = 25;
            this.btnFalso.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnFalso.IdleBorderRadius = 15;
            this.btnFalso.IdleBorderThickness = 1;
            this.btnFalso.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnFalso.IdleIconLeftImage = null;
            this.btnFalso.IdleIconRightImage = null;
            this.btnFalso.IndicateFocus = false;
            this.btnFalso.Location = new System.Drawing.Point(255, 324);
            this.btnFalso.Name = "btnFalso";
            this.btnFalso.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnFalso.OnDisabledState.BorderRadius = 15;
            this.btnFalso.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnFalso.OnDisabledState.BorderThickness = 1;
            this.btnFalso.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnFalso.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnFalso.OnDisabledState.IconLeftImage = null;
            this.btnFalso.OnDisabledState.IconRightImage = null;
            this.btnFalso.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnFalso.onHoverState.BorderRadius = 15;
            this.btnFalso.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnFalso.onHoverState.BorderThickness = 1;
            this.btnFalso.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnFalso.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnFalso.onHoverState.IconLeftImage = null;
            this.btnFalso.onHoverState.IconRightImage = null;
            this.btnFalso.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnFalso.OnIdleState.BorderRadius = 15;
            this.btnFalso.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnFalso.OnIdleState.BorderThickness = 1;
            this.btnFalso.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnFalso.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnFalso.OnIdleState.IconLeftImage = null;
            this.btnFalso.OnIdleState.IconRightImage = null;
            this.btnFalso.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnFalso.OnPressedState.BorderRadius = 15;
            this.btnFalso.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnFalso.OnPressedState.BorderThickness = 1;
            this.btnFalso.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.btnFalso.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(158)))), ((int)(((byte)(31)))));
            this.btnFalso.OnPressedState.IconLeftImage = null;
            this.btnFalso.OnPressedState.IconRightImage = null;
            this.btnFalso.Size = new System.Drawing.Size(120, 39);
            this.btnFalso.TabIndex = 57;
            this.btnFalso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFalso.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnFalso.TextMarginLeft = 0;
            this.btnFalso.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnFalso.UseDefaultRadiusAndThickness = true;
            this.btnFalso.Visible = false;
            this.btnFalso.Click += new System.EventHandler(this.btnFalso_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AparicionImagen.SetDecoration(this.pbImagen, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pbImagen.Image = global::Ayudas.Properties.Resources.Dialogo_Pregunta;
            this.pbImagen.Location = new System.Drawing.Point(135, 80);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(160, 160);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 61;
            this.pbImagen.TabStop = false;
            this.pbImagen.Visible = false;
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
            this.lblTitulo.TabIndex = 63;
            this.lblTitulo.Text = "SISTEMA DE GESTIÓN DE SILABOS Y CONTROL DE ASISTENCIA - UNSAAC";
            this.lblTitulo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblTitulo.Visible = false;
            // 
            // lblPregunta
            // 
            this.lblPregunta.AllowParentOverrides = false;
            this.lblPregunta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPregunta.AutoEllipsis = false;
            this.lblPregunta.AutoSize = false;
            this.lblPregunta.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPregunta.CursorType = System.Windows.Forms.Cursors.Default;
            this.AparicionImagen.SetDecoration(this.lblPregunta, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.lblPregunta.Font = new System.Drawing.Font("Montserrat Alternates", 12F);
            this.lblPregunta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.lblPregunta.Location = new System.Drawing.Point(23, 228);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPregunta.Size = new System.Drawing.Size(384, 100);
            this.lblPregunta.TabIndex = 62;
            this.lblPregunta.Text = "PREGUNTA";
            this.lblPregunta.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPregunta.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblPregunta.Visible = false;
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
            // A_DialogoRespuesta2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 382);
            this.Controls.Add(this.btnFalso);
            this.Controls.Add(this.btnVerdadero);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblPregunta);
            this.AparicionImagen.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "A_DialogoRespuesta2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialogo de Pregunta";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.P_DialogoRespuesta2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse Bordeado;
        private System.Windows.Forms.Timer AparicionFormulario;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnVerdadero;
        private Bunifu.UI.WinForms.BunifuTransition AparicionImagen;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnFalso;
        private System.Windows.Forms.PictureBox pbImagen;
        private Bunifu.UI.WinForms.BunifuLabel lblTitulo;
        private Bunifu.UI.WinForms.BunifuLabel lblPregunta;
        private Bunifu.UI.WinForms.BunifuFormDock Docker;
    }
}