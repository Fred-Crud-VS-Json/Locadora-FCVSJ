using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloTaxa;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloTaxa;

namespace LocadoraFCVSJ.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        public readonly ServicoTaxa _servicoTaxa;
        private readonly ControleTaxaForm controleTaxaForm;

        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
            _servicoTaxa = servicoTaxa;
            controleTaxaForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarTaxaForm tela = new()
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
            Taxa? taxaSelecionada = ObterTaxa();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro.", "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarTaxaForm tela = new()
            {
                Taxa = taxaSelecionada,
                SalvarRegistro = _servicoTaxa.Editar
            };

            tela.LblTitulo.Text = "Editando Registro";
            tela.PxbIcon.Image = Properties.Resources.edit_50px;

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
            {
                Result<Taxa> resultadoExclusao = _servicoTaxa.Excluir(taxaSelecionada);

                if (resultadoExclusao.IsFailed)
                    MessageBox.Show(resultadoExclusao.Errors[0].Message, "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    CarregarTaxas();
            }
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