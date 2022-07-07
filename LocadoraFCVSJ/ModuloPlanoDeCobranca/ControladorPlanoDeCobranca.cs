using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;

namespace LocadoraFCVSJ.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private readonly ServicoGrupo _servicoGrupo;
        private readonly ServicoPlanoDeCobranca _servicoPlanoDeCobranca;
        private readonly ControlePlanoDeCobrancaForm controlePlanoDeCobrancaForm;

        public ControladorPlanoDeCobranca(ServicoGrupo servicoGrupo, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            _servicoGrupo = servicoGrupo;
            _servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            controlePlanoDeCobrancaForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoPlanoDeCobrancaForm tela = new(_servicoGrupo)
            {
                PlanoDeCobranca = new(),
                SalvarRegistro = _servicoPlanoDeCobranca.Inserir
            };

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

            RegistrarNovoPlanoDeCobrancaForm tela = new(_servicoGrupo)
            {
                PlanoDeCobranca = planoSelecionado,
                SalvarRegistro = _servicoPlanoDeCobranca.Editar
            };

            tela.label1.Text = "                Editando Registro";

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
                _servicoPlanoDeCobranca.Excluir(planoSelecionado);

            CarregarPlanosDeCobranca();
        }

        public override KryptonForm ObterTela()
        {
            CarregarPlanosDeCobranca();

            return controlePlanoDeCobrancaForm;
        }

        private void CarregarPlanosDeCobranca()
        {
            List<PlanoDeCobranca> planosDeCobranca = _servicoPlanoDeCobranca.SelecionarTodos();

            controlePlanoDeCobrancaForm.AtualizarGrid(planosDeCobranca);
        }

        private PlanoDeCobranca? ObterPlanoDeCobranca()
        {
            if (controlePlanoDeCobrancaForm.ObterGrid().CurrentCell != null && controlePlanoDeCobrancaForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controlePlanoDeCobrancaForm.ObterLinhaSelecionada();
                return _servicoPlanoDeCobranca.SelecionarTodos().ElementAtOrDefault(index);
            }

            return null;
        }
    }
}