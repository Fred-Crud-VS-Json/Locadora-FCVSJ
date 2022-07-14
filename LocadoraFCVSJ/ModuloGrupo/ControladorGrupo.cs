﻿using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;

namespace LocadoraFCVSJ.ModuloGrupo
{
    public class ControladorGrupo : ControladorBase
    {
        private readonly ServicoGrupo _servicoGrupo;
        private readonly ControleGrupoForm controleGrupoForm;

        public ControladorGrupo(ServicoGrupo servicoGrupo)
        {
            _servicoGrupo = servicoGrupo;
            controleGrupoForm = new(this);
        }

        public override void Inserir()
        {
            RegistrarNovoGrupoForm tela = new()
            {
                Grupo = new(),
                SalvarRegistro = _servicoGrupo.Inserir
            };

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Editar()
        {
            Grupo? grupoSelecionado = ObterGrupo();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo primeiro.", "Edição de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarNovoGrupoForm tela = new()
            {
                Grupo = grupoSelecionado,
                SalvarRegistro = _servicoGrupo.Editar
            };

            tela.label1.Text = "      Editando Registro";
            tela.label4.Text = "Insira o novo nome do grupo no campo abaixo";


            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Excluir()
        {
            Grupo? grupoSelecionado = ObterGrupo();

            if (grupoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo primeiro.", "Exclusão de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este registro?", "Exclusão de Grupo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                _servicoGrupo.Excluir(grupoSelecionado);

            CarregarGrupos();
        }

        public override KryptonForm ObterTela()
        {
            CarregarGrupos();

            return controleGrupoForm;
        }

        private void CarregarGrupos()
        {
            Result<List<Grupo>> resultado = _servicoGrupo.SelecionarTodos();

            if (resultado.IsSuccess)
                controleGrupoForm.AtualizarGrid(resultado.Value);
        }

        private Grupo? ObterGrupo()
        {
            if (controleGrupoForm.ObterGrid().CurrentCell != null && controleGrupoForm.ObterGrid().CurrentCell.Selected == true)
            {
                int index = controleGrupoForm.ObterLinhaSelecionada();
                return _servicoGrupo.SelecionarTodos().Value.ElementAtOrDefault(index);
            }

            return null;
        }
    }
}