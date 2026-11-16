
using System;
using MySql.Data.MySqlClient;

public class MotoristaRepositorio
{
    private Conexao conexao = new Conexao();

    public void Cadastrar(Motorista motorista)
    {
        using (MySqlConnection conn = conexao.Conectar())
        {
            string sql = "INSERT INTO Motoristas (nome, cpf, senha) VALUES (@nome, @cpf, @senha)";

            MySqlCommand comando = new MySqlCommand(sql, conn);

            comando.Parameters.AddWithValue("@nome", motorista.Nome);
            comando.Parameters.AddWithValue("@cpf", motorista.Cpf);
            comando.Parameters.AddWithValue("@senha", motorista.Senha);

            comando.ExecuteNonQuery();
        }
    }

    public Motorista BuscarPorCpf(string cpf)
    {
        using (MySqlConnection conn = conexao.Conectar())
        {
            string sql = "SELECT * FROM Motoristas WHERE cpf = @cpf";

            MySqlCommand comando = new MySqlCommand(sql, conn);

            comando.Parameters.AddWithValue("@cpf", cpf);

            MySqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                Motorista motorista = new Motorista(
                    leitor["nome"].ToString(),
                    leitor["cpf"].ToString(),
                    leitor["senha"].ToString()
                );

                motorista.Id = Convert.ToInt32(leitor["id"]);

                return motorista;
            }

            return null;
        }
    }
}
