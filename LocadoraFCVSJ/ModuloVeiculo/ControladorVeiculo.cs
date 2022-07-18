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
        public readonly ServicoVeiculo _servicoVeiculo;
        public readonly ServicoGrupo _servicoGrupo;
        private readonly ControleVeiculoForm controleVeiculoForm;

        public ControladorVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupo servidoGrupo)
        {
            _servicoVeiculo = servicoVeiculo;
            _servicoGrupo = servidoGrupo;
            
            controleVeiculoForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarVeiculoForm tela = new(_servicoGrupo)
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
                MessageBox.Show("Selecione um veiculo primeiro.", "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarVeiculoForm tela = new(_servicoGrupo)
            {
                Veiculo = veiculoSelecionado,
                SalvarRegistro = _servicoVeiculo.Editar
            };

            tela.LblTitulo.Text = "Editando Registro";
            tela.PxbIcon.Image = Properties.Resources.edit_50px;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            Veiculo? veiculoSelecionado = ObterVeiculo();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro.", "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Result<Veiculo> resultadoExclusao = _servicoVeiculo.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsFailed)
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    CarregarVeiculos();
            }
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