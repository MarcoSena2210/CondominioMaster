﻿using System.Globalization;

namespace CondominioMaster.Infra.CrossCutting.IoC.Extensions
{
    public static class DecimalExtensions
    {
        public static string Formatado(this decimal strIn, string masc)
        {
            var retorno = string.Format(CultureInfo.GetCultureInfo("pt-BR"), masc, strIn);
            return retorno;
        }
    }
}
