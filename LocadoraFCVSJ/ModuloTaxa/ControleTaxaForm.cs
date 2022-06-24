using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using System.Globalization;

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
                GridTaxas.Rows.Add(x.Id, x.Nome, "R$ " + x.Valor.ToString("F2"), x.TipoCalculoTaxa);
            });

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

        private void ControleGrupoForm_Load(object sender, EventArgs e)
        {
            GridTaxas.ClearSelection();
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            _controladorTaxa.Inserir();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            _controladorTaxa.Editar();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            _controladorTaxa.Excluir();
        }
    }
}