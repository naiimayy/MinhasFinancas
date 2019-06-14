using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
   public class ContaReceberRepositorio: IRepositoryContaReceber
    {
        private Conexao conexao;

        public ContaReceberRepositorio()
        {
            conexao = new Conexao();
        }

        public int Inserir(ContaReceber conta)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO contas_receber (nome, valor, tipo, descricao, status) 
            VALUES (@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";

            comando.Parameters.AddWithValue("@NOME", conta.Nome);
            comando.Parameters.AddWithValue("@VALOR", conta.Valor);
            comando.Parameters.AddWithValue("@TIPO", conta.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", conta.Descricao);
            comando.Parameters.AddWithValue("@STATUS", conta.Status);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public List<ContaReceber> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT * FROM contas_receber
            WHERE nome like @NOME";

            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<ContaReceber> contas = new List<ContaReceber>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                ContaReceber conta = new ContaReceber();
                conta.Id = Convert.ToInt32(linha["id"]);
                conta.Nome = linha["nome"].ToString();
                conta.Valor = Convert.ToDecimal(linha["valor"]);
                conta.Tipo = linha["tipo"].ToString();
                conta.Descricao = linha["descricao"].ToString();
                conta.Status = linha["status"].ToString();

                contas.Add(conta);
            }
            return contas;




        }

        public ContaReceber ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT 8 FROM contas_receber WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            if (tabela.Rows.Count == 0)
            {
                return null;
            }
            DataRow linha = tabela.Rows[0];
            ContaReceber conta = new ContaReceber();
            conta.Id = Convert.ToInt32(linha["id"]);
            conta.Nome = linha["nome"].ToString();
            conta.Valor = Convert.ToDecimal(linha["valor"]);
            conta.Tipo = linha["tipo"].ToString();
            conta.Descricao = linha["descricao"].ToString();
            conta.Status = linha["status"].ToString();

            return conta;
        }

        public bool Atualizar(ContaReceber conta)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE contas_receber SET 
            nome = @NOME, valor = @VALOR, tipo = @TIPO, descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";

            comando.Parameters.AddWithValue("@ID", conta.Id);
            comando.Parameters.AddWithValue("@NOME", conta.Nome);
            comando.Parameters.AddWithValue("@VALOR", conta.Valor);
            comando.Parameters.AddWithValue("@TIPO", conta.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", conta.Descricao);
            comando.Parameters.AddWithValue("@STATUS", conta.Status);

            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"DELETE FROM contas_receber WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
