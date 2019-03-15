using AutoMapper;
using CondominioMaster.Application.ViewModels;
using CondominioMaster.Application.ViewModels.AgregacaoEdificacao;
using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Entities.AgregacaoEdificacao;
using CondominioMaster.Infra.CrossCutting.Extensions;

namespace Projeto.Curso.Core.Application.Pedido.AutoMapper
{
     public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
               # region Empresa --> EmpresaViewModel

               CreateMap<Empresa, EmpresaViewModel>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new EmpresaViewModel
                     {
                         Id = src.Id,
                         ListaErros = src.ListaErros,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CpfCnpj = src.CPFCNPJ.Numero.FormatoCpfCnpj(),
                         Email = src.Email.Endereco,
                         Endereco = src.Endereco.Logradouro,
                         Bairro = src.Endereco.Bairro,
                         Cidade = src.Endereco.Cidade,
                         UF = src.Endereco.UF.UF,
                         CEP = src.Endereco.CEP.Codigo
                     };
                 });
               #endregion Empresa --> EmpresaViewModel


               #region Condominio --> CondominioViewModel

               CreateMap<Condominio,CondominioViewModel>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new CondominioViewModel
                     {
                         Id = src.Id,
                         ListaErros = src.ListaErros,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CpfCnpj = src.CPFCNPJ.Numero.FormatoCpfCnpj(),
                         Email = src.Email.Endereco,
                         Endereco = src.Endereco.Logradouro,
                         Bairro = src.Endereco.Bairro,
                         Cidade = src.Endereco.Cidade,
                         UF = src.Endereco.UF.UF,
                         CEP = src.Endereco.CEP.Codigo
                     };
                 });
               #endregion Condominio --> CondominioViewModel


               #region Edificacao --> EdificacaoViewModel

               CreateMap<Edificacao, EdificacaoViewModel>()
               .ConvertUsing((src, dst) =>
               {
                    return new EdificacaoViewModel
                    {
                         Id = src.Id,
                         ListaErros = src.ListaErros,
                         Apelido = src.Apelido,
                         Nome = src.Nome,
                         CpfCnpj = src.CPFCNPJ.Numero.FormatoCpfCnpj(),
                         Email = src.Email.Endereco,
                         Endereco = src.Endereco.Logradouro,
                         Bairro = src.Endereco.Bairro,
                         Cidade = src.Endereco.Cidade,
                         UF = src.Endereco.UF.UF,
                         CEP = src.Endereco.CEP.Codigo
                    };
               });
               #endregion Edificacao --> EdificacaoViewModel


               #region Imovel --> ImovelViewModel

               CreateMap<Imovel, ImovelViewModel>()
                   .ConvertUsing((src, dst) =>
                    {
                        return new ImovelViewModel
                        {
                            ListaErros = src.ListaErros,
                            Id = src.Id,
                            IdEdificacao = src.IdEdificacao,
                            IdPessoaFinanceiro = src.IdPessoaFinanceiro,
                            ResponsavelFinanceiro = src.Pessoa.Nome,
                            NomeEdificacao = src.Edificacao.Nome != null ? src.Edificacao.Nome : "",
                            Identificador = src.Identificador,
                            NumeroPorta = src.NumeroPorta,
                            SiglaImovel = src.SiglaImovel,
                        };
                    });
               #endregion Imovel --> ImovelViewModel


               #region DTO
               //CreateMap<EdificacaoDTO, EdificacaoViewModel>()
               //       .ForMember(to => to.DataPedido, opt => opt.MapFrom(from => from.DataPedido.Formatado("{0:dd/MM/yyyy}")))
               //       .ForMember(to => to.DataEntrega, opt => opt.MapFrom(from => from.DataEntrega.Formatado("{0:dd/MM/yyyy}")))
               //       .ForMember(to => to.ValorTotalProdutos, opt => opt.MapFrom(from => from.ValorTotalProdutos.Formatado("{0:#,###,##0.00}")));
               #endregion

          }
     }
}
