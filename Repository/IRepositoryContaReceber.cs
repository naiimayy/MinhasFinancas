using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepositoryContaReceber
    {
        int Inserir(ContaReceber conta);

        List<ContaReceber> ObterTodos(string busca);

        ContaReceber ObterPeloId(int id);

        bool Atualizar(ContaReceber conta);

        bool Apagar(int id);
    }
}
