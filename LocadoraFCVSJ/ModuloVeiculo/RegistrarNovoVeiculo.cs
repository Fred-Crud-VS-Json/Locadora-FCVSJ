﻿using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public partial class RegistrarNovoVeiculo : KryptonForm
    {
        public string caminhoFoto = "";
        private Veiculo veiculo = new Veiculo();
        private readonly ServicoVeiculo _servicoVeiculo;
        private readonly ServicoGrupo _servicoGrupo;
        private Byte[] imagem;

        public RegistrarNovoVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupo servicoGrupo)
        {
            InitializeComponent();

            _servicoVeiculo = servicoVeiculo;
            _servicoGrupo = servicoGrupo;

            _servicoGrupo.SelecionarTodos().ForEach(x => CbxGrupo.Items.Add(x));

            List<TipoCombustivel> tiposDeCalculoDeTaxa = Enum.GetValues(typeof(TipoCombustivel)).Cast<TipoCombustivel>().ToList();

            tiposDeCalculoDeTaxa.ForEach(x => CbxTipoCombustivel.Items.Add(x));
        }

        public Veiculo Veiculo
        {
            get { return veiculo; }

            set
            {
                veiculo = value;

                CbxGrupo.SelectedItem = veiculo.Grupo;
                TxbModelo.Text = veiculo.Modelo;
                TxbMarca.Text = veiculo.Marca;
                TxbPlaca.Text = veiculo.Placa;
                TxbCor.Text = veiculo.Cor;
                CbxTipoCombustivel.SelectedItem = veiculo.TipoCombustivel;
                TxbCapacidadeDoTanque.Text = veiculo.CapacidadeTanque.ToString();
                TxbAno.Text = veiculo.Ano.ToString();
                TxbKmPercorrido.Text = veiculo.KmPercorrido.ToString();
                PxbFotoVeiculo.Image = ObterImagem();
            }
        }

        public Func<Veiculo, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                veiculo.Grupo = (Dominio.ModuloGrupo.Grupo)CbxGrupo.SelectedItem;
                veiculo.Modelo = TxbModelo.Text;
                veiculo.Marca = TxbMarca.Text;
                veiculo.Placa = TxbPlaca.Text;
                veiculo.Cor = TxbCor.Text;
                veiculo.TipoCombustivel = (Dominio.Compartilhado.TipoCombustivel?)CbxTipoCombustivel.SelectedItem;
                veiculo.CapacidadeTanque = Convert.ToInt32(TxbCapacidadeDoTanque.Text);
                veiculo.Ano = Convert.ToInt32(TxbAno.Text);
                veiculo.KmPercorrido = Convert.ToInt32(TxbKmPercorrido.Text);

                if (CbxTipoCombustivel.SelectedItem != null)
                    veiculo.TipoCombustivel = (TipoCombustivel)CbxTipoCombustivel.SelectedItem;

                ValidationResult resultado = SalvarRegistro(veiculo);

                if (resultado.IsValid == false)
                {
                    MessageBox.Show(resultado.ToString("\n"), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DialogResult = DialogResult.None;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("O campo 'Placa' ou 'Ano' ou 'Km Percorrido' possue valores inválidos.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }


        private void BtnSelecionarFoto_Click(object sender, EventArgs e)
        {
            CarregarFoto();
        }

        public void CarregarFoto()
        {
            if(openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.None;

                imagem = File.ReadAllBytes(openFileDialog1.FileName);

                veiculo.Foto = imagem;

                using (MemoryStream ms = new(imagem))
                    PxbFotoVeiculo.Image = new Bitmap(ms);
            }
        }



        private Bitmap ObterImagem()
        {
            if(veiculo.Foto != null)
            {
            using (MemoryStream ms = new(veiculo.Foto))
                return new Bitmap(ms);
            }
            return null;
        }

    }
}