using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;

namespace LocadoraFCVSJ.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        public readonly ServicoCliente _servicoCliente;
        private readonly ControleClienteForm controleClienteForm;

        public ControladorCliente(ServicoCliente servicoCliente)
        {
            _servicoCliente = servicoCliente;
            controleClienteForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarClienteForm tela = new()
            {
                Cliente = new(),
                SalvarRegistro = _servicoCliente.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Editar()
        {
            Cliente? clienteSelecionado = ObterCliente();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro.", "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarClienteForm tela = new()
            {
                Cliente = clienteSelecionado,
                SalvarRegistro = _servicoCliente.Editar
            };

            tela.LblTitulo.Text = "Editando Registro";
            tela.PxbIcon.Image = Properties.Resources.edit_50px;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Excluir()
        {
            Cliente? clienteSelecionado = ObterCliente();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro.", "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Result<Cliente> resultadoExclusao = _servicoCliente.Excluir(clienteSelecionado);

                if (resultadoExclusao.IsFailed)
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    CarregarClientes();
            }
        }

        public override KryptonForm ObterTela()
        {
            CarregarClientes();

            return controleClienteForm;
        }

        private void CarregarClientes()
        {
            Result<List<Cliente>> resultado = _servicoCliente.SelecionarTodos();

            if (resultado.IsSuccess)
                controleClienteForm.AtualizarGrid(resultado.Value);
        }

        public Cliente? ObterCliente()
        {
            if (controleClienteForm.ObterGrid().CurrentCell != null && controleClienteForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleClienteForm.ObterLinhaSelecionada();
                return _servicoCliente.SelecionarTodos().Value.ElementAtOrDefault(index);
            }

            return null;
        }
    }
}