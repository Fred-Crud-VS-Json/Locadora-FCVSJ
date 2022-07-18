using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Aplicacao.ModuloCondutor;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;

namespace LocadoraFCVSJ.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        public readonly ServicoCondutor _servicoCondutor;
        public readonly ServicoCliente _servicoCliente;
        private readonly ControleCondutorForm controleCondutorForm;

        public ControladorCondutor(ServicoCondutor servicoCondutor, ServicoCliente servicoCliente)
        {
            _servicoCondutor = servicoCondutor;
            _servicoCliente = servicoCliente;
            controleCondutorForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarCondutorForm tela = new(_servicoCondutor)
            {
                Condutor = new(),
                SalvarRegistro = _servicoCondutor.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutor();
        }

        public override void Editar()
        {
            Condutor? condutorSelecionado = ObterCondutor();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro.", "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarCondutorForm tela = new(_servicoCondutor)
            {
                Condutor = condutorSelecionado,
                SalvarRegistro = _servicoCondutor.Editar
            };

            tela.LblTitulo.Text = "Editando Registro";
            tela.PxbIcon.Image = Properties.Resources.edit_50px;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutor();
        }

        public override void Excluir()
        {
            Condutor? condutorSelecionado = ObterCondutor();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro.", "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Result<Condutor> resultadoExclusao = _servicoCondutor.Excluir(condutorSelecionado);

                if (resultadoExclusao.IsFailed)
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    CarregarCondutor();
            }
        }

        public override KryptonForm ObterTela()
        {
            CarregarCondutor();

            return controleCondutorForm;
        }

        private void CarregarCondutor()
        {
            Result<List<Condutor>> resultado = _servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
                controleCondutorForm.AtualizarGrid(resultado.Value);
        }

        public Condutor? ObterCondutor()
        {
            if (controleCondutorForm.ObterGrid().CurrentCell != null && controleCondutorForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleCondutorForm.ObterLinhaSelecionada();
                return _servicoCondutor.SelecionarTodos().Value.ElementAtOrDefault(index);
            }

            return null;
        }
    }
}