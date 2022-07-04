using LocadoraFCVSJ.Dominio.ModuloPlanoDeCobranca;
using LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado;
using LocadoraFCVSJ.Infra.BancoDeDados.ModuloGrupo;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobranca : MapeadorBase<PlanoDeCobranca>
    {
        public override void ConfigurarParametros(PlanoDeCobranca planoDeCobranca, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", planoDeCobranca.Id);
            comando.Parameters.AddWithValue("DIARIO_VALORDIARIO", planoDeCobranca.PlanoDiario_ValorDiario);
            comando.Parameters.AddWithValue("DIARIO_VALORKM", planoDeCobranca.PlanoDiario_ValorKm);
            comando.Parameters.AddWithValue("LIVRE_VALORDIARIO", planoDeCobranca.PlanoLivre_ValorDiario);
            comando.Parameters.AddWithValue("CONTROLADO_VALORDIARIO", planoDeCobranca.PlanoControlado_ValorDiario);
            comando.Parameters.AddWithValue("CONTROLADO_VALORKM", planoDeCobranca.PlanoControlado_ValorKm);
            comando.Parameters.AddWithValue("CONTROLADO_LIMITEKM", planoDeCobranca.PlanoControlado_LimiteKm);
        }

        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            return new()
            {
                Id = Convert.ToInt32(leitorRegistro["COBRANCA_ID"]),
                PlanoDiario_ValorDiario = Convert.ToDecimal(leitorRegistro["PLANO_DIARIO_VALORDIARIO"]),
                PlanoDiario_ValorKm = Convert.ToDecimal(leitorRegistro["PLANO_DIARIO_VALORKM"]),
                PlanoLivre_ValorDiario = Convert.ToDecimal(leitorRegistro["PLANO_LIVRE_VALORDIARIO"]),
                PlanoControlado_ValorDiario = Convert.ToDecimal(leitorRegistro["PLANO_CONTROLADO_VALORDIARIO"]),
                PlanoControlado_ValorKm = Convert.ToDecimal(leitorRegistro["PLANO_CONTROLADO_VALORKM"]),
                PlanoControlado_LimiteKm = Convert.ToInt32(leitorRegistro["PLANO_CONTROLADO_LIMITEKM"]),
                Grupo = new MapeadorGrupo().ConverterRegistro(leitorRegistro)
            };
        }
    }
}