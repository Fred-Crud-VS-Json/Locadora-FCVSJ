using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraFCVSJ.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly RepositorioClienteEmBancoDeDados _repositorioCliente;
        private readonly ControleClienteForm controleClienteForm;

        public ControladorCliente(RepositorioClienteEmBancoDeDados repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
            controleClienteForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoCliente tela = new()
            {
                Cliente = new(),
                SalvarRegistro = _repositorioCliente.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK);
                CarregarClientes();
        }

        public override void Editar()
        {
            Cliente? clienteSelecionado = ObterCliente();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro.", "Edição de clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarNovoCliente tela = new()
            {
                Cliente = clienteSelecionado,
                SalvarRegistro = _repositorioCliente.Editar
            };

            tela.label1.Text = " Editando Registro";
            tela.label4.Text = "Altere abaixo as informações que deseja do cliente selecionado.";


            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Excluir()
        {
            Cliente? clienteSelecionado = ObterCliente();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro.", "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Clienet", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                _repositorioCliente.Excluir(clienteSelecionado);

            CarregarClientes();
        }


        public override KryptonForm ObterTela()
        {
            CarregarClientes();

            return controleClienteForm;
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = _repositorioCliente.SelecionarTodos();

            controleClienteForm.AtualizarGrid(clientes);
        }

        private Cliente? ObterCliente()
        {
            if (controleClienteForm.ObterGrid().CurrentCell != null && controleClienteForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleClienteForm.ObterLinhaSelecionada();
                return _repositorioCliente.SelecionarTodos().ElementAtOrDefault(index);
            }

            return null;
        }
    }
}