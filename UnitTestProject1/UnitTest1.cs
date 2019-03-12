using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Services.AgregacaoEdificacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
   //  private readonly ServiceImovel serviceImovel;

     //public UnitTestProject1(ServiceImovel _serviceImovel)
     //{
     //     serviceImovel = _serviceImovel;
     //     Imovel imovel = new Imovel();

     //     int IdCondominio = 1;
     //     imovel.Id = 2;
     //     imovel.SiglaImovel = "AP";
     //     imovel.IdEdificacao = 528;
     //     imovel.NumeroPorta = "515A";
     //     imovel.StatusRegistro = "A";
     //     imovel.IdPessoaFinanceiro = 4;
     //     //     imovel.DataIncluiRegistro = imovel.DataIncluiRegistro.ToShortDateString();
     //     imovel.Identificador = null;
     //}
   
    
     [TestClass]
     public class UnitTest1
     {
          [TestMethod]
          public void TestMethod1()
          {
               //Arrange
               string resultadoEsperado = "1.528.AP515A";

               //Act
          //     string resultadoAtual =
          //serviceImovel.MontaIdentificadorDoImovel(Imovel, IdCondominio);

               //Assert 
         //      Assert.AreEqual(resultadoEsperado, 
         //resultadoAtual);
          }
     }
}
