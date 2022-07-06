using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCondutor;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;

namespace LocadoraFCVSJ.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly RepositorioCondutor _repositorioCondutor;
        private readonly ServicoCondutor _servicoCondutor;
        private readonly ControleCondutorForm controleCondutorForm;

        public ControladorCondutor(RepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor)
        {
            _repositorioCondutor = repositorioCondutor;
            _servicoCondutor = servicoCondutor;
            controleCondutorForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoCondutor tela = new()
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
                MessageBox.Show("Selecione um condutor primeiro.", "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarNovoCondutor tela = new()
            {
                Condutor = condutorSelecionado,
                SalvarRegistro = _servicoCondutor.Editar
            };

            tela.label1.Text = "        Editando Registro";
            tela.label4.Text = "Altere abaixo as informações que deseja do condutor selecionado.";


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
                _repositorioCondutor.Excluir(condutorSelecionado);

            CarregarCondutor();
        }

        public override KryptonForm ObterTela()
        {
            CarregarCondutor();

            return controleCondutorForm;
        }

        private void CarregarCondutor()
        {
            List<Condutor> condutores = _repositorioCondutor.SelecionarTodos();

            controleCondutorForm.AtualizarGrid(condutores);
        }

        public Condutor? ObterCondutor()
        {
            if (controleCondutorForm.ObterGrid().CurrentCell != null && controleCondutorForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleCondutorForm.ObterLinhaSelecionada();
                return _repositorioCondutor.SelecionarTodos().ElementAtOrDefault(index);
            }

            return null;
        }
    }
}
