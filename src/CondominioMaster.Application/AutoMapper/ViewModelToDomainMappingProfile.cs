using AutoMapper;
using CondominioMaster.Application.ViewModels;
using CondominioMaster.Application.ViewModels.AgregacaoEdificacao;
using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Domain.Shared.ValueObjects;
using CondominioMaster.Infra.CrossCutting.Extensions;

namespace CondominioMaster.Application.AutoMapper
{
     public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
               #region EmpresaViewModel -->  Empresa 

               CreateMap<EmpresaViewModel, Empresa>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new Empresa
                     {
                         Id = src.Id,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CPFCNPJ = new CpfCnpjVO //Obrigatotrio instanciar pois é um VO
                         {
                             Numero = src.CpfCnpj.SomenteNumeros()
                         },
                         Email = new EmailVO
                         {
                             Endereco = src.Email
                         },
                         Endereco = new EnderecoVO
                         {
                             Logradouro = src.Endereco,
                             Bairro = src.Bairro,
                             Cidade = src.Cidade,
                             UF = new UfVO
                             {
                                 UF = src.UF
                             },
                             CEP = new CepVO
                             {
                                 Codigo = src.CEP
                             }
                         }

                     };
                 });
               #endregion  EmpresaViewModel -->  Empresa 

               #region CondominioViewModel --> Condominio

               CreateMap<CondominioViewModel, Condominio>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new Condominio
                     {
                         Id = src.Id,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CPFCNPJ = new CpfCnpjVO
                         {
                             Numero = src.CpfCnpj.SomenteNumeros()
                         },
                         Email = new EmailVO
                         {
                             Endereco = src.Email
                         },
                         Endereco = new EnderecoVO
                         {
                             Logradouro = src.Endereco,
                             Bairro = src.Bairro,
                             Cidade = src.Cidade,
                             UF = new UfVO
                             {
                                 UF = src.UF
                             },
                             CEP = new CepVO
                             {
                                 Codigo = src.CEP
                             }
                         }
                     };
                 });
               #endregion  CondominioViewModel --> Condominio

               #region EdificacaoViewModel --> Edificacao

               CreateMap<EdificacaoViewModel, Edificacao>()
                 .ConvertUsing((src, dst) =>
                 {
                      return new Edificacao
                      {
                           Id = src.Id,
                           Apelido = src.Apelido,
                           Nome = src.Nome,
                           CPFCNPJ = new CpfCnpjVO
                           {
                                Numero = src.CpfCnpj.SomenteNumeros()
                           },
                           Email = new EmailVO
                           {
                                Endereco = src.Email
                           },
                           Endereco = new EnderecoVO
                           {
                                Logradouro = src.Endereco,
                                Bairro = src.Bairro,
                                Cidade = src.Cidade,
                                UF = new UfVO
                                {
                                     UF = src.UF
                                },
                                CEP = new CepVO
                                {
                                     Codigo = src.CEP
                                }
                           }
                      };
                 });
               #endregion  EdificacaoViewModel --> Edificacao

               #region ImovelViewModel --> Imovel

               CreateMap<ImovelViewModel, Imovel>()
                 .ConvertUsing((src, dst) =>
                 {
                      return new Imovel
                      {
                           Id = src.Id,
                           IdEdificacao = src.IdEdificacao,
                           IdPessoaFinanceiro = src.IdPessoaFinanceiro,
                           Identificador = src.Identificador,
                           NumeroPorta = src.NumeroPorta,
                           SiglaImovel = src.SiglaImovel
   
                      };
                 });
               #endregion ImovelViewModel --> Imovel



          }

     }
}
