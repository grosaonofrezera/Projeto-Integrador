
using MySql.Data.MySqlClient;
using UrbanBus.Models;

namespace UrbanBus.Repositorios
{
    public class LinhaRepositorio
    {
        private Conexao conexao = new Conexao();

        // CADASTRAR LINHA
        public void Cadastrar(Linha linha)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "INSERT INTO Linhas (nome, codigo, descricao, status) " +
                             "VALUES (@nome, @codigo, @descricao, @status)";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@nome", linha.Nome);
                comando.Parameters.AddWithValue("@codigo", linha.Codigo);
                comando.Parameters.AddWithValue("@descricao", linha.Descricao);
                comando.Parameters.AddWithValue("@status", linha.Status);

                comando.ExecuteNonQuery();
            }
        }

        // LISTAR LINHAS
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
                        leitor["codigo"].ToString(),
                        leitor["descricao"].ToString(),
                        leitor["status"].ToString()
                    );

                    linhas.Add(linha);
                }
            }

            return linhas;
        }

        // BUSCAR LINHA PELO ID
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
                    Linha linha = new Linha(
                        Convert.ToInt32(leitor["id"]),
                        leitor["nome"].ToString(),
                        leitor["codigo"].ToString(),
                        leitor["descricao"].ToString(),
                        leitor["status"].ToString()
                    );

                    return linha;
                }

                return null;
            }
        }

        // ATUALIZAR LINHA
        public bool Atualizar(Linha linha)
        {
            using (MySqlConnection conn = conexao.Conectar())
            {
                string sql = "UPDATE Linhas SET nome = @nome, codigo = @codigo, " +
                             "descricao = @descricao, status = @status WHERE id = @id";

                MySqlCommand comando = new MySqlCommand(sql, conn);

                comando.Parameters.AddWithValue("@id", linha.Id);
                comando.Parameters.AddWithValue("@nome", linha.Nome);
                comando.Parameters.AddWithValue("@codigo", linha.Codigo);
                comando.Parameters.AddWithValue("@descricao", linha.Descricao);
                comando.Parameters.AddWithValue("@status", linha.Status);

                return comando.ExecuteNonQuery() > 0;
            }
        }

        // EXCLUIR LINHA
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
