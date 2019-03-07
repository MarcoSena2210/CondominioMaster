using CondominioMaster.Domain.Entities;
using CondominioMaster.Domain.Interfaces.Repository;
using CondominioMaster.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Domain.Services
{
    public class ServiceCondominio : IServiceCondominio
    {
        private readonly IRepositoryCondominio repoCondominio;

        public ServiceCondominio(IRepositoryCondominio _repoCondominio)
        {
            repoCondominio = _repoCondominio;
        }

        public Condominio Adicionar(Condominio condominio)
        {
            repoCondominio.Adicionar(condominio);
            return condominio;
        }

        public Condominio Atualizar(Condominio condominio)
        {
            repoCondominio.Atualizar(condominio);
            return condominio;
        }

        public Condominio Remover(Condominio condominio)
        {
            repoCondominio.Remover(condominio);
            return condominio;
        }

        public IEnumerable<Condominio> ObterTodos()
        {
            return repoCondominio.ObterTodos();
        }

        public Condominio ObterPorId(int id)
        {
            return repoCondominio.ObterPorId(id);
        }
        
        public Condominio ObterPorApelido(string apelido)
        {
            return repoCondominio.ObterPorApelido(apelido);
        }

        public Condominio ObterPorCpfCnpj(string cpfcnpj)
        {
            return repoCondominio.ObterPorCpfCnpj(cpfcnpj);
        }

     
        public Condominio ObterPorNome(string nome)
        {
            return repoCondominio.ObterPorNome(nome);
        }

        public void Dispose()
        {
            repoCondominio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
