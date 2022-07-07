namespace LocadoraFCVSJ.ModuloVeiculo
{
    partial class ControleVeiculoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControleVeiculoForm));
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnExcluir = new Krypton.Toolkit.KryptonButton();
            this.BtnEditar = new Krypton.Toolkit.KryptonButton();
            this.BtnInserir = new Krypton.Toolkit.KryptonButton();
            this.GridVeiculos = new System.Windows.Forms.DataGridView();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnPlaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnVisualizar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridVeiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office2010BlackDarkMode;
            this.kryptonPalette1.ButtonSpecs.FormClose.Image = global::LocadoraFCVSJ.Properties.Resources.close_20px;
            this.kryptonPalette1.ButtonSpecs.FormMax.Image = global::LocadoraFCVSJ.Properties.Resources.maximize_button_20px;
            this.kryptonPalette1.ButtonSpecs.FormMin.Image = global::LocadoraFCVSJ.Properties.Resources.subtract_20px;
            this.kryptonPalette1.ButtonSpecs.FormRestore.Image = global::LocadoraFCVSJ.Properties.Resources.restore_window_20px;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 5F;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Rounding = 1F;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Width = 0;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 12;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonPadding = new System.Windows.Forms.Padding(-1, 0, -1, -1);
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-1, 0, -1, -1);
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateDisabled.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LocadoraFCVSJ.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(306, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 72);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(679, 68);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(196, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestão de Veículos";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(12, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(977, 54);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.BtnExcluir);
            this.panel4.Controls.Add(this.BtnEditar);
            this.panel4.Controls.Add(this.BtnInserir);
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(973, 50);
            this.panel4.TabIndex = 2;
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(139, 7);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.OverrideDefault.Back.Color1 = System.Drawing.Color.IndianRed;
            this.BtnExcluir.OverrideDefault.Back.Color2 = System.Drawing.Color.IndianRed;
            this.BtnExcluir.Size = new System.Drawing.Size(55, 38);
            this.BtnExcluir.StateCommon.Back.Color1 = System.Drawing.Color.IndianRed;
            this.BtnExcluir.StateCommon.Back.Color2 = System.Drawing.Color.IndianRed;
            this.BtnExcluir.StateCommon.Back.Image = global::LocadoraFCVSJ.Properties.Resources.close_white_30px;
            this.BtnExcluir.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnExcluir.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnExcluir.StateCommon.Border.Rounding = 4F;
            this.BtnExcluir.TabIndex = 2;
            this.BtnExcluir.ToolTipValues.Description = "";
            this.BtnExcluir.ToolTipValues.EnableToolTips = true;
            this.BtnExcluir.ToolTipValues.Heading = "Excluir Veículo";
            this.BtnExcluir.ToolTipValues.ToolTipStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.BtnExcluir.Values.Text = "";
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(75, 7);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.BtnEditar.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.BtnEditar.Size = new System.Drawing.Size(55, 38);
            this.BtnEditar.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.BtnEditar.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.BtnEditar.StateCommon.Back.Image = global::LocadoraFCVSJ.Properties.Resources.pencil_30px;
            this.BtnEditar.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnEditar.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnEditar.StateCommon.Border.Rounding = 4F;
            this.BtnEditar.StateCommon.Border.Width = 1;
            this.BtnEditar.TabIndex = 1;
            this.BtnEditar.ToolTipValues.Description = "";
            this.BtnEditar.ToolTipValues.EnableToolTips = true;
            this.BtnEditar.ToolTipValues.Heading = "Editar Veículo";
            this.BtnEditar.ToolTipValues.ToolTipStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.BtnEditar.Values.Text = "";
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnInserir
            // 
            this.BtnInserir.Location = new System.Drawing.Point(11, 7);
            this.BtnInserir.Name = "BtnInserir";
            this.BtnInserir.OverrideDefault.Back.Color1 = System.Drawing.Color.MediumSeaGreen;
            this.BtnInserir.OverrideDefault.Back.Color2 = System.Drawing.Color.MediumSeaGreen;
            this.BtnInserir.Size = new System.Drawing.Size(55, 38);
            this.BtnInserir.StateCommon.Back.Color1 = System.Drawing.Color.MediumSeaGreen;
            this.BtnInserir.StateCommon.Back.Color2 = System.Drawing.Color.MediumSeaGreen;
            this.BtnInserir.StateCommon.Back.Image = global::LocadoraFCVSJ.Properties.Resources.plus_math_30px;
            this.BtnInserir.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnInserir.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnInserir.StateCommon.Border.Rounding = 4F;
            this.BtnInserir.StateCommon.Border.Width = 1;
            this.BtnInserir.TabIndex = 0;
            this.BtnInserir.ToolTipValues.Description = "";
            this.BtnInserir.ToolTipValues.EnableToolTips = true;
            this.BtnInserir.ToolTipValues.Heading = "Adicionar Veículo";
            this.BtnInserir.ToolTipValues.ToolTipStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.BtnInserir.Values.Text = "";
            this.BtnInserir.Click += new System.EventHandler(this.BtnInserir_Click);
            // 
            // GridVeiculos
            // 
            this.GridVeiculos.AllowUserToAddRows = false;
            this.GridVeiculos.AllowUserToDeleteRows = false;
            this.GridVeiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridVeiculos.BackgroundColor = System.Drawing.Color.White;
            this.GridVeiculos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridVeiculos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridVeiculos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(219)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridVeiculos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridVeiculos.ColumnHeadersHeight = 45;
            this.GridVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridVeiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.ClnGrupo,
            this.ClnModelo,
            this.ClnMarca,
            this.ClnPlaca,
            this.ClnVisualizar});
            this.GridVeiculos.EnableHeadersVisualStyles = false;
            this.GridVeiculos.GridColor = System.Drawing.Color.White;
            this.GridVeiculos.Location = new System.Drawing.Point(12, 190);
            this.GridVeiculos.Name = "GridVeiculos";
            this.GridVeiculos.ReadOnly = true;
            this.GridVeiculos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridVeiculos.RowHeadersVisible = false;
            this.GridVeiculos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(130)))), ((int)(((byte)(229)))));
            this.GridVeiculos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GridVeiculos.RowTemplate.Height = 25;
            this.GridVeiculos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridVeiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridVeiculos.Size = new System.Drawing.Size(977, 468);
            this.GridVeiculos.TabIndex = 4;
            this.GridVeiculos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridVeiculos_CellClick);
            this.GridVeiculos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridVeiculos_CellFormatting);
            this.GridVeiculos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GridVeiculos_CellPainting);
            // 
            // ClnId
            // 
            this.ClnId.FillWeight = 30F;
            this.ClnId.HeaderText = "ID";
            this.ClnId.Name = "ClnId";
            this.ClnId.ReadOnly = true;
            this.ClnId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnGrupo
            // 
            this.ClnGrupo.FillWeight = 95F;
            this.ClnGrupo.HeaderText = "Grupo";
            this.ClnGrupo.Name = "ClnGrupo";
            this.ClnGrupo.ReadOnly = true;
            this.ClnGrupo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnGrupo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnModelo
            // 
            this.ClnModelo.FillWeight = 40F;
            this.ClnModelo.HeaderText = "Modelo";
            this.ClnModelo.Name = "ClnModelo";
            this.ClnModelo.ReadOnly = true;
            this.ClnModelo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnModelo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnMarca
            // 
            this.ClnMarca.FillWeight = 66.81472F;
            this.ClnMarca.HeaderText = "Marca";
            this.ClnMarca.Name = "ClnMarca";
            this.ClnMarca.ReadOnly = true;
            this.ClnMarca.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnMarca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnPlaca
            // 
            this.ClnPlaca.FillWeight = 80F;
            this.ClnPlaca.HeaderText = "Placa";
            this.ClnPlaca.Name = "ClnPlaca";
            this.ClnPlaca.ReadOnly = true;
            this.ClnPlaca.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnPlaca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnVisualizar
            // 
            this.ClnVisualizar.FillWeight = 66.81472F;
            this.ClnVisualizar.HeaderText = "Visualizar";
            this.ClnVisualizar.Name = "ClnVisualizar";
            this.ClnVisualizar.ReadOnly = true;
            this.ClnVisualizar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ControleVeiculoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1001, 670);
            this.Controls.Add(this.GridVeiculos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControleVeiculoForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora FCVSJ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridVeiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
        private Krypton.Toolkit.KryptonButton BtnExcluir;
        private Krypton.Toolkit.KryptonButton BtnEditar;
        private Krypton.Toolkit.KryptonButton BtnInserir;
        private DataGridView GridVeiculos;
        private DataGridViewTextBoxColumn ClnId;
        private DataGridViewTextBoxColumn ClnGrupo;
        private DataGridViewTextBoxColumn ClnModelo;
        private DataGridViewTextBoxColumn ClnMarca;
        private DataGridViewTextBoxColumn ClnPlaca;
        private DataGridViewButtonColumn ClnVisualizar;
    }
}