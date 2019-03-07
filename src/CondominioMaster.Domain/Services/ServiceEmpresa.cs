using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Services
{
    public class ServiceEmpresa : IServiceEmpresa
    {
        private readonly IRepositoryEmpresa repoEmpresa;

        public ServiceEmpresa(IRepositoryEmpresa _repoEmpresa)
        {
            repoEmpresa = _repoEmpresa;
        }

        public Empresa Adicionar(Empresa empresa)
        {
           repoEmpresa.Adicionar(empresa);
            return empresa;
        }

        public Empresa Atualizar(Empresa empresa)
        {
            repoEmpresa.Atualizar(empresa);
            return empresa;
        }

        public Empresa Remover(Empresa empresa)
        {
            repoEmpresa.Remover(empresa);
            return empresa;
        }

        public IEnumerable<Empresa> ObterTodos()
        {
            return repoEmpresa.ObterTodos();
        }

        public Empresa ObterPorId(int id)
        {
            return repoEmpresa.ObterPorId(id);
        }

        public Empresa ObterPorApelido(string apelido)
        {
            return repoEmpresa.ObterPorApelido(apelido);
        }

        public Empresa ObterPorCpfCnpj(string cpfcnpj)
        {
            return repoEmpresa.ObterPorCpfCnpj(cpfcnpj);
        }
            
        public Empresa ObterPorNome(string nome)
        {
            return repoEmpresa.ObterPorNome(nome);
        }
        
        public void Dispose()
        {
            repoEmpresa.Dispose();
            GC.SuppressFinalize(this);
        }
              
    }
}
