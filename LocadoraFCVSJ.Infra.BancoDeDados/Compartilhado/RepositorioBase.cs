using FluentValidation;
using FluentValidation.Results;
using LocadoraFCVSJ.Dominio.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado
{
    public abstract class RepositorioBase<T, TValidador, TMapeador>
        where T : EntidadeBase<T>
        where TValidador : AbstractValidator<T>, new()
        where TMapeador : MapeadorBase<T>, new()
    {
        private readonly string StringConexao =
            @"Data Source=(LocalDB)\MSSqlLocalDB;
              Initial Catalog=DBLocadoraFCVSJ;
              Integrated Security=True;
              Pooling=False";

        private SqlConnection? Conexao = null;

        protected abstract string QueryInserir { get; }

        protected abstract string QueryEditar { get; }

        protected abstract string QueryExcluir { get; }

        protected abstract string QuerySelecionarPorId { get; }

        protected abstract string QuerySelecionarTodos { get; }

        public ValidationResult Inserir(T registro)
        {
            TValidador validador = new();

            ValidationResult resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QueryInserir, Conexao);

                TMapeador mapeador = new();

                mapeador.ConfigurarParametros(registro, comando);

                Conexao.Open();

                registro.Id = Convert.ToInt32(comando.ExecuteScalar());

                return resultadoValidacao;
            }
        }

        public ValidationResult Editar(T registro)
        {
            TValidador validador = new();

            ValidationResult resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QueryEditar, Conexao);

                TMapeador mapeador = new();

                mapeador.ConfigurarParametros(registro, comando);

                Conexao.Open();

                comando.ExecuteNonQuery();
                
                return resultadoValidacao;
            }
        }

        public void Excluir(T registro)
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QueryExcluir, Conexao);

                comando.Parameters.AddWithValue("ID", registro.Id);

                Conexao.Open();

                comando.ExecuteNonQuery();
            }
        }

        public T? SelecionarPorId(int id)
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QuerySelecionarPorId, Conexao);

                comando.Parameters.AddWithValue("ID", id);

                Conexao.Open();

                SqlDataReader leitorRegistro = comando.ExecuteReader();

                TMapeador mapeador = new();

                T? registro = null;

                if (leitorRegistro.Read())
                    registro = mapeador.ConverterRegistro(leitorRegistro);

                return registro;
            }
        }

        public List<T> SelecionarTodos()
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QuerySelecionarTodos, Conexao);

                Conexao.Open();

                SqlDataReader leitorRegistro = comando.ExecuteReader();

                TMapeador mapeador = new();

                List<T> registros = new();

                while(leitorRegistro.Read()) 
                    registros.Add(mapeador.ConverterRegistro(leitorRegistro));

                return registros;
            }
        }
    }
}