﻿using Krypton.Toolkit;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloTaxa;
using LocadoraFCVSJ.ModuloFuncionario;
using LocadoraFCVSJ.ModuloGrupo;
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

            controladores = new()
            {
                { "Grupos", new ControladorGrupo(repositorioGrupo) },
                { "Funcionarios", new ControladorFuncionario(repositorioFuncionario) },
                { "Taxas", new ControladorTaxa(repositorioTaxa) }
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

        private void AbrirTela(KryptonButton botao)
        {
            controlador = controladores[botao.AccessibleName];

            KryptonForm formAtual = controlador.ObterTela();

            formAtual.ShowDialog();
        }
    }
}