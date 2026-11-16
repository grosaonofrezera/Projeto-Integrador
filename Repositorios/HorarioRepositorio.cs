using MySql.Data.MySqlClient;
using UrbanBus.Models;

namespace UrbanBus.Repositorios
{
    public class HorarioRepositorio
    {
        private Conexao conexao = new Conexao();

        public void Cadastrar(Horario horario)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = @"INSERT INTO Horarios
                (linhaid, horarioSaida, diaSemana)
                VALUES (@linhaid, @horarioSaida, @diaSemana)";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@linhaid", horario.LinhaId);
                comando.Parameters.AddWithValue("@horarioSaida", horario.HorarioSaida);
                comando.Parameters.AddWithValue("@diaSemana", horario.DiaSemana);

                comando.ExecuteNonQuery();
            }
        }

        public List<Horario> Listar()
        {
            List<Horario> horarios = new List<Horario>();

            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM Horarios";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                MySqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Horario horario = new Horario(
                        Convert.ToInt32(leitor["id"]),
                        Convert.ToInt32(leitor["linhaid"]),
                        TimeSpan.Parse(leitor["horarioSaida"].ToString()),
                        leitor["diaSemana"].ToString()
                    );

                    horarios.Add(horario);
                }
            }

            return horarios;
        }

        public Horario BuscarPorId(int id)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "SELECT * FROM Horarios WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", id);

                MySqlDataReader leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    return new Horario(
                        Convert.ToInt32(leitor["id"]),
                        Convert.ToInt32(leitor["linhaid"]),
                        TimeSpan.Parse(leitor["horarioSaida"].ToString()),
                        leitor["diaSemana"].ToString()
                    );
                }

                return null;
            }
        }

        public bool Atualizar(Horario horario)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = @"UPDATE Horarios SET
                linhaid = @linhaid,
                horarioSaida = @horarioSaida,
                diaSemana = @diaSemana
                WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", horario.Id);
                comando.Parameters.AddWithValue("@linhaid", horario.LinhaId);
                comando.Parameters.AddWithValue("@horarioSaida", horario.HorarioSaida);
                comando.Parameters.AddWithValue("@diaSemana", horario.DiaSemana);

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Excluir(int id)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "DELETE FROM Horarios WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", id);

                return comando.ExecuteNonQuery() > 0;
            }
        }
    }
}
