using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloLocacao;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloLocacao;

namespace LocadoraFCVSJ.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        public readonly ServicoLocacao _servicoLocacao;
        private readonly ControleLocacaoForm controleLocacaoForm;

        public ControladorLocacao(ServicoLocacao servicoLocacao)
        {
            _servicoLocacao = servicoLocacao;
            controleLocacaoForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarLocacaoForm tela = new()
            {
                Locacao = new(),
                SalvarRegistro = _servicoLocacao.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarLocacao();
        }

        public override void Editar()
        {
            Locacao? locacaoSelecionada = ObterLocacao();

            if (locacaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma locação primeiro.", "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarLocacaoForm tela = new()
            {
                Locacao = locacaoSelecionada,
                SalvarRegistro = _servicoLocacao.Editar
            };

            tela.LblTitulo.Text = "Editando Registro";
            tela.PxbIcon.Image = Properties.Resources.edit_50px;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarLocacao();
        }

        public override void Excluir()
        {
            Locacao? locacaoSelecionada = ObterLocacao();

            if (locacaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma locação primeiro.", "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Result<Locacao> resultadoExclusao = _servicoLocacao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsFailed)
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    CarregarLocacao();
            }
        }

        public override KryptonForm ObterTela()
        {
            CarregarLocacao();

            return controleLocacaoForm;
        }

        private void CarregarLocacao()
        {
            Result<List<Locacao>> resultado = _servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
                controleLocacaoForm.AtualizarGrid(resultado.Value);
        }

        private Locacao? ObterLocacao()
        {
            if (controleLocacaoForm.ObterGrid().CurrentCell != null && controleLocacaoForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleLocacaoForm.ObterLinhaSelecionada();
                return _servicoLocacao.SelecionarTodos().Value.ElementAtOrDefault(index);
            }

            return null;
        }
    }
}
