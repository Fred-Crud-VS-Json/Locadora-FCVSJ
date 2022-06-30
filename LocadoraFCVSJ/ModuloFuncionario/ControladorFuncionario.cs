using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;

namespace LocadoraFCVSJ.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        private readonly ServicoFuncionario _servicoFuncionario;
        private readonly ControleFuncionarioForm controleFuncionarioForm;

        public ControladorFuncionario(IRepositorioFuncionario repositorioFuncionario, ServicoFuncionario servicoFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario;
            _servicoFuncionario = servicoFuncionario;
            controleFuncionarioForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoFuncionario tela = new()
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

            RegistrarNovoFuncionario tela = new()
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
                _repositorioFuncionario.Excluir(funcionarioSelecionado);

            CarregarFuncionarios();
        }

        public override KryptonForm ObterTela()
        {
            CarregarFuncionarios();

            return controleFuncionarioForm;
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = _repositorioFuncionario.SelecionarTodos();

            controleFuncionarioForm.AtualizarGrid(funcionarios);
        }

        private Funcionario? ObterFuncionario()
        {
            if (controleFuncionarioForm.ObterGrid().CurrentCell != null && controleFuncionarioForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleFuncionarioForm.ObterLinhaSelecionada();
                return _repositorioFuncionario.SelecionarTodos().ElementAtOrDefault(index);
            }

            return null;
        }
    }
}