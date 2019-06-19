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
    public class ClientePessoaFisicaRepositorio: IRepositoryClientePessoaFisica
    {
        private Conexao conexao;

        public ClientePessoaFisicaRepositorio()
        {
            conexao = new Conexao();
        }

        public int Inserir (ClientePessoaFisica cliente)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO clientes_pessoa_fisica (nome, cpf, data_nascimento, rg, sexo)
                                  VALUES (@NOME, @CPF, @DATA_NASCIMENTO, @RG, @SEXO)";

            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.Data_nascimento);
            comando.Parameters.AddWithValue("@RG", cliente.Rg);
            comando.Parameters.AddWithValue("@SEXO", cliente.Sexo);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;




        }

        public List<ClientePessoaFisica> ObterTodos (string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT * FROM clientes_pessoa_fisica WHERE nome LIKE @NOME";

            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            List<ClientePessoaFisica> pessoas = new List<ClientePessoaFisica>();
            for(int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                ClientePessoaFisica pessoa = new ClientePessoaFisica();
                pessoa.Id = Convert.ToInt32(linha["id"]);
                pessoa.Nome = linha["nome"].ToString();
                pessoa.Cpf = linha["cpf"].ToString();
                pessoa.Data_nascimento = Convert.ToDateTime(linha["data_nascimento"]);
                pessoa.Rg = linha["rg"].ToString();
                pessoa.Sexo = linha["sexo"].ToString();

                pessoas.Add(pessoa);
            }
            return pessoas;
                                  
        }

        public ClientePessoaFisica ObterPeloId (int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT * FROM clientes_pessoa_fisica WHERE id = @ID";
            comando.Parameters.AddWithValue("ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            if(tabela.Rows.Count == 0)
            {
                return null;
            }
            DataRow linha = tabela.Rows[0];
            ClientePessoaFisica pessoa = new ClientePessoaFisica();
            pessoa.Id = Convert.ToInt32(linha["id"]);
            pessoa.Nome = linha["nome"].ToString();
            pessoa.Cpf = linha["cpf"].ToString();
            pessoa.Data_nascimento = Convert.ToDateTime(linha["data_nascimento"]);
            pessoa.Rg = linha["rg"].ToString();
            pessoa.Sexo = linha["sexo"].ToString();

            return pessoa;
        }

        public bool Atualizar (ClientePessoaFisica cliente)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE clientes_pessoa_fisica SET nome = @NOME, cpf = @CPF, data_nascimento = @DATA_NASCIMENTO, rg = @RG, sexo = @SEXO WHERE id = @ID";

            comando.Parameters.AddWithValue("@ID", cliente.Id);
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.Data_nascimento);
            comando.Parameters.AddWithValue("@RG", cliente.Rg);
            comando.Parameters.AddWithValue("@SEXO", cliente.Sexo);

            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"DELETE FROM clientes_pessoa_fisica WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
