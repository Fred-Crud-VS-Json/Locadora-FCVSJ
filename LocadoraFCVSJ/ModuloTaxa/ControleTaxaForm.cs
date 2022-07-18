using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloTaxa;

namespace LocadoraFCVSJ.ModuloTaxa
{
    public partial class ControleTaxaForm : KryptonForm
    {
        private readonly ControladorTaxa _controladorTaxa;

        public ControleTaxaForm(ControladorTaxa controladorTaxa)
        {
            InitializeComponent();
            _controladorTaxa = controladorTaxa;   
        }

        public void AtualizarGrid(List<Taxa> taxas)
        {
            GridTaxas.Rows.Clear();

            taxas.ForEach(x =>
            {
                GridTaxas.Rows.Add(x.Nome, "R$ " + x.Valor.ToString("F2"), x.TipoCalculoTaxa);
            });

            LblRegistros.Text = _controladorTaxa._servicoTaxa.SelecionarTodos().Value.Count + " taxa(s)";

            GridTaxas.ClearSelection();
        }

        public int ObterLinhaSelecionada()
        {
            return GridTaxas.CurrentCell.RowIndex;
        }

        public DataGridView ObterGrid()
        {
            return GridTaxas;
        }

        private void ControleTaxaForm_Load(object sender, EventArgs e)
        {
            GridTaxas.ClearSelection();
        }

        private void ControleTaxaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TelaPrincipal.Instancia.WindowState = FormWindowState.Normal;
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            GridTaxas.ClearSelection();
            _controladorTaxa.Inserir();
        }

        private void GridTaxas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3:
                    _controladorTaxa.Editar();
                    GridTaxas.ClearSelection();
                    break;

                case 5:
                    _controladorTaxa.Excluir();
                    break;
            }
        }

        private void GridTaxas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image editarImg = Properties.Resources.edit_blue_30px;
            Image excluirImg = Properties.Resources.close_blue_30px;

            if (e.RowIndex < 0)
                return;

            switch (e.ColumnIndex)
            {
                case 3:
                    e.ConfigurarImagem(editarImg);
                    break;

                case 5:
                    e.ConfigurarImagem(excluirImg);
                    break;
            }
        }

        private void GridTaxas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = GridTaxas.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (e.ColumnIndex)
            {
                case 3:
                    cell.ToolTipText = "Editar Registro";
                    break;

                case 4:
                    cell.ToolTipText = "";
                    break;

                case 5:
                    cell.ToolTipText = "Excluir Registro";
                    break;
            }
        }
    }
}