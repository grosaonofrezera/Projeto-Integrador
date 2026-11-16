using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UrbanBus.Models;

namespace UrbanBus.Repositorios
{
    public class LinhaPontoRepositorio
    {
        private Conexao conexao = new Conexao();

        public void Cadastrar(LinhaPonto linhaPonto)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = @"INSERT INTO LinhaPonto
                (linhaid, pontoid, ordem)
                VALUES (@linhaid, @pontoid, @ordem)";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@linhaid", linhaPonto.LinhaId);
                comando.Parameters.AddWithValue("@pontoid", linhaPonto.PontoId);
                comando.Parameters.AddWithValue("@ordem", linhaPonto.Ordem);

                comando.ExecuteNonQuery();
            }
        }

        public List<LinhaPonto> Listar()
        {
            List<LinhaPonto> linhasPontos = new List<LinhaPonto>();

            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM LinhaPonto";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    LinhaPonto linhaPonto = new LinhaPonto(
                        Convert.ToInt32(leitor["id"]),
                        Convert.ToInt32(leitor["linhaid"]),
                        Convert.ToInt32(leitor["pontoid"]),
                        Convert.ToInt32(leitor["ordem"])
                    );

                    linhasPontos.Add(linhaPonto);
                }
            }

            return linhasPontos;
        }

        public LinhaPonto BuscarPorId(int id)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM LinhaPonto WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", id);

                MySqlDataReader leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    return new LinhaPonto(
                        Convert.ToInt32(leitor["id"]),
                        Convert.ToInt32(leitor["linhaid"]),
                        Convert.ToInt32(leitor["pontoid"]),
                        Convert.ToInt32(leitor["ordem"])
                    );
                }

                return null;
            }
        }

        public bool Atualizar(LinhaPonto linhaPonto)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = @"UPDATE LinhaPonto SET
                linhaid = @linhaid,
                pontoid = @pontoid,
                ordem = @ordem
                WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", linhaPonto.Id);
                comando.Parameters.AddWithValue("@linhaid", linhaPonto.LinhaId);
                comando.Parameters.AddWithValue("@pontoid", linhaPonto.PontoId);
                comando.Parameters.AddWithValue("@ordem", linhaPonto.Ordem);

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Excluir(int id)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "DELETE FROM LinhaPonto WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", id);

                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
