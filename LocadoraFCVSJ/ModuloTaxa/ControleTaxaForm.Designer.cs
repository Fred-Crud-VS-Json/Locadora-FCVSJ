using LocadoraFCVSJ.Compartilhado.Componentes;

namespace LocadoraFCVSJ.ModuloTaxa
{
    partial class ControleTaxaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControleTaxaForm));
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.GridTaxas = new System.Windows.Forms.DataGridView();
            this.ClnNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ClnEsp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnExcluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.customPanel2 = new LocadoraFCVSJ.Compartilhado.Componentes.CustomPanel();
            this.customPanel1 = new LocadoraFCVSJ.Compartilhado.Componentes.CustomPanel();
            this.BtnInserir = new LocadoraFCVSJ.Compartilhado.Componentes.CustomKryptonButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblRegistros = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridTaxas)).BeginInit();
            this.customPanel2.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office365White;
            this.kryptonPalette1.ButtonSpecs.FormClose.Image = global::LocadoraFCVSJ.Properties.Resources.close_20px1;
            this.kryptonPalette1.ButtonSpecs.FormMax.Image = global::LocadoraFCVSJ.Properties.Resources.maximize_button_20px1;
            this.kryptonPalette1.ButtonSpecs.FormMin.Image = global::LocadoraFCVSJ.Properties.Resources.subtract_20px1;
            this.kryptonPalette1.ButtonSpecs.FormRestore.Image = global::LocadoraFCVSJ.Properties.Resources.restore_window_20px1;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 5F;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Width = 1;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Rounding = 1F;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Border.Width = 1;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 12;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonPadding = new System.Windows.Forms.Padding(-1, 0, -1, -1);
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Open Sans SemiBold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // GridTaxas
            // 
            this.GridTaxas.AllowUserToAddRows = false;
            this.GridTaxas.AllowUserToDeleteRows = false;
            this.GridTaxas.BackgroundColor = System.Drawing.Color.White;
            this.GridTaxas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridTaxas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridTaxas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridTaxas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridTaxas.ColumnHeadersHeight = 45;
            this.GridTaxas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridTaxas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnNome,
            this.ClnValor,
            this.ClnTipo,
            this.ClnEditar,
            this.ClnEsp1,
            this.ClnExcluir});
            this.GridTaxas.EnableHeadersVisualStyles = false;
            this.GridTaxas.GridColor = System.Drawing.Color.White;
            this.GridTaxas.Location = new System.Drawing.Point(1, 0);
            this.GridTaxas.Name = "GridTaxas";
            this.GridTaxas.ReadOnly = true;
            this.GridTaxas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridTaxas.RowHeadersVisible = false;
            this.GridTaxas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(95)))), ((int)(((byte)(134)))));
            this.GridTaxas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.GridTaxas.RowTemplate.Height = 35;
            this.GridTaxas.RowTemplate.ReadOnly = true;
            this.GridTaxas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridTaxas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridTaxas.Size = new System.Drawing.Size(1069, 457);
            this.GridTaxas.TabIndex = 4;
            this.GridTaxas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridTaxas_CellClick);
            this.GridTaxas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridTaxas_CellFormatting);
            this.GridTaxas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.GridTaxas_CellPainting);
            // 
            // ClnNome
            // 
            this.ClnNome.HeaderText = "Nome";
            this.ClnNome.Name = "ClnNome";
            this.ClnNome.ReadOnly = true;
            this.ClnNome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnNome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClnNome.Width = 322;
            // 
            // ClnValor
            // 
            this.ClnValor.HeaderText = "Valor";
            this.ClnValor.Name = "ClnValor";
            this.ClnValor.ReadOnly = true;
            this.ClnValor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnValor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClnValor.Width = 321;
            // 
            // ClnTipo
            // 
            this.ClnTipo.HeaderText = "Tipo";
            this.ClnTipo.Name = "ClnTipo";
            this.ClnTipo.ReadOnly = true;
            this.ClnTipo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClnTipo.Width = 321;
            // 
            // ClnEditar
            // 
            this.ClnEditar.FillWeight = 20F;
            this.ClnEditar.HeaderText = "";
            this.ClnEditar.Name = "ClnEditar";
            this.ClnEditar.ReadOnly = true;
            this.ClnEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnEditar.Width = 50;
            // 
            // ClnEsp1
            // 
            this.ClnEsp1.FillWeight = 1F;
            this.ClnEsp1.HeaderText = "";
            this.ClnEsp1.Name = "ClnEsp1";
            this.ClnEsp1.ReadOnly = true;
            this.ClnEsp1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnEsp1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClnEsp1.Width = 5;
            // 
            // ClnExcluir
            // 
            this.ClnExcluir.FillWeight = 20F;
            this.ClnExcluir.HeaderText = "";
            this.ClnExcluir.Name = "ClnExcluir";
            this.ClnExcluir.ReadOnly = true;
            this.ClnExcluir.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClnExcluir.Width = 50;
            // 
            // customPanel2
            // 
            this.customPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.customPanel2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.customPanel2.BorderRadius = 5;
            this.customPanel2.BorderSize = 1;
            this.customPanel2.Controls.Add(this.GridTaxas);
            this.customPanel2.Location = new System.Drawing.Point(37, 218);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(1071, 461);
            this.customPanel2.TabIndex = 6;
            this.customPanel2.UnderlinedStyle = false;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.customPanel1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.customPanel1.BorderRadius = 5;
            this.customPanel1.BorderSize = 1;
            this.customPanel1.Controls.Add(this.BtnInserir);
            this.customPanel1.Controls.Add(this.panel5);
            this.customPanel1.Controls.Add(this.panel3);
            this.customPanel1.Controls.Add(this.panel1);
            this.customPanel1.Controls.Add(this.label2);
            this.customPanel1.Location = new System.Drawing.Point(37, 27);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(1072, 145);
            this.customPanel1.TabIndex = 6;
            this.customPanel1.UnderlinedStyle = false;
            // 
            // BtnInserir
            // 
            this.BtnInserir.AccessibleName = "";
            this.BtnInserir.Location = new System.Drawing.Point(18, 87);
            this.BtnInserir.Name = "BtnInserir";
            this.BtnInserir.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.BtnInserir.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.BtnInserir.OverrideDefault.Back.ColorAngle = 45F;
            this.BtnInserir.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.BtnInserir.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.BtnInserir.OverrideDefault.Border.ColorAngle = 45F;
            this.BtnInserir.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnInserir.OverrideDefault.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.BtnInserir.OverrideDefault.Border.Rounding = 5F;
            this.BtnInserir.OverrideDefault.Border.Width = 1;
            this.BtnInserir.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.BtnInserir.Size = new System.Drawing.Size(171, 44);
            this.BtnInserir.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.BtnInserir.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.BtnInserir.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.BtnInserir.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.BtnInserir.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnInserir.StateCommon.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.BtnInserir.StateCommon.Border.Rounding = 5F;
            this.BtnInserir.StateCommon.Border.Width = 1;
            this.BtnInserir.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnInserir.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.BtnInserir.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Open Sans SemiBold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnInserir.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(95)))), ((int)(((byte)(134)))));
            this.BtnInserir.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(95)))), ((int)(((byte)(134)))));
            this.BtnInserir.StatePressed.Back.ColorAngle = 135F;
            this.BtnInserir.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(95)))), ((int)(((byte)(134)))));
            this.BtnInserir.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(95)))), ((int)(((byte)(134)))));
            this.BtnInserir.StatePressed.Border.ColorAngle = 135F;
            this.BtnInserir.StatePressed.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnInserir.StatePressed.Border.Rounding = 5F;
            this.BtnInserir.StatePressed.Border.Width = 1;
            this.BtnInserir.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(126)))), ((int)(((byte)(168)))));
            this.BtnInserir.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(126)))), ((int)(((byte)(168)))));
            this.BtnInserir.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(126)))), ((int)(((byte)(168)))));
            this.BtnInserir.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(126)))), ((int)(((byte)(168)))));
            this.BtnInserir.StateTracking.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BtnInserir.StateTracking.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.BtnInserir.StateTracking.Border.Rounding = 5F;
            this.BtnInserir.StateTracking.Border.Width = 1;
            this.BtnInserir.TabIndex = 13;
            this.BtnInserir.Values.Text = "Nova Taxa";
            this.BtnInserir.Click += new System.EventHandler(this.BtnInserir_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(743, 87);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(110, 44);
            this.panel5.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registros";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(853, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(204, 44);
            this.panel3.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.LblRegistros);
            this.panel4.Location = new System.Drawing.Point(1, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(202, 41);
            this.panel4.TabIndex = 10;
            // 
            // LblRegistros
            // 
            this.LblRegistros.AutoSize = true;
            this.LblRegistros.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(150)))));
            this.LblRegistros.Location = new System.Drawing.Point(37, 8);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(0, 26);
            this.LblRegistros.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.panel1.Location = new System.Drawing.Point(18, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 2);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(187)))));
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "GESTÃO DE TAXAS";
            // 
            // ControleTaxaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1146, 710);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.customPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControleTaxaForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora FCVSJ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControleTaxaForm_FormClosed);
            this.Load += new System.EventHandler(this.ControleTaxaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridTaxas)).EndInit();
            this.customPanel2.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private DataGridView GridTaxas;
        private CustomPanel customPanel2;
        private CustomPanel customPanel1;
        private Panel panel5;
        private Label label1;
        private Panel panel3;
        private Panel panel4;
        private Label LblRegistros;
        private Panel panel1;
        private Label label2;
        private CustomKryptonButton BtnInserir;
        private DataGridViewTextBoxColumn ClnNome;
        private DataGridViewTextBoxColumn ClnValor;
        private DataGridViewTextBoxColumn ClnTipo;
        private DataGridViewButtonColumn ClnEditar;
        private DataGridViewTextBoxColumn ClnEsp1;
        private DataGridViewButtonColumn ClnExcluir;
    }
}