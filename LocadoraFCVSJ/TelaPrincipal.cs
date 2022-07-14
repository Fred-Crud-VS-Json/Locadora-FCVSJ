using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Aplicacao.ModuloCondutor;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Aplicacao.ModuloTaxa;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCondutor;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraFCVSJ.ModuloCliente;
using LocadoraFCVSJ.ModuloCondutor;
using LocadoraFCVSJ.ModuloFuncionario;
using LocadoraFCVSJ.ModuloGrupo;
using LocadoraFCVSJ.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.ModuloTaxa;
using LocadoraFCVSJ.ModuloVeiculo;

namespace LocadoraFCVSJ
{
    public partial class TelaPrincipal : KryptonForm
    {
        private ControladorBase? controlador;
        private readonly Dictionary<string, ControladorBase> controladores;

        public TelaPrincipal()
        {
            InitializeComponent();

            RepositorioFuncionario repositorioFuncionario = new();
            RepositorioCliente repositorioCliente = new();
            RepositorioCondutor repositorioCondutor = new();
            RepositorioVeiculo repositorioVeiculo = new();

            ServicoGrupo servicoGrupo = new(new RepositorioGrupo());
            ServicoTaxa servicoTaxa = new(new RepositorioTaxa());
            ServicoCliente servicoCliente = new(repositorioCliente);
            ServicoFuncionario servicoFuncionario = new(repositorioFuncionario);
            ServicoCondutor servicoCondutor = new(repositorioCondutor, servicoCliente);
            ServicoPlanoDeCobranca servicoPlanoDeCobranca = new(new RepositorioPlanoDeCobranca());
            ServicoVeiculo servicoVeiculo = new(repositorioVeiculo);

            controladores = new()
            {
                { "Grupos", new ControladorGrupo(servicoGrupo) },
                { "Funcionarios", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario) },
                { "Taxas", new ControladorTaxa(servicoTaxa) },
                { "Clientes", new ControladorCliente(repositorioCliente, servicoCliente) },
                { "Planos", new ControladorPlanoDeCobranca(servicoGrupo, servicoPlanoDeCobranca) },
                { "Condutores", new ControladorCondutor(repositorioCondutor, servicoCondutor) },
                { "Veiculos", new ControladorVeiculo(repositorioVeiculo, servicoVeiculo, servicoGrupo) }
            };
        }

        private void BtnAcessarCondutores_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarCondutores);
        }

        private void BtnAcessarGrupos_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarGrupos);
        }

        private void BtnAcessarFuncionarios_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarFuncionarios);
        }

        private void BtnAcessarTaxas_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarTaxas);
        }

        private void BtnAcessarClientes_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarClientes);
        }

        private void BtnAcessarPlanos_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarPlanos);
        }

        private void BtnAcessarVeiculos_Click(object sender, EventArgs e)
        {
            AbrirTela(BtnAcessarVeiculos);
        }

        private void AbrirTela(KryptonButton botao)
        {
            controlador = controladores[botao.AccessibleName];

            KryptonForm formAtual = controlador.ObterTela();

            formAtual.ShowDialog();
        }
    }
}