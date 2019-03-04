using System;
using System.Globalization;

namespace CondominioMaster.Infra.CrossCutting.Extensions
{
    public static class DateTimeExtensions
    {

        public static string Formatado(this DateTime strIn, string masc)
        {
            var retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn);
            return retorno;
        }

        public static string Formatado(this DateTime? strIn, string masc)
        {
            string retorno = "";
            if (strIn != null)
            {
                retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn);
                return retorno;
            }
            return retorno;
        }


    }
}
