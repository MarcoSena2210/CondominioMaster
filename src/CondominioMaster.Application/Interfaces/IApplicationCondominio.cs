using CondominioMaster.Application.ViewModels.AgregacaoEdificacao;
using System;
using System.Collections.Generic;

namespace CondominioMaster.Application.Interfaces
{
     public interface IApplicationCondominio :IDisposable
     {
          CondominioViewModel Adicionar(CondominioViewModel condominio);
          CondominioViewModel Atualizar(CondominioViewModel condominio);
          CondominioViewModel Remover(CondominioViewModel condominio);
          IEnumerable<CondominioViewModel> ObterTodos();
          CondominioViewModel ObterPorId(int id);
          CondominioViewModel ObterPorCpfCnpj(string cpfcnpj);
          CondominioViewModel ObterPorApelido(string apelido);
          CondominioViewModel ObterPorNome(string nome);
     }
}
