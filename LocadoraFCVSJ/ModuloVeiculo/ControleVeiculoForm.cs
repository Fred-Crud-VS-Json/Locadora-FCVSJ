using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public partial class ControleVeiculoForm : KryptonForm
    {
        private readonly ControladorVeiculo _controladorVeiculo;
        public ControleVeiculoForm(ControladorVeiculo controladorVeiculo)
        {
            InitializeComponent();
            _controladorVeiculo = controladorVeiculo;
        }

        private void GridVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                Veiculo? veiculo = _controladorVeiculo.ObterVeiculo();

                new VisualizarVeiculoForm(veiculo).ShowDialog();
            }
        }

        public void AtualizarGrid(List<Veiculo> veiculos)
        {
            GridVeiculos.Rows.Clear();

            veiculos.ForEach(x =>
            {
                GridVeiculos.Rows.Add(x.Id, x.Grupo, x.Modelo, x.Marca, x.Placa);
            });

            GridVeiculos.ClearSelection();
        }

        public DataGridView ObterGrid()
        {
            return GridVeiculos;
        }

        public int ObterLinhaSelecionada()
        {
            return GridVeiculos.CurrentCell.RowIndex;
        }

        private void GridVeiculos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image someImage = Properties.Resources.search_more_25px;

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
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

        private void GridVeiculos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridVeiculos.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (e.ColumnIndex == 5)
                cell.ToolTipText = "Visualização Completa";
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorVeiculo.Inserir();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _controladorVeiculo.Editar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            _controladorVeiculo.Excluir();
        }
    }
}