﻿namespace LocadoraFCVSJ.ModuloCondutor
{
    partial class ControleCondutorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControleCondutorForm));
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
            this.GridCondutores = new System.Windows.Forms.DataGridView();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnValidadeCnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnPessoaJuridica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCnpj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnEndereco = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCondutores)).BeginInit();
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
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.panel1.Size = new System.Drawing.Size(1068, 72);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 68);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestão de Condutores";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(12, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1363, 54);
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
            this.panel4.Size = new System.Drawing.Size(1359, 50);
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
            this.BtnExcluir.ToolTipValues.Heading = "Excluir Condutor";
            this.BtnExcluir.ToolTipValues.ToolTipStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.BtnExcluir.Values.Text = "";
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
            this.BtnEditar.ToolTipValues.Heading = "Editar Condutor";
            this.BtnEditar.ToolTipValues.ToolTipStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.BtnEditar.Values.Text = "";
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
            this.BtnInserir.ToolTipValues.Heading = "Adicionar Condutor";
            this.BtnInserir.ToolTipValues.ToolTipStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.BtnInserir.Values.Text = "";
            // 
            // GridCondutores
            // 
            this.GridCondutores.AllowUserToAddRows = false;
            this.GridCondutores.AllowUserToDeleteRows = false;
            this.GridCondutores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridCondutores.BackgroundColor = System.Drawing.Color.White;
            this.GridCondutores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridCondutores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridCondutores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(219)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridCondutores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridCondutores.ColumnHeadersHeight = 45;
            this.GridCondutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridCondutores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.ClnNome,
            this.ClnCpf,
            this.ClnCnh,
            this.ClnValidadeCnh,
            this.ClnEmail,
            this.ClnTelefone,
            this.ClnPessoaJuridica,
            this.ClnCnpj,
            this.ClnEndereco});
            this.GridCondutores.EnableHeadersVisualStyles = false;
            this.GridCondutores.GridColor = System.Drawing.Color.White;
            this.GridCondutores.Location = new System.Drawing.Point(12, 190);
            this.GridCondutores.Name = "GridCondutores";
            this.GridCondutores.ReadOnly = true;
            this.GridCondutores.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridCondutores.RowHeadersVisible = false;
            this.GridCondutores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(130)))), ((int)(((byte)(229)))));
            this.GridCondutores.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GridCondutores.RowTemplate.Height = 25;
            this.GridCondutores.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridCondutores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridCondutores.Size = new System.Drawing.Size(1363, 468);
            this.GridCondutores.TabIndex = 4;
            this.GridCondutores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCondutores_CellClick);
            this.GridCondutores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridCondutores_CellFormatting);
            this.GridCondutores.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GridCondutores_CellPainting);
            // 
            // ClnId
            // 
            this.ClnId.FillWeight = 8.250055F;
            this.ClnId.HeaderText = "ID";
            this.ClnId.Name = "ClnId";
            this.ClnId.ReadOnly = true;
            this.ClnId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnNome
            // 
            this.ClnNome.FillWeight = 26.12518F;
            this.ClnNome.HeaderText = "Nome";
            this.ClnNome.Name = "ClnNome";
            this.ClnNome.ReadOnly = true;
            this.ClnNome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnNome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnCpf
            // 
            this.ClnCpf.FillWeight = 11.00007F;
            this.ClnCpf.HeaderText = "CPF";
            this.ClnCpf.Name = "ClnCpf";
            this.ClnCpf.ReadOnly = true;
            this.ClnCpf.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnCpf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnCnh
            // 
            this.ClnCnh.FillWeight = 18.37417F;
            this.ClnCnh.HeaderText = "CNH";
            this.ClnCnh.Name = "ClnCnh";
            this.ClnCnh.ReadOnly = true;
            this.ClnCnh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnCnh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnValidadeCnh
            // 
            this.ClnValidadeCnh.FillWeight = 10F;
            this.ClnValidadeCnh.HeaderText = "Validade CNH";
            this.ClnValidadeCnh.Name = "ClnValidadeCnh";
            this.ClnValidadeCnh.ReadOnly = true;
            this.ClnValidadeCnh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnValidadeCnh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnEmail
            // 
            this.ClnEmail.FillWeight = 22.00015F;
            this.ClnEmail.HeaderText = "E-mail";
            this.ClnEmail.Name = "ClnEmail";
            this.ClnEmail.ReadOnly = true;
            this.ClnEmail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnTelefone
            // 
            this.ClnTelefone.FillWeight = 18.37417F;
            this.ClnTelefone.HeaderText = "Telefone";
            this.ClnTelefone.Name = "ClnTelefone";
            this.ClnTelefone.ReadOnly = true;
            this.ClnTelefone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnTelefone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnPessoaJuridica
            // 
            this.ClnPessoaJuridica.FillWeight = 4.125028F;
            this.ClnPessoaJuridica.HeaderText = "PJ";
            this.ClnPessoaJuridica.Name = "ClnPessoaJuridica";
            this.ClnPessoaJuridica.ReadOnly = true;
            this.ClnPessoaJuridica.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnPessoaJuridica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnCnpj
            // 
            this.ClnCnpj.FillWeight = 18.37417F;
            this.ClnCnpj.HeaderText = "CNPJ";
            this.ClnCnpj.Name = "ClnCnpj";
            this.ClnCnpj.ReadOnly = true;
            this.ClnCnpj.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnCnpj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnEndereco
            // 
            this.ClnEndereco.FillWeight = 15.25006F;
            this.ClnEndereco.HeaderText = "Endereço";
            this.ClnEndereco.Name = "ClnEndereco";
            this.ClnEndereco.ReadOnly = true;
            this.ClnEndereco.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClnEndereco.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClnEndereco.Text = "";
            // 
            // ControleCondutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 670);
            this.Controls.Add(this.GridCondutores);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControleCondutorForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.GridCondutores)).EndInit();
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
        private DataGridView GridCondutores;
        private DataGridViewTextBoxColumn ClnId;
        private DataGridViewTextBoxColumn ClnNome;
        private DataGridViewTextBoxColumn ClnCpf;
        private DataGridViewTextBoxColumn ClnCnh;
        private DataGridViewTextBoxColumn ClnValidadeCnh;
        private DataGridViewTextBoxColumn ClnEmail;
        private DataGridViewTextBoxColumn ClnTelefone;
        private DataGridViewTextBoxColumn ClnPessoaJuridica;
        private DataGridViewTextBoxColumn ClnCnpj;
        private DataGridViewButtonColumn ClnEndereco;
    }
}