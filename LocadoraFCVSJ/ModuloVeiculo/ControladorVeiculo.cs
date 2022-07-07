using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly IRepositorioVeiculo _repositorioVeiculo;
        private readonly ServicoVeiculo _servicoVeiculo;
        private readonly ControleVeiculoForm controleVeiculoForm;

        public ControladorVeiculo(IRepositorioVeiculo repositorioVeiculo, ServicoVeiculo servicoVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
            _servicoVeiculo = servicoVeiculo;
            controleVeiculoForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoVeiculo tela = new()
            {
                Veiculo = new(),
                SalvarRegistro = _servicoVeiculo.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Editar()
        {
            Veiculo? veiculoSelecionado = ObterVeiculo();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro.", "Edição de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarNovoVeiculo tela = new()
            {
                Veiculo = veiculoSelecionado,
                SalvarRegistro = _servicoVeiculo.Editar
            };

            tela.label1.Text = "            Editando Registro";
            tela.label4.Text = "Altere abaixo as informações que deseja do veiculo selecionado.";


            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            Veiculo? veiculoSelecionado = ObterVeiculo();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro.", "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Funcionário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                _repositorioVeiculo.Excluir(veiculoSelecionado);

            CarregarVeiculos();
        }

        public override KryptonForm ObterTela()
        {
            CarregarVeiculos();

            return controleVeiculoForm;
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = _repositorioVeiculo.SelecionarTodos();

            controleVeiculoForm.AtualizarGrid(veiculos);
        }

        private Veiculo? ObterVeiculo()
        {
            if (controleVeiculoForm.ObterGrid().CurrentCell != null && controleVeiculoForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleVeiculoForm.ObterLinhaSelecionada();
                return _repositorioVeiculo.SelecionarTodos().ElementAtOrDefault(index);
            }

            return null;
        }
    }
}
