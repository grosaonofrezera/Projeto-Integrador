
using MySql.Data.MySqlClient;

public class PassageiroRepositorio
{
    private Conexao conexao = new Conexao();

    public void Cadastrar(Administrador administrador)
    {
        using (MySqlConnection conn = conexao.Conectar())
        {
            string sql = "INSERT INTO Administradores (nome, cpf, senha) VALUES (@nome, @cpf, @senha)";

            MySqlCommand comando = new MySqlCommand(sql, conn);

            comando.Parameters.AddWithValue("@nome", administrador.Nome);
            comando.Parameters.AddWithValue("@cpf", administrador.Cpf);
            comando.Parameters.AddWithValue("@senha", administrador.Senha);

            comando.ExecuteNonQuery();
        }
    }

    public Administrador BuscarPorCpf(string cpf)
    {
        using (MySqlConnection conn = conexao.Conectar())
        {
            string sql = "SELECT * FROM Administradores WHERE cpf = @cpf";

            MySqlCommand comando = new MySqlCommand(sql, conn);

            comando.Parameters.AddWithValue("@cpf", cpf);

            MySqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                Administrador administrador = new Administrador(
                    leitor["nome"].ToString(),
                    leitor["cpf"].ToString(),
                    leitor["senha"].ToString()
                );

                administrador.Id = Convert.ToInt32(leitor["id"]);

                return administrador;
            }

            return null;
        }
    }
}
