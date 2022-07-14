using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloTaxa;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloTaxa;

namespace LocadoraFCVSJ.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        private readonly ServicoTaxa _servicoTaxa;
        private readonly ControleTaxaForm controleTaxaForm;

        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
            _servicoTaxa = servicoTaxa;
            controleTaxaForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovaTaxaForm tela = new()
            {
                Taxa = new(),
                SalvarRegistro = _servicoTaxa.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Editar()
        {
            Taxa? taxaSelecionado = ObterTaxa();

            if (taxaSelecionado == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro.", "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarNovaTaxaForm tela = new()
            {
                Taxa = taxaSelecionado,
                SalvarRegistro = _servicoTaxa.Editar
            };

            tela.LblTitulo.Text = "      Editando Registro";
            tela.LblInformacao.Text = "Insira o novo nome da taxa no campo abaixo";


            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            Taxa? taxaSelecionado = ObterTaxa();

            if (taxaSelecionado == null)
            {
                MessageBox.Show("Selecione um taxa primeiro.", "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                _servicoTaxa.Excluir(taxaSelecionado);

            CarregarTaxas();
        }

        public override KryptonForm ObterTela()
        {
            CarregarTaxas();

            return controleTaxaForm;
        }

        private void CarregarTaxas()
        {
            Result<List<Taxa>> resultado = _servicoTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
                controleTaxaForm.AtualizarGrid(resultado.Value);
        }

        private Taxa? ObterTaxa()
        {
            if (controleTaxaForm.ObterGrid().CurrentCell != null && controleTaxaForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleTaxaForm.ObterLinhaSelecionada();
                return _servicoTaxa.SelecionarTodos().Value.ElementAtOrDefault(index);
            }

            return null;
        }
    }
}