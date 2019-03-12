using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Services.AgregacaoEdificacao;
using NUnit.Framework;

namespace CondominioMaster.Tests.Domain.Services.AgregacaoEdificacao
{
     public class ServiceImovelTests
     {
          private readonly ServiceImovel serviceImovel;

          public ServiceImovelTests(ServiceImovel _serviceImovel)
          {
               serviceImovel = _serviceImovel;
          }

          [NUnit.Framework.SetUp]
          public void Setup()
          {
               Imovel imovel = new Imovel();

               int IdCondominio = 1;
               imovel.Id = 2;
               imovel.SiglaImovel = "AP";
               imovel.IdEdificacao = 528;
               imovel.NumeroPorta = "515A";
               imovel.StatusRegistro = "A";
               imovel.IdPessoaFinanceiro = 4;
               //     imovel.DataIncluiRegistro = imovel.DataIncluiRegistro.ToShortDateString();
               imovel.Identificador = null;

          }

          [Test]
          public void MontaIdentificadorDoImove_DeveRetornarIdentificadorPreenchido(Imovel imovel, int IdCondominio)
          {
               //Arrange
               string resultadoEsperado = "1.528.AP515A";

               //Act
               string resultadoAtual = serviceImovel.MontaIdentificadorDoImovel(imovel, IdCondominio);

               //Assert 
               Assert.AreEqual(resultadoEsperado, resultadoAtual);
          }
     }
}
