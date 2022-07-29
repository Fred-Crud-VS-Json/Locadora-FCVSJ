using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloLocacao;

namespace LocadoraFCVSJ.ModuloLocacao
{
    public partial class ControleLocacaoForm : KryptonForm
    {
        private readonly ControladorLocacao _controladorLocacao;

        public ControleLocacaoForm(ControladorLocacao controladorLocacao)
        {
            InitializeComponent();
            _controladorLocacao = controladorLocacao;
        }

        public void AtualizarGrid(List<Locacao> locacao)
        {
            GridLocacoes.Rows.Clear();

            locacao.ForEach(x =>
            {
                GridLocacoes.Rows.Add(x.DataLocacao);
            });

            LblRegistros.Text = _controladorLocacao._servicoLocacao.SelecionarTodos().Value.Count + " locações";

            GridLocacoes.ClearSelection();
        }

        public DataGridView ObterGrid()
        {
            return GridLocacoes;
        }

        public int ObterLinhaSelecionada()
        {
            return GridLocacoes.CurrentCell.RowIndex;
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {

        }
    }
}