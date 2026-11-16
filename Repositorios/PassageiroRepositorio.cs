
using System;
using MySql.Data.MySqlClient;

public class PassageiroRepositorio
{
    private Conexao conexao = new Conexao();

    public void Cadastrar(Passageiro passageiro)
    {
        using (MySqlConnection conn = conexao.Conectar())
        {
            string sql = "INSERT INTO Passageiros (nome, cpf, senha) VALUES (@nome, @cpf, @senha)";

            MySqlCommand comando = new MySqlCommand(sql, conn);

            comando.Parameters.AddWithValue("@nome", passageiro.Nome);
            comando.Parameters.AddWithValue("@cpf", passageiro.Cpf);
            comando.Parameters.AddWithValue("@senha", passageiro.Senha);

            comando.ExecuteNonQuery();
        }
    }

    public Passageiro BuscarPorCpf(string cpf)
    {
        using (MySqlConnection conn = conexao.Conectar())
        {
            string sql = "SELECT * FROM Passageiros WHERE cpf = @cpf";

            MySqlCommand comando = new MySqlCommand(sql, conn);

            comando.Parameters.AddWithValue("@cpf", cpf);

            MySqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                Passageiro passageiro = new Passageiro(
                    leitor["nome"].ToString(),
                    leitor["cpf"].ToString(),
                    leitor["senha"].ToString()
                );

                passageiro.Id = Convert.ToInt32(leitor["id"]);

                return passageiro;
            }

            return null;
        }
    }
}
