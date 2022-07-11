﻿using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloCondutor;

namespace LocadoraFCVSJ.ModuloCondutor
{
    public partial class ControleCondutorForm : KryptonForm
    {
        private readonly ControladorCondutor _controladorCondutor;

        public ControleCondutorForm(ControladorCondutor controladorCondutor)
        {
            InitializeComponent();
            _controladorCondutor = controladorCondutor;
        }

        public void AtualizarGrid(List<Condutor> condutores)
        {
            GridCondutores.Rows.Clear();

            int z = 0;

            condutores.ForEach(x =>
            {
                GridCondutores.Rows.Add(x.Id, x.Nome, x.CPF, x.CNH, x.DataVencimento.ToString("dd/MM/yyyy"), x.Email, x.Telefone, x.CNPJ, x.Rua);

                z++;

                for (int i = z; i <= GridCondutores.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(x.CNPJ))
                        GridCondutores.Rows[i - 1].Cells[6].Value = "Não";
                    else
                        GridCondutores.Rows[i - 1].Cells[6].Value = "Sim";
                        GridCondutores.Rows[i - 1].Cells[7].Value = x.CNPJ;
                }
            });

            GridCondutores.ClearSelection();
        }

        public int ObterLinhaSelecionada()
        {
            return GridCondutores.CurrentCell.RowIndex;
        }

        public DataGridView ObterGrid()
        {
            return GridCondutores;
        }

        private void ControleClienteForm_Load(object sender, EventArgs e)
        {
            GridCondutores.ClearSelection();
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorCondutor.Inserir();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _controladorCondutor.Editar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            _controladorCondutor.Excluir();
        }

        private void GridCondutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // TO-DO
        }

        private void GridCondutores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image someImage = Properties.Resources.search_more_25px;

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 8)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = someImage.Width;
                var h = someImage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void GridCondutores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridCondutores.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == 8)
                cell.ToolTipText = "Visualizar Endereço";
        }
    }
}