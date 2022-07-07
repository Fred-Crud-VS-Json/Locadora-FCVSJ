using FluentValidation.Results;
using Krypton.Toolkit;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloVeiculo;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public partial class RegistrarNovoVeiculo : KryptonForm
    {
        public string caminhoFoto = "";
        private Veiculo veiculo = new Veiculo();
        private MapeadorVeiculo mapeadorVeiculo;
        public RegistrarNovoVeiculo()
        {
            InitializeComponent();
        }

        public Veiculo Veiculo
        {
            get { return veiculo; }

            set
            {
                veiculo = value;

                CbxGrupo.SelectedItem = veiculo.GrupoVeiculo;
                TxbModelo.Text = veiculo.Modelo;
                TxbMarca.Text = veiculo.Marca;
                TxbPlaca.Text = veiculo.Placa;
                TxbCor.Text = veiculo.Cor;
                CbxTipoCombustivel.SelectedItem = veiculo.TipoCombustivel;
                TxbCapacidadeDoTanque.Text = veiculo.CapacidadeTanque.ToString();
                TxbAno.Text = veiculo.Ano.ToString();
                TxbKmPercorrido.Text = veiculo.KmPercorrido.ToString();
            }
        }

        public Func<Veiculo, ValidationResult> SalvarRegistro { get; set; }

        private void BtnConcluirRegistro_Click(object sender, EventArgs e)
        {
            SalvarVeiculo();
        }


        private void SalvarVeiculo()
        {
            veiculo.CaminhoFoto = caminhoFoto;

            mapeadorVeiculo.Salvar(veiculo);

            MessageBox.Show("Veiculo gravado!");
        }

        private void BtnSelecionarFoto_Click(object sender, EventArgs e)
        {
            CarregarFoto();
        }

        private void CarregarFoto()
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Arquivos de imagens jpg e png|*.jpg; *.png";
            openFile.Multiselect = false;

            if (openFile.ShowDialog() == DialogResult.OK)
                caminhoFoto = openFile.FileName;

            if (caminhoFoto != "")
                pictureBox1.Load(caminhoFoto);
        }
    }
}