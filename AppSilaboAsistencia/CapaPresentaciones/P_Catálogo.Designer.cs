
namespace CapaPresentaciones
{
    partial class P_Catálogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_Catálogo));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Restaurar = new System.Windows.Forms.PictureBox();
            this.Maximizar = new System.Windows.Forms.PictureBox();
            this.Minimizar = new System.Windows.Forms.PictureBox();
            this.Salir = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Menú = new System.Windows.Forms.PictureBox();
            this.Panel_DashBoard = new System.Windows.Forms.Panel();
            this.GradientPanel = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.Botón_Actualizar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.Botón_Eliminar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.Botón_Agregar = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel_Mostrar_Catálogo = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Restaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Menú)).BeginInit();
            this.Panel_DashBoard.SuspendLayout();
            this.GradientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.Restaurar);
            this.panel1.Controls.Add(this.Maximizar);
            this.panel1.Controls.Add(this.Minimizar);
            this.panel1.Controls.Add(this.Salir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Menú);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 54);
            this.panel1.TabIndex = 1;
            // 
            // Restaurar
            // 
            this.Restaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Restaurar.BackColor = System.Drawing.Color.Transparent;
            this.Restaurar.Image = global::CapaPresentaciones.Properties.Resources.Restaurar;
            this.Restaurar.Location = new System.Drawing.Point(719, 13);
            this.Restaurar.Name = "Restaurar";
            this.Restaurar.Size = new System.Drawing.Size(30, 30);
            this.Restaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Restaurar.TabIndex = 5;
            this.Restaurar.TabStop = false;
            this.Restaurar.Visible = false;
            this.Restaurar.Click += new System.EventHandler(this.Restaurar_Click);
            // 
            // Maximizar
            // 
            this.Maximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Maximizar.BackColor = System.Drawing.Color.Transparent;
            this.Maximizar.Image = global::CapaPresentaciones.Properties.Resources.Maximizar;
            this.Maximizar.Location = new System.Drawing.Point(719, 13);
            this.Maximizar.Name = "Maximizar";
            this.Maximizar.Size = new System.Drawing.Size(30, 30);
            this.Maximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Maximizar.TabIndex = 4;
            this.Maximizar.TabStop = false;
            this.Maximizar.Click += new System.EventHandler(this.Maximizar_Click);
            // 
            // Minimizar
            // 
            this.Minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimizar.BackColor = System.Drawing.Color.Transparent;
            this.Minimizar.Image = global::CapaPresentaciones.Properties.Resources.Minimizar;
            this.Minimizar.Location = new System.Drawing.Point(683, 13);
            this.Minimizar.Name = "Minimizar";
            this.Minimizar.Size = new System.Drawing.Size(30, 30);
            this.Minimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Minimizar.TabIndex = 3;
            this.Minimizar.TabStop = false;
            this.Minimizar.Click += new System.EventHandler(this.Minimizar_Click);
            // 
            // Salir
            // 
            this.Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Salir.BackColor = System.Drawing.Color.Transparent;
            this.Salir.Image = global::CapaPresentaciones.Properties.Resources.Cerrar;
            this.Salir.Location = new System.Drawing.Point(755, 13);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(30, 30);
            this.Salir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Salir.TabIndex = 2;
            this.Salir.TabStop = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(146)))), ((int)(((byte)(1)))));
            this.label1.Location = new System.Drawing.Point(50, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "CATÁLOGO";
            // 
            // Menú
            // 
            this.Menú.BackColor = System.Drawing.Color.Transparent;
            this.Menú.Image = global::CapaPresentaciones.Properties.Resources.menu;
            this.Menú.Location = new System.Drawing.Point(15, 13);
            this.Menú.Name = "Menú";
            this.Menú.Size = new System.Drawing.Size(30, 30);
            this.Menú.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Menú.TabIndex = 0;
            this.Menú.TabStop = false;
            this.Menú.Click += new System.EventHandler(this.Menú_Click);
            // 
            // Panel_DashBoard
            // 
            this.Panel_DashBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.Panel_DashBoard.Controls.Add(this.GradientPanel);
            this.Panel_DashBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_DashBoard.Location = new System.Drawing.Point(0, 54);
            this.Panel_DashBoard.Name = "Panel_DashBoard";
            this.Panel_DashBoard.Size = new System.Drawing.Size(201, 396);
            this.Panel_DashBoard.TabIndex = 2;
            // 
            // GradientPanel
            // 
            this.GradientPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GradientPanel.BackColor = System.Drawing.Color.Transparent;
            this.GradientPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GradientPanel.BackgroundImage")));
            this.GradientPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GradientPanel.BorderRadius = 1;
            this.GradientPanel.Controls.Add(this.Botón_Actualizar);
            this.GradientPanel.Controls.Add(this.Botón_Eliminar);
            this.GradientPanel.Controls.Add(this.Botón_Agregar);
            this.GradientPanel.Controls.Add(this.bunifuSeparator1);
            this.GradientPanel.Controls.Add(this.label2);
            this.GradientPanel.Controls.Add(this.pictureBox1);
            this.GradientPanel.GradientBottomLeft = System.Drawing.Color.Orange;
            this.GradientPanel.GradientBottomRight = System.Drawing.Color.Khaki;
            this.GradientPanel.GradientTopLeft = System.Drawing.Color.Khaki;
            this.GradientPanel.GradientTopRight = System.Drawing.Color.Orange;
            this.GradientPanel.Location = new System.Drawing.Point(13, 11);
            this.GradientPanel.Name = "GradientPanel";
            this.GradientPanel.Quality = 10;
            this.GradientPanel.Size = new System.Drawing.Size(171, 371);
            this.GradientPanel.TabIndex = 0;
            // 
            // Botón_Actualizar
            // 
            this.Botón_Actualizar.AllowAnimations = true;
            this.Botón_Actualizar.AllowMouseEffects = true;
            this.Botón_Actualizar.AllowToggling = false;
            this.Botón_Actualizar.AnimationSpeed = 200;
            this.Botón_Actualizar.AutoGenerateColors = false;
            this.Botón_Actualizar.AutoRoundBorders = false;
            this.Botón_Actualizar.AutoSizeLeftIcon = true;
            this.Botón_Actualizar.AutoSizeRightIcon = true;
            this.Botón_Actualizar.BackColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.BackColor1 = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Botón_Actualizar.BackgroundImage")));
            this.Botón_Actualizar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Actualizar.ButtonText = "ACTUALIZAR ";
            this.Botón_Actualizar.ButtonTextMarginLeft = 0;
            this.Botón_Actualizar.ColorContrastOnClick = 45;
            this.Botón_Actualizar.ColorContrastOnHover = 45;
            this.Botón_Actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.Botón_Actualizar.CustomizableEdges = borderEdges4;
            this.Botón_Actualizar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Botón_Actualizar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Botón_Actualizar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Botón_Actualizar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Botón_Actualizar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.Botón_Actualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Botón_Actualizar.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Actualizar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Botón_Actualizar.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.Botón_Actualizar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Botón_Actualizar.IconMarginLeft = 11;
            this.Botón_Actualizar.IconPadding = 10;
            this.Botón_Actualizar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Actualizar.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.Botón_Actualizar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Botón_Actualizar.IconSize = 25;
            this.Botón_Actualizar.IdleBorderColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.IdleBorderRadius = 1;
            this.Botón_Actualizar.IdleBorderThickness = 1;
            this.Botón_Actualizar.IdleFillColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Modificar_1;
            this.Botón_Actualizar.IdleIconRightImage = null;
            this.Botón_Actualizar.IndicateFocus = false;
            this.Botón_Actualizar.Location = new System.Drawing.Point(0, 140);
            this.Botón_Actualizar.Name = "Botón_Actualizar";
            this.Botón_Actualizar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Botón_Actualizar.OnDisabledState.BorderRadius = 1;
            this.Botón_Actualizar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Actualizar.OnDisabledState.BorderThickness = 1;
            this.Botón_Actualizar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Botón_Actualizar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Botón_Actualizar.OnDisabledState.IconLeftImage = null;
            this.Botón_Actualizar.OnDisabledState.IconRightImage = null;
            this.Botón_Actualizar.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.onHoverState.BorderRadius = 1;
            this.Botón_Actualizar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Actualizar.onHoverState.BorderThickness = 1;
            this.Botón_Actualizar.onHoverState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.onHoverState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Actualizar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Modificar_1;
            this.Botón_Actualizar.onHoverState.IconRightImage = null;
            this.Botón_Actualizar.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.OnIdleState.BorderRadius = 1;
            this.Botón_Actualizar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Actualizar.OnIdleState.BorderThickness = 1;
            this.Botón_Actualizar.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.OnIdleState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Actualizar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Modificar_1;
            this.Botón_Actualizar.OnIdleState.IconRightImage = null;
            this.Botón_Actualizar.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.OnPressedState.BorderRadius = 1;
            this.Botón_Actualizar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Actualizar.OnPressedState.BorderThickness = 1;
            this.Botón_Actualizar.OnPressedState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Actualizar.OnPressedState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Actualizar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Modificar_1;
            this.Botón_Actualizar.OnPressedState.IconRightImage = null;
            this.Botón_Actualizar.Size = new System.Drawing.Size(170, 39);
            this.Botón_Actualizar.TabIndex = 58;
            this.Botón_Actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Actualizar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Botón_Actualizar.TextMarginLeft = 0;
            this.Botón_Actualizar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Botón_Actualizar.UseDefaultRadiusAndThickness = true;
            // 
            // Botón_Eliminar
            // 
            this.Botón_Eliminar.AllowAnimations = true;
            this.Botón_Eliminar.AllowMouseEffects = true;
            this.Botón_Eliminar.AllowToggling = false;
            this.Botón_Eliminar.AnimationSpeed = 200;
            this.Botón_Eliminar.AutoGenerateColors = false;
            this.Botón_Eliminar.AutoRoundBorders = false;
            this.Botón_Eliminar.AutoSizeLeftIcon = true;
            this.Botón_Eliminar.AutoSizeRightIcon = true;
            this.Botón_Eliminar.BackColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.BackColor1 = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Botón_Eliminar.BackgroundImage")));
            this.Botón_Eliminar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Eliminar.ButtonText = "ELIMINAR      ";
            this.Botón_Eliminar.ButtonTextMarginLeft = 0;
            this.Botón_Eliminar.ColorContrastOnClick = 45;
            this.Botón_Eliminar.ColorContrastOnHover = 45;
            this.Botón_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.Botón_Eliminar.CustomizableEdges = borderEdges5;
            this.Botón_Eliminar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Botón_Eliminar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Botón_Eliminar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Botón_Eliminar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Botón_Eliminar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.Botón_Eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Botón_Eliminar.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Eliminar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Botón_Eliminar.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.Botón_Eliminar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Botón_Eliminar.IconMarginLeft = 11;
            this.Botón_Eliminar.IconPadding = 10;
            this.Botón_Eliminar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Eliminar.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.Botón_Eliminar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Botón_Eliminar.IconSize = 25;
            this.Botón_Eliminar.IdleBorderColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.IdleBorderRadius = 1;
            this.Botón_Eliminar.IdleBorderThickness = 1;
            this.Botón_Eliminar.IdleFillColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Eliminar_2;
            this.Botón_Eliminar.IdleIconRightImage = null;
            this.Botón_Eliminar.IndicateFocus = false;
            this.Botón_Eliminar.Location = new System.Drawing.Point(0, 96);
            this.Botón_Eliminar.Name = "Botón_Eliminar";
            this.Botón_Eliminar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Botón_Eliminar.OnDisabledState.BorderRadius = 1;
            this.Botón_Eliminar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Eliminar.OnDisabledState.BorderThickness = 1;
            this.Botón_Eliminar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Botón_Eliminar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Botón_Eliminar.OnDisabledState.IconLeftImage = null;
            this.Botón_Eliminar.OnDisabledState.IconRightImage = null;
            this.Botón_Eliminar.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.onHoverState.BorderRadius = 1;
            this.Botón_Eliminar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Eliminar.onHoverState.BorderThickness = 1;
            this.Botón_Eliminar.onHoverState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.onHoverState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Eliminar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Eliminar_2;
            this.Botón_Eliminar.onHoverState.IconRightImage = null;
            this.Botón_Eliminar.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.OnIdleState.BorderRadius = 1;
            this.Botón_Eliminar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Eliminar.OnIdleState.BorderThickness = 1;
            this.Botón_Eliminar.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.OnIdleState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Eliminar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Eliminar_2;
            this.Botón_Eliminar.OnIdleState.IconRightImage = null;
            this.Botón_Eliminar.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.OnPressedState.BorderRadius = 1;
            this.Botón_Eliminar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Eliminar.OnPressedState.BorderThickness = 1;
            this.Botón_Eliminar.OnPressedState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Eliminar.OnPressedState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Eliminar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Eliminar_2;
            this.Botón_Eliminar.OnPressedState.IconRightImage = null;
            this.Botón_Eliminar.Size = new System.Drawing.Size(170, 39);
            this.Botón_Eliminar.TabIndex = 57;
            this.Botón_Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Eliminar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Botón_Eliminar.TextMarginLeft = 0;
            this.Botón_Eliminar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Botón_Eliminar.UseDefaultRadiusAndThickness = true;
            // 
            // Botón_Agregar
            // 
            this.Botón_Agregar.AllowAnimations = true;
            this.Botón_Agregar.AllowMouseEffects = true;
            this.Botón_Agregar.AllowToggling = false;
            this.Botón_Agregar.AnimationSpeed = 200;
            this.Botón_Agregar.AutoGenerateColors = false;
            this.Botón_Agregar.AutoRoundBorders = false;
            this.Botón_Agregar.AutoSizeLeftIcon = true;
            this.Botón_Agregar.AutoSizeRightIcon = true;
            this.Botón_Agregar.BackColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.BackColor1 = System.Drawing.Color.Transparent;
            this.Botón_Agregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Botón_Agregar.BackgroundImage")));
            this.Botón_Agregar.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Agregar.ButtonText = "AGREGAR     ";
            this.Botón_Agregar.ButtonTextMarginLeft = 0;
            this.Botón_Agregar.ColorContrastOnClick = 45;
            this.Botón_Agregar.ColorContrastOnHover = 45;
            this.Botón_Agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.Botón_Agregar.CustomizableEdges = borderEdges6;
            this.Botón_Agregar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Botón_Agregar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Botón_Agregar.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Botón_Agregar.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Botón_Agregar.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.Botón_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Botón_Agregar.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Agregar.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Botón_Agregar.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.Botón_Agregar.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Botón_Agregar.IconMarginLeft = 11;
            this.Botón_Agregar.IconPadding = 10;
            this.Botón_Agregar.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Agregar.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.Botón_Agregar.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Botón_Agregar.IconSize = 25;
            this.Botón_Agregar.IdleBorderColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.IdleBorderRadius = 1;
            this.Botón_Agregar.IdleBorderThickness = 1;
            this.Botón_Agregar.IdleFillColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.IdleIconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar_2;
            this.Botón_Agregar.IdleIconRightImage = null;
            this.Botón_Agregar.IndicateFocus = false;
            this.Botón_Agregar.Location = new System.Drawing.Point(0, 52);
            this.Botón_Agregar.Name = "Botón_Agregar";
            this.Botón_Agregar.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.Botón_Agregar.OnDisabledState.BorderRadius = 1;
            this.Botón_Agregar.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Agregar.OnDisabledState.BorderThickness = 1;
            this.Botón_Agregar.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Botón_Agregar.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Botón_Agregar.OnDisabledState.IconLeftImage = null;
            this.Botón_Agregar.OnDisabledState.IconRightImage = null;
            this.Botón_Agregar.onHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.onHoverState.BorderRadius = 1;
            this.Botón_Agregar.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Agregar.onHoverState.BorderThickness = 1;
            this.Botón_Agregar.onHoverState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.onHoverState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Agregar.onHoverState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar_2;
            this.Botón_Agregar.onHoverState.IconRightImage = null;
            this.Botón_Agregar.OnIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.OnIdleState.BorderRadius = 1;
            this.Botón_Agregar.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Agregar.OnIdleState.BorderThickness = 1;
            this.Botón_Agregar.OnIdleState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.OnIdleState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Agregar.OnIdleState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar_2;
            this.Botón_Agregar.OnIdleState.IconRightImage = null;
            this.Botón_Agregar.OnPressedState.BorderColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.OnPressedState.BorderRadius = 1;
            this.Botón_Agregar.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.Botón_Agregar.OnPressedState.BorderThickness = 1;
            this.Botón_Agregar.OnPressedState.FillColor = System.Drawing.Color.Transparent;
            this.Botón_Agregar.OnPressedState.ForeColor = System.Drawing.Color.Navy;
            this.Botón_Agregar.OnPressedState.IconLeftImage = global::CapaPresentaciones.Properties.Resources.Agregar_2;
            this.Botón_Agregar.OnPressedState.IconRightImage = null;
            this.Botón_Agregar.Size = new System.Drawing.Size(170, 39);
            this.Botón_Agregar.TabIndex = 56;
            this.Botón_Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Botón_Agregar.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Botón_Agregar.TextMarginLeft = 0;
            this.Botón_Agregar.TextPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Botón_Agregar.UseDefaultRadiusAndThickness = true;
            this.Botón_Agregar.Click += new System.EventHandler(this.Botón_Agregar_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.Gray;
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(-8, 44);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(190, 1);
            this.bunifuSeparator1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(15)))));
            this.label2.Location = new System.Drawing.Point(44, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ACTUALIZAR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentaciones.Properties.Resources.Editar;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Panel_Mostrar_Catálogo
            // 
            this.Panel_Mostrar_Catálogo.AutoScroll = true;
            this.Panel_Mostrar_Catálogo.AutoSize = true;
            this.Panel_Mostrar_Catálogo.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Mostrar_Catálogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Mostrar_Catálogo.Location = new System.Drawing.Point(201, 54);
            this.Panel_Mostrar_Catálogo.Name = "Panel_Mostrar_Catálogo";
            this.Panel_Mostrar_Catálogo.Size = new System.Drawing.Size(599, 396);
            this.Panel_Mostrar_Catálogo.TabIndex = 3;
            // 
            // P_Catálogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Panel_Mostrar_Catálogo);
            this.Controls.Add(this.Panel_DashBoard);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_Catálogo";
            this.Text = "P_Catálogo1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Restaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Salir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Menú)).EndInit();
            this.Panel_DashBoard.ResumeLayout(false);
            this.GradientPanel.ResumeLayout(false);
            this.GradientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Restaurar;
        private System.Windows.Forms.PictureBox Maximizar;
        private System.Windows.Forms.PictureBox Minimizar;
        private System.Windows.Forms.PictureBox Salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Menú;
        private System.Windows.Forms.Panel Panel_DashBoard;
        private Bunifu.UI.WinForms.BunifuGradientPanel GradientPanel;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 Botón_Actualizar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 Botón_Eliminar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 Botón_Agregar;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Panel_Mostrar_Catálogo;
    }
}