using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;

namespace LocadoraFCVSJ.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private readonly ServicoFuncionario _servicoFuncionario;
        private readonly ControleFuncionarioForm controleFuncionarioForm;

        public ControladorFuncionario(ServicoFuncionario servicoFuncionario)
        {
            _servicoFuncionario = servicoFuncionario;
            controleFuncionarioForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoFuncionarioForm tela = new()
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

            RegistrarNovoFuncionarioForm tela = new()
            {
                Funcionario = funcionarioSelecionado,
                SalvarRegistro = _servicoFuncionario.Editar
            };

            tela.label1.Text = "            Editando Registro";
            tela.label4.Text = "Altere abaixo as informações que deseja do funcionário selecionado.";


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
                _servicoFuncionario.Excluir(funcionarioSelecionado);

            CarregarFuncionarios();
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
                return _servicoFuncionario.SelecionarPorId((Guid)controleFuncionarioForm.ObterGrid().CurrentCell.Value).Value;
            }

            return null;
        }
    }
}