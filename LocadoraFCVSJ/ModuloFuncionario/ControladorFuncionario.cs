using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;

namespace LocadoraFCVSJ.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        public readonly ServicoFuncionario _servicoFuncionario;
        private readonly ControleFuncionarioForm controleFuncionarioForm;

        public ControladorFuncionario(ServicoFuncionario servicoFuncionario)
        {
            _servicoFuncionario = servicoFuncionario;
            controleFuncionarioForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarFuncionarioForm tela = new()
            {
                Funcionario = new(),
                SalvarRegistro = _servicoFuncionario.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Editar()
        {
            Funcionario? funcionarioSelecionado = ObterFuncionario();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro.", "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarFuncionarioForm tela = new()
            {
                Funcionario = funcionarioSelecionado,
                SalvarRegistro = _servicoFuncionario.Editar
            };

            tela.LblTitulo.Text = "Editando Registro";
            tela.PxbIcon.Image = Properties.Resources.edit_50px;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            Funcionario? funcionarioSelecionado = ObterFuncionario();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro.", "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Funcionário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Result<Funcionario> resultadoExclusao = _servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsFailed)
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    CarregarFuncionarios();
            }
        }

        public override KryptonForm ObterTela()
        {
            CarregarFuncionarios();

            return controleFuncionarioForm;
        }

        private void CarregarFuncionarios()
        {
            Result<List<Funcionario>> resultado = _servicoFuncionario.SelecionarTodos();

            if(resultado.IsSuccess)
                controleFuncionarioForm.AtualizarGrid(resultado.Value);
        }

        private Funcionario? ObterFuncionario()
        {
            if (controleFuncionarioForm.ObterGrid().CurrentCell != null && controleFuncionarioForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleFuncionarioForm.ObterLinhaSelecionada();
                return _servicoFuncionario.SelecionarTodos().Value.ElementAtOrDefault(index);
            }

            return null;
        }
    }
}