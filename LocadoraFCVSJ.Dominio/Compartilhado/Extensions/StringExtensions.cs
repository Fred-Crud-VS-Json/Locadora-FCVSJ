namespace LocadoraFCVSJ.Dominio.Compartilhado.Extensions
{
    public static class StringExtensions
    {
        public static string FormatarParaCpf(this string cpf)
        {
            string response = cpf.Trim();
            if (response.Length == 11)
            {
                response = response.Insert(9, "-");
                response = response.Insert(6, ".");
                response = response.Insert(3, ".");
            }
            return response;
        }

        public static string FormatarParaTelefone(this string telefone)
        {
            string p1 = telefone[..2];
            string p2 = telefone.Substring(2, 1);
            string p3 = telefone.Substring(3, 4);
            string p4 = telefone.Substring(7, 4);

            return $"({p1}) {p2} {p3}-{p4}";
        }
    }
}