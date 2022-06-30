﻿using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;

namespace LocadoraFCVSJ.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly RepositorioCliente _repositorioCliente;
        private readonly ServicoCliente _servicoCliente;
        private readonly ControleClienteForm controleClienteForm;

        public ControladorCliente(RepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            _repositorioCliente = repositorioCliente;
            _servicoCliente = servicoCliente;
            controleClienteForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoCliente tela = new()
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

            RegistrarNovoCliente tela = new()
            {
                Cliente = clienteSelecionado,
                SalvarRegistro = _servicoCliente.Editar
            };

            tela.label1.Text = "        Editando Registro";
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
                MessageBox.Show("Selecione um cliente primeiro.", "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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

        public Cliente? ObterCliente()
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