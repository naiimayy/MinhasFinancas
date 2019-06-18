using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepositoryContaPagar
    {
        int Inserir(ContaPagar conta);

        List<ContaPagar> ObterTodos(string busca);

        ContaPagar ObterPeloId(int id);

        bool Atualizar(ContaPagar conta);

        bool Apagar(int id);
    }
}
