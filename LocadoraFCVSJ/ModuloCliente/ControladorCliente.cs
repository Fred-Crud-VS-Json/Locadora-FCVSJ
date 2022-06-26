using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
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
               // CarregarClientes();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }


        public override KryptonForm ObterTela()
        {
            throw new NotImplementedException();
        }
    }
}