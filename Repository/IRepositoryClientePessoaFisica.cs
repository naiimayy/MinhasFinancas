using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepositoryClientePessoaFisica
    {
        int Inserir(ClientePessoaFisica cliente);

        List<ClientePessoaFisica> ObterTodos(string busca);

        ClientePessoaFisica ObterPeloId(int id);
         
        bool Atualizar(ClientePessoaFisica cliente);

        bool Apagar(int id);
    }
}

