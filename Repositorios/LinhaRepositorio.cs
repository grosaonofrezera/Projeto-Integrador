using MySql.Data.MySqlClient;
using UrbanBus.Models;
using System;
using System.Collections.Generic;

namespace UrbanBus.Repositorios
{
    public class LinhaRepositorio
    {
        private Conexao conexao = new Conexao();

        public void Cadastrar(Linha linha)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "INSERT INTO Linhas (nome, codigo) VALUES (@nome, @codigo)";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@nome", linha.Nome);
                comando.Parameters.AddWithValue("@codigo", linha.Codigo);

                comando.ExecuteNonQuery();
            }
        }

        public List<Linha> Listar()
        {
            List<Linha> linhas = new List<Linha>();

            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM Linhas";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Linha linha = new Linha(
                        Convert.ToInt32(leitor["id"]),
                        leitor["nome"].ToString(),
                        leitor["codigo"].ToString()
                    );

                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        public Linha BuscarPorId(int id)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM Linhas WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);
                comando.Parameters.AddWithValue("@id", id);

                MySqlDataReader leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    return new Linha(
                        Convert.ToInt32(leitor["id"]),
                        leitor["nome"].ToString(),
                        leitor["codigo"].ToString()
                    );
                }

                return null;
            }
        }

        public bool Atualizar(Linha linha)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "UPDATE Linhas SET nome = @nome, codigo = @codigo WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", linha.Id);
                comando.Parameters.AddWithValue("@nome", linha.Nome);
                comando.Parameters.AddWithValue("@codigo", linha.Codigo);

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Excluir(int id)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "DELETE FROM Linhas WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);
                comando.Parameters.AddWithValue("@id", id);

                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}