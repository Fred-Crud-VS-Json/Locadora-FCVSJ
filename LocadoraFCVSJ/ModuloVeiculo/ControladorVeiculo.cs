using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly ServicoVeiculo _servicoVeiculo;
        private readonly ServicoGrupo _servidoGrupo;
        private readonly ControleVeiculoForm controleVeiculoForm;

        public ControladorVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupo servidoGrupo)
        {
            _servicoVeiculo = servicoVeiculo;
            _servidoGrupo = servidoGrupo;
            
            controleVeiculoForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoVeiculo tela = new(_servicoVeiculo, _servidoGrupo)
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

            RegistrarNovoVeiculo tela = new(_servicoVeiculo, _servidoGrupo)
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
                _servicoVeiculo.Excluir(veiculoSelecionado);

            CarregarVeiculos();
        }

        public override KryptonForm ObterTela()
        {
            CarregarVeiculos();

            return controleVeiculoForm;
        }

        private void CarregarVeiculos()
        {
            Result<List<Veiculo>> resultado = _servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
                controleVeiculoForm.AtualizarGrid(resultado.Value);
        }

        public Veiculo? ObterVeiculo()
        {
            if (controleVeiculoForm.ObterGrid().CurrentCell != null && controleVeiculoForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleVeiculoForm.ObterLinhaSelecionada();
                return _servicoVeiculo.SelecionarTodos().Value.ElementAtOrDefault(index);
            }

            return null;
        }
    }
}
