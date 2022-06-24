using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;

namespace LocadoraFCVSJ.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        private readonly RepositorioTaxa _repositorioTaxa;
        private readonly ControleTaxaForm controleTaxaForm;

        public ControladorTaxa(RepositorioTaxa repositorioTaxa)
        {
            _repositorioTaxa = repositorioTaxa;
            controleTaxaForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovaTaxaForm tela = new()
            {
                Taxa = new(),
                SalvarRegistro = _repositorioTaxa.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Editar()
        {
            Taxa? taxaSelecionada = ObterTaxa();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro.", "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarNovaTaxaForm tela = new()
            {
                Taxa = taxaSelecionada,
                SalvarRegistro = _repositorioTaxa.Editar
            };

            tela.label1.Text = "      Editando Registro";
            tela.label4.Text = "Insira as novas informações da taxa no campo abaixo";


            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            Taxa? taxaSelecionada = ObterTaxa();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro.", "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                _repositorioTaxa.Excluir(taxaSelecionada);

            CarregarTaxas();
        }

        public override KryptonForm ObterTela()
        {
            CarregarTaxas();

            return controleTaxaForm;
        }

        private void CarregarTaxas()
        {
            List<Taxa> taxas = _repositorioTaxa.SelecionarTodos();

            controleTaxaForm.AtualizarGrid(taxas);
        }

        private Taxa? ObterTaxa()
        {
            if (controleTaxaForm.ObterGrid().CurrentCell != null && controleTaxaForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleTaxaForm.ObterLinhaSelecionada();
                return _repositorioTaxa.SelecionarTodos().ElementAtOrDefault(index);
            }

            return null;
        }
    }
}