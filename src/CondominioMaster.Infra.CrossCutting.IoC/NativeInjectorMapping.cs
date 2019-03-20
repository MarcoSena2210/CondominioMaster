using AutoMapper;
using CondominioMaster.Application.CondominioMaster.Application.Services;
using CondominioMaster.Application.Interfaces;
using CondominioMaster.Application.Interfaces.AgregacaoEdificacao;
using CondominioMaster.Application.Services;
using CondominioMaster.Application.Shared;
using CondominioMaster.Application.Shared.Interfaces;
using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Domain.Interfaces.Repository.AgregacaoEdificacao;
using CondominioMaster.Domain.Interfaces.Services;
using CondominioMaster.Domain.Interfaces.Services.AgregacaoEdificacao;
using CondominioMaster.Domain.Services;
using CondominioMaster.Domain.Services.AgregacaoEdificacao;
using CondominioMaster.Infra.Data.Context;
using CondominioMaster.Infra.Data.Interfaces;
using CondominioMaster.Infra.Data.Repository;
using CondominioMaster.Infra.Data.Repository.AgregacaoEdificacao;
using CondominioMaster.Infra.Data.uOw;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioMaster.Infra.CrossCutting.IoC
{
     public class NativeInjectorMapping
     {

          public static void RegistersServices(IServiceCollection service)
          {
               service.AddSingleton(Mapper.Configuration);
               service.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
              
               service.AddScoped<IApplicationEmpresa, ApplicationEmpresa>();
               service.AddScoped<IApplicationCondominio, ApplicationCondominio>();
               service.AddScoped<IApplicationEdificacao, ApplicationEdificacao>();
               service.AddScoped<IApplicationImovel, ApplicationImovel>();

               service.AddScoped<IApplicationShared, ApplicationShared>();

               service.AddScoped<IServiceEmpresa, ServiceEmpresa>();
               service.AddScoped<IServiceCondominio, ServiceCondominio>();
               service.AddScoped<IServiceEdificacao, ServiceEdificacao>();
               service.AddScoped<IServiceImovel, ServiceImovel>();

               service.AddScoped<IRepositoryEmpresa, RepositoryEmpresa>();
               service.AddScoped<IRepositoryCondominio, RepositoryCondominio>();
               service.AddScoped<IRepositoryEdificacao, RepositoryEdificacao>();
               service.AddScoped<IRepositoryImovel, RepositoryImovel>();

               service.AddScoped<IUnitOfWork, UnitOfWork>();

               service.AddScoped<ContextEFCondominioMaster>();
          }

     }
}