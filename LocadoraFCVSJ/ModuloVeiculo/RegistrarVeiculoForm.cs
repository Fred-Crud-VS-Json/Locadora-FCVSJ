using FluentResults;
using Krypton.Toolkit;
using LocadoraFCVSJ.Aplicacao.ModuloGrupo;
using LocadoraFCVSJ.Aplicacao.ModuloVeiculo;
using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloVeiculo;
using System.Text;

namespace LocadoraFCVSJ.ModuloVeiculo
{
    public partial class RegistrarVeiculoForm : KryptonForm
    {
        private Veiculo veiculo;
        private readonly ServicoGrupo _servicoGrupo;

        public RegistrarVeiculoForm(ServicoGrupo servicoGrupo)
        {
            InitializeComponent();

            _servicoGrupo = servicoGrupo;

            _servicoGrupo.SelecionarTodos().Value.ForEach(x => CbxGrupo.Items.Add(x));

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

                if (veiculo.CapacidadeTanque != 0)
                    TxbCapacidadeTanque.Text = veiculo.CapacidadeTanque.ToString();

                if (veiculo.Ano != 0)
                    TxbAno.Text = veiculo.Ano.ToString();

                if (veiculo.KmPercorrido != 0)
                    TxbKmPercorrido.Text = veiculo.KmPercorrido.ToString();

                PxbImagem.Image = ObterImagem();
            }
        }

        public Func<Veiculo, Result<Veiculo>> SalvarRegistro { get; set; }

        private void BtnConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                veiculo.Grupo = (Dominio.ModuloGrupo.Grupo)CbxGrupo.SelectedItem;
                veiculo.Modelo = TxbModelo.Text;
                veiculo.Marca = TxbMarca.Text;
                veiculo.Placa = TxbPlaca.Text;
                veiculo.Cor = TxbCor.Text;
                veiculo.TipoCombustivel = (TipoCombustivel)CbxTipoCombustivel.SelectedItem;
                veiculo.CapacidadeTanque = Convert.ToInt32(TxbCapacidadeTanque.Text);
                veiculo.Ano = Convert.ToInt32(TxbAno.Text);
                veiculo.KmPercorrido = Convert.ToInt32(TxbKmPercorrido.Text);

                if (CbxTipoCombustivel.SelectedItem != null)
                    veiculo.TipoCombustivel = (TipoCombustivel)CbxTipoCombustivel.SelectedItem;

                Result<Veiculo> resultado = SalvarRegistro(veiculo);

                if (resultado.IsFailed)
                {
                    StringBuilder erros = new();

                    foreach (Error erro in resultado.Errors)
                        erros.AppendLine(erro.Message);

                    MessageBox.Show(erros.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    DialogResult = DialogResult.None;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("O campo 'Placa' ou 'Ano' ou 'Km Percorrido' possue valores inválidos.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
            }
        }

        private void BtnSelecionarImagem_Click(object sender, EventArgs e)
        {
            Opf.Filter = "Images (*.JPG;*.PNG)|*.JPG;*.PNG|" + "All files (*.*)|*.*";
            long total = 0;//s

            if (Opf.ShowDialog(this) == DialogResult.OK)
            {
                foreach (string s in Opf.FileNames)
                    total += new FileInfo(s).Length;
                if(total < 15000)
                {
                    DialogResult = DialogResult.None;

                    byte[] imagem = File.ReadAllBytes(Opf.FileName);

                    veiculo.Foto = imagem;

                    using MemoryStream ms = new(imagem);

                    PxbImagem.Image = new Bitmap(ms);
                }
                else
                {
                    MessageBox.Show("Peso da imagem está acima do permitido, peso máximo aceito: 15KB");
                    DialogResult = DialogResult.None;
                }
            }
        }

        private Bitmap? ObterImagem()
        {
            if(veiculo.Foto != null)
            {
                using MemoryStream ms = new(veiculo.Foto);
                return new Bitmap(ms);
            }

            return null;
        }
    }
}