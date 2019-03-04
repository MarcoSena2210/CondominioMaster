using System.Data.SqlClient;

namespace CondominioMaster.Infra.Data.Context
{
    //Criada para verificar se o parametros estiver null no momento de salvar no banco, preenche com vazio "espaços"
    //para os casos em que desejamos permitir gravar em branco.
    public static class ReaderExtension
    {
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}
