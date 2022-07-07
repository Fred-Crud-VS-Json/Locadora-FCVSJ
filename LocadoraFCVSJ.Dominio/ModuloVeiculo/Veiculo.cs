using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public Grupo GrupoVeiculo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public TipoCombustivel? TipoCombustivel { get; set; }
        public decimal CapacidadeTanque { get; set; }
        public int Ano { get; set; }
        public decimal KmPercorrido { get; set; }
        public string CaminhoFoto { get; set; }
        public byte[] Foto { get; set; }

       

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   EqualityComparer<Grupo>.Default.Equals(GrupoVeiculo, veiculo.GrupoVeiculo) &&
                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   Placa == veiculo.Placa &&
                   Cor == veiculo.Cor &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   Ano == veiculo.Ano &&
                   KmPercorrido == veiculo.KmPercorrido &&
                   EqualityComparer<byte[]>.Default.Equals(Foto, veiculo.Foto);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(GrupoVeiculo);
            hash.Add(Modelo);
            hash.Add(Marca);
            hash.Add(Placa);
            hash.Add(Cor);
            hash.Add(TipoCombustivel);
            hash.Add(CapacidadeTanque);
            hash.Add(Ano);
            hash.Add(KmPercorrido);
            hash.Add(Foto);
            return hash.ToHashCode();
        }
    }
}