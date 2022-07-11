using FluentValidation.Results;
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
        private MapeadorVeiculo mapeadorVeiculo;
        private readonly ServicoVeiculo _servicoVeiculo;
        private readonly ServicoGrupo _servicoGrupo;

        public RegistrarNovoVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupo servicoGrupo)
        {
            InitializeComponent();

            _servicoVeiculo = servicoVeiculo;
            _servicoGrupo = servicoGrupo;

            List<Grupo> gruposVeiculo = new();

            _servicoGrupo.SelecionarTodos().ForEach(x =>
            {
                if (!_servicoVeiculo.SelecionarTodos().Select(x => x.GrupoVeiculo).Contains(x))
                    gruposVeiculo.Add(x);
            });

            gruposVeiculo.ForEach(x => CbxGrupo.Items.Add(x));

            List<TipoCombustivel> tiposDeCalculoDeTaxa = Enum.GetValues(typeof(TipoCombustivel)).Cast<TipoCombustivel>().ToList();

            tiposDeCalculoDeTaxa.ForEach(x => CbxTipoCombustivel.Items.Add(x));
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
            veiculo.GrupoVeiculo = (Dominio.ModuloGrupo.Grupo)CbxGrupo.SelectedItem;
            veiculo.Modelo = TxbMarca.Text;
            veiculo.Marca = TxbMarca.Text;
            veiculo.Placa = TxbPlaca.Text;
            veiculo.Cor = TxbCor.Text;
            veiculo.TipoCombustivel = (Dominio.Compartilhado.TipoCombustivel?)CbxTipoCombustivel.SelectedItem;
            veiculo.CapacidadeTanque = Convert.ToInt32(TxbCapacidadeDoTanque.Text);
            veiculo.Ano = Convert.ToInt32(TxbAno.Text);
            veiculo.KmPercorrido = Convert.ToInt32(TxbKmPercorrido.Text);
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