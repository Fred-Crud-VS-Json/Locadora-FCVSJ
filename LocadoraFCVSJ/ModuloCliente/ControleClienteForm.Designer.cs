namespace LocadoraFCVSJ.ModuloCliente
{
    partial class ControleClienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControleClienteForm));
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
            this.GridClientes = new System.Windows.Forms.DataGridView();
            this.ClnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnCnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.GridClientes)).BeginInit();
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
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
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
            this.panel1.Location = new System.Drawing.Point(306, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 75);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 71);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestão de Clientes";
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
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1361, 52);
            this.panel4.TabIndex = 2;
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Location = new System.Drawing.Point(105, 7);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.OverrideDefault.Back.Color1 = System.Drawing.Color.IndianRed;
            this.BtnExcluir.OverrideDefault.Back.Color2 = System.Drawing.Color.IndianRed;
            this.BtnExcluir.Size = new System.Drawing.Size(41, 38);
            this.BtnExcluir.StateCommon.Back.Color1 = System.Drawing.Color.IndianRed;
            this.BtnExcluir.StateCommon.Back.Color2 = System.Drawing.Color.IndianRed;
            this.BtnExcluir.StateCommon.Back.Image = global::LocadoraFCVSJ.Properties.Resources.close_white_30px;
            this.BtnExcluir.StateCommon.Back.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.BtnExcluir.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnExcluir.StateCommon.Border.Rounding = 4F;
            this.BtnExcluir.TabIndex = 2;
            this.BtnExcluir.Values.Text = "";
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(58, 7);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.BtnEditar.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.BtnEditar.Size = new System.Drawing.Size(41, 38);
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
            this.BtnEditar.Values.Text = "";
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnInserir
            // 
            this.BtnInserir.Location = new System.Drawing.Point(11, 7);
            this.BtnInserir.Name = "BtnInserir";
            this.BtnInserir.OverrideDefault.Back.Color1 = System.Drawing.Color.MediumSeaGreen;
            this.BtnInserir.OverrideDefault.Back.Color2 = System.Drawing.Color.MediumSeaGreen;
            this.BtnInserir.Size = new System.Drawing.Size(41, 38);
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
            this.BtnInserir.Values.Text = "";
            this.BtnInserir.Click += new System.EventHandler(this.BtnInserir_Click);
            // 
            // GridClientes
            // 
            this.GridClientes.AllowUserToAddRows = false;
            this.GridClientes.AllowUserToDeleteRows = false;
            this.GridClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridClientes.BackgroundColor = System.Drawing.Color.White;
            this.GridClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(219)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridClientes.ColumnHeadersHeight = 45;
            this.GridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnId,
            this.ClnNome,
            this.ClnCpf,
            this.ClnCnh,
            this.ClnEmail,
            this.ClnTelefone,
            this.ClnPessoaJuridica,
            this.ClnCnpj,
            this.ClnEndereco});
            this.GridClientes.EnableHeadersVisualStyles = false;
            this.GridClientes.GridColor = System.Drawing.Color.White;
            this.GridClientes.Location = new System.Drawing.Point(12, 190);
            this.GridClientes.Name = "GridClientes";
            this.GridClientes.ReadOnly = true;
            this.GridClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridClientes.RowHeadersVisible = false;
            this.GridClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(130)))), ((int)(((byte)(229)))));
            this.GridClientes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GridClientes.RowTemplate.Height = 25;
            this.GridClientes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridClientes.Size = new System.Drawing.Size(1363, 468);
            this.GridClientes.TabIndex = 4;
            this.GridClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridClientes_CellClick);
            this.GridClientes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridClientes_CellFormatting);
            this.GridClientes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GridClientes_CellPainting);
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
            // ClnNome
            // 
            this.ClnNome.FillWeight = 95F;
            this.ClnNome.HeaderText = "Nome";
            this.ClnNome.Name = "ClnNome";
            this.ClnNome.ReadOnly = true;
            this.ClnNome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnNome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnCpf
            // 
            this.ClnCpf.FillWeight = 40F;
            this.ClnCpf.HeaderText = "CPF";
            this.ClnCpf.Name = "ClnCpf";
            this.ClnCpf.ReadOnly = true;
            this.ClnCpf.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnCpf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnCnh
            // 
            this.ClnCnh.FillWeight = 66.81472F;
            this.ClnCnh.HeaderText = "CNH";
            this.ClnCnh.Name = "ClnCnh";
            this.ClnCnh.ReadOnly = true;
            this.ClnCnh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnCnh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnEmail
            // 
            this.ClnEmail.FillWeight = 80F;
            this.ClnEmail.HeaderText = "E-mail";
            this.ClnEmail.Name = "ClnEmail";
            this.ClnEmail.ReadOnly = true;
            this.ClnEmail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnTelefone
            // 
            this.ClnTelefone.FillWeight = 66.81472F;
            this.ClnTelefone.HeaderText = "Telefone";
            this.ClnTelefone.Name = "ClnTelefone";
            this.ClnTelefone.ReadOnly = true;
            this.ClnTelefone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnTelefone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnPessoaJuridica
            // 
            this.ClnPessoaJuridica.FillWeight = 15F;
            this.ClnPessoaJuridica.HeaderText = "PJ";
            this.ClnPessoaJuridica.Name = "ClnPessoaJuridica";
            this.ClnPessoaJuridica.ReadOnly = true;
            this.ClnPessoaJuridica.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnPessoaJuridica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnCnpj
            // 
            this.ClnCnpj.FillWeight = 66.81472F;
            this.ClnCnpj.HeaderText = "CNPJ";
            this.ClnCnpj.Name = "ClnCnpj";
            this.ClnCnpj.ReadOnly = true;
            this.ClnCnpj.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnCnpj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClnEndereco
            // 
            this.ClnEndereco.FillWeight = 25F;
            this.ClnEndereco.HeaderText = "Endereço";
            this.ClnEndereco.Name = "ClnEndereco";
            this.ClnEndereco.ReadOnly = true;
            this.ClnEndereco.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClnEndereco.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClnEndereco.Text = "";
            // 
            // ControleClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 670);
            this.Controls.Add(this.GridClientes);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControleClienteForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora FCVSJ";
            this.Load += new System.EventHandler(this.ControleClienteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridClientes)).EndInit();
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
        private DataGridView GridClientes;
        private DataGridViewTextBoxColumn ClnId;
        private DataGridViewTextBoxColumn ClnNome;
        private DataGridViewTextBoxColumn ClnCpf;
        private DataGridViewTextBoxColumn ClnCnh;
        private DataGridViewTextBoxColumn ClnEmail;
        private DataGridViewTextBoxColumn ClnTelefone;
        private DataGridViewTextBoxColumn ClnPessoaJuridica;
        private DataGridViewTextBoxColumn ClnCnpj;
        private DataGridViewButtonColumn ClnEndereco;
    }
}