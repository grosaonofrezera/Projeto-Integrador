using MySql.Data.MySqlClient;
using UrbanBus.Models;

namespace UrbanBus.Repositorios
{
    public class PontoRepositorio
    {
        private Conexao conexao = new Conexao();

        public void Cadastrar(Ponto ponto)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = @"INSERT INTO Pontos
                (nome, endereco, bairro)
                VALUES (@nome, @endereco, @bairro)";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@nome", ponto.Nome);
                comando.Parameters.AddWithValue("@endereco", ponto.Endereco);
                comando.Parameters.AddWithValue("@bairro", ponto.Bairro);

                comando.ExecuteNonQuery();
            }
        }

        public List<Ponto> Listar()
        {
            List<Ponto> pontos = new List<Ponto>();

            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM Pontos";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Ponto ponto = new Ponto(
                        Convert.ToInt32(leitor["id"]),
                        leitor["nome"].ToString(),
                        leitor["endereco"].ToString(),
                        leitor["bairro"].ToString()
                    );

                    pontos.Add(ponto);
                }
            }

            return pontos;
        }

        public Ponto BuscarPorId(int id)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM Pontos WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", id);

                MySqlDataReader leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    return new Ponto(
                        Convert.ToInt32(leitor["id"]),
                        leitor["nome"].ToString(),
                        leitor["endereco"].ToString(),
                        leitor["bairro"].ToString()
                    );
                }

                return null;
            }
        }

        public bool Atualizar(Ponto ponto)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = @"UPDATE Pontos SET
                nome = @nome,
                endereco = @endereco,
                bairro = @bairro
                WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", ponto.Id);
                comando.Parameters.AddWithValue("@nome", ponto.Nome);
                comando.Parameters.AddWithValue("@endereco", ponto.Endereco);
                comando.Parameters.AddWithValue("@bairro", ponto.Bairro);

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Excluir(int id)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "DELETE FROM Pontos WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", id);

                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
