using LocadoraFCVSJ.Dominio.Compartilhado;
using LocadoraFCVSJ.Dominio.Compartilhado.Excecoes;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace LocadoraFCVSJ.Infra.BancoDeDados.Compartilhado
{
    public abstract class RepositorioBaseSql<T, TMapeador> : IRepositorio<T>
        where T : EntidadeBase<T>
        where TMapeador : MapeadorBaseSql<T>, new()
    {
        private readonly string StringConexao;

        private SqlConnection? Conexao = null;

        public RepositorioBaseSql()
        {
            IConfigurationRoot? configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            StringConexao = configuracao.GetConnectionString("SqlServer");
        }

        protected abstract string QueryInserir { get; }

        protected abstract string QueryEditar { get; }

        protected abstract string QueryExcluir { get; }

        protected abstract string QuerySelecionarPorId { get; }

        protected abstract string QuerySelecionarTodos { get; }

        public virtual void Inserir(T registro)
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QueryInserir, Conexao);

                TMapeador mapeador = new();

                mapeador.ConfigurarParametros(registro, comando);

                Conexao.Open();

                comando.ExecuteNonQuery();
            }
        }

        public virtual void Editar(T registro)
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QueryEditar, Conexao);

                TMapeador mapeador = new();

                mapeador.ConfigurarParametros(registro, comando);

                Conexao.Open();

                comando.ExecuteNonQuery();
            }
        }

        public virtual void Excluir(T registro)
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QueryExcluir, Conexao);

                comando.Parameters.AddWithValue("ID", registro.Id);

                try
                {
                    Conexao.Open();

                    comando.ExecuteNonQuery();
                } 
                catch (SqlException ex)
                {
                    if (ex != null && ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        throw new ExcluirRegistroRelacionadoException(ex);

                    throw;
                }
            }
        }

        public virtual T? SelecionarPorId(Guid id)
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

        public virtual List<T> SelecionarTodos()
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(QuerySelecionarTodos, Conexao);

                Conexao.Open();

                SqlDataReader leitorRegistro = comando.ExecuteReader();

                TMapeador mapeador = new();

                List<T> registros = new();

                while (leitorRegistro.Read())
                    registros.Add(mapeador.ConverterRegistro(leitorRegistro));

                return registros;
            }
        }

        public virtual T? SelecionarParametro(string query, SqlParameter parametro)
        {
            using (Conexao = new(StringConexao))
            {
                using SqlCommand comando = new(query, Conexao);

                comando.Parameters.Add(parametro);

                Conexao.Open();

                SqlDataReader leitorRegistro = comando.ExecuteReader();

                TMapeador mapeador = new();

                T? registro = null;

                if (leitorRegistro.Read())
                    registro = mapeador.ConverterRegistro(leitorRegistro);

                return registro;
            }
        }
    }
}