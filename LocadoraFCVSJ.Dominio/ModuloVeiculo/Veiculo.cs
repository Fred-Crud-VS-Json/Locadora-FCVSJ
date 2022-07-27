using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.ModuloGrupo;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public TipoCombustivel? TipoCombustivel { get; set; }
        public decimal CapacidadeTanque { get; set; }
        public int Ano { get; set; }
        public decimal KmPercorrido { get; set; }
        public byte[] Foto { get; set; }
        public Grupo Grupo { get; set; }
        public Guid GrupoId { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Veiculo veiculo &&
                   Id.Equals(veiculo.Id) &&
                   Modelo == veiculo.Modelo &&
                   Marca == veiculo.Marca &&
                   Placa == veiculo.Placa &&
                   Cor == veiculo.Cor &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   Ano == veiculo.Ano &&
                   KmPercorrido == veiculo.KmPercorrido &&
                   EqualityComparer<Grupo>.Default.Equals(Grupo, veiculo.Grupo);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Modelo);
            hash.Add(Marca);
            hash.Add(Placa);
            hash.Add(Cor);
            hash.Add(TipoCombustivel);
            hash.Add(CapacidadeTanque);
            hash.Add(Ano);
            hash.Add(KmPercorrido);
            hash.Add(Foto);
            hash.Add(Grupo);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return Modelo;
        }
    }
}