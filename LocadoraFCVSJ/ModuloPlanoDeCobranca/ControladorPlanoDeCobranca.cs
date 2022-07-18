using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        public readonly ServicoGrupo _servicoGrupo;
        public readonly ServicoPlanoDeCobranca _servicoPlanoDeCobranca;
        private readonly ControlePlanoDeCobrancaForm controlePlanoDeCobrancaForm;

        public ControladorPlanoDeCobranca(ServicoGrupo servicoGrupo, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            _servicoGrupo = servicoGrupo;
            _servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            controlePlanoDeCobrancaForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarPlanoDeCobrancaForm tela = new(_servicoPlanoDeCobranca, _servicoGrupo)
            {
                PlanoDeCobranca = new(),
                SalvarRegistro = _servicoPlanoDeCobranca.Inserir
            };

            if (tela.CbxGrupo.Items.Count == 0)
            {
                MessageBox.Show("Não há nenhum grupo disponível para cadastrar um plano de cobrança.", "Locadora FCVSJ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanosDeCobranca();
        }

        public override void Editar()
        {
            PlanoDeCobranca? planoSelecionado = ObterPlanoDeCobranca();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro.", "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarPlanoDeCobrancaForm tela = new(_servicoPlanoDeCobranca, _servicoGrupo)
            {
                PlanoDeCobranca = planoSelecionado,
                SalvarRegistro = _servicoPlanoDeCobranca.Editar
            };

            tela.LblTitulo.Text = "Editando Registro";
            tela.PxbIcon.Image = Properties.Resources.edit_50px;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanosDeCobranca();
        }

        public override void Excluir()
        {
            PlanoDeCobranca? planoSelecionado = ObterPlanoDeCobranca();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro.", "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Plano de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Result<PlanoDeCobranca> resultadoExclusao = _servicoPlanoDeCobranca.Excluir(planoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanosDeCobranca();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override KryptonForm ObterTela()
        {
            CarregarPlanosDeCobranca();

            return controlePlanoDeCobrancaForm;
        }

        private void CarregarPlanosDeCobranca()
        {
            Result<List<PlanoDeCobranca>> resultado = _servicoPlanoDeCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
                controlePlanoDeCobrancaForm.AtualizarGrid(resultado.Value);
        }

        public PlanoDeCobranca? ObterPlanoDeCobranca()
        {
            if (controlePlanoDeCobrancaForm.ObterGrid().CurrentCell != null && controlePlanoDeCobrancaForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controlePlanoDeCobrancaForm.ObterLinhaSelecionada();
                return _servicoPlanoDeCobranca.SelecionarTodos().Value.ElementAtOrDefault(index);
            }

            return null;
        }
    }
}