using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloCliente;
using LocadoraFCVSJ.Aplicacao.ModuloFuncionario;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Aplicacao.ModuloTaxa;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloCliente;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;
using LocadoraFCVSJ.ModuloCliente;
using LocadoraFCVSJ.ModuloFuncionario;
using LocadoraFCVSJ.ModuloGrupo;
using LocadoraFCVSJ.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.ModuloTaxa;

namespace LocadoraFCVSJ
{
    public partial class TelaPrincipal : KryptonForm
    {
        private ControladorBase? controlador;
        private readonly Dictionary<string, ControladorBase> controladores;

        public TelaPrincipal()
        {
            InitializeComponent();

            RepositorioGrupo repositorioGrupo = new();
            RepositorioFuncionario repositorioFuncionario = new();
            RepositorioTaxa repositorioTaxa = new();
            RepositorioCliente repositorioCliente = new();

            ServicoGrupo servicoGrupo = new(repositorioGrupo);
            ServicoTaxa servicoTaxa = new(repositorioTaxa);
            ServicoCliente servicoCliente = new(repositorioCliente);
            ServicoFuncionario servicoFuncionario = new(repositorioFuncionario);
            ServicoPlanoDeCobranca servicoPlanoDeCobranca = new(new RepositorioPlanoDeCobranca());

            controladores = new()
            {
                { "Grupos", new ControladorGrupo(repositorioGrupo, servicoGrupo) },
                { "Funcionarios", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario) },
                { "Taxas", new ControladorTaxa(repositorioTaxa, servicoTaxa) },
                { "Clientes", new ControladorCliente(repositorioCliente, servicoCliente) },
                { "Planos", new ControladorPlanoDeCobranca(servicoGrupo, servicoPlanoDeCobranca) }
            };
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

        private void AbrirTela(KryptonButton botao)
        {
            controlador = controladores[botao.AccessibleName];

            KryptonForm formAtual = controlador.ObterTela();

            formAtual.ShowDialog();
        }
    }
}