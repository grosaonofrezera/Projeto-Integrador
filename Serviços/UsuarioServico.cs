
using System;
using System.Text.RegularExpressions;

public class UsuarioServico
{
    private AdministradorRepositorio administradorRepositorio = new AdministradorRepositorio();
    private MotoristaRepositorio motoristaRepositorio = new MotoristaRepositorio();
    private PassageiroRepositorio passageiroRepositorio = new PassageiroRepositorio();

    private string LimparCPF(string cpf)
    {
        return cpf.Replace(".", "").Replace("-", "").Replace(" ", "");
    }

    private bool ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return false;

        return Regex.IsMatch(nome.Trim(), @"^[\p{L}\s]+$");
    }

    private bool ValidarCPF(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = LimparCPF(cpf);

        if (!Regex.IsMatch(cpf, @"^\d{11}$"))
            return false;

        bool todosIguais = true;

        for (int i = 1; i < cpf.Length; i++)
        {
            if (cpf[i] != cpf[0])
                todosIguais = false;
        }

        if (todosIguais)
            return false;

        int soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * (10 - i);
        }

        int primeiroDigito = (soma * 10) % 11;

        if (primeiroDigito == 10)
            primeiroDigito = 0;

        if (primeiroDigito != int.Parse(cpf[9].ToString()))
            return false;

        soma = 0;

        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * (11 - i);
        }

        int segundoDigito = (soma * 10) % 11;

        if (segundoDigito == 10)
            segundoDigito = 0;

        if (segundoDigito != int.Parse(cpf[10].ToString()))
            return false;

        return true;
    }

    private bool ValidarSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            return false;

        return senha.Length >= 4;
    }

    private bool ValidarDados(string nome, string cpf, string senha)
    {
        return ValidarNome(nome) &&
               ValidarCPF(cpf) &&
               ValidarSenha(senha);
    }

    public bool CadastrarAdministrador(string nome, string cpf, string senha)
    {
        if (!ValidarDados(nome, cpf, senha))
            return false;

        cpf = LimparCPF(cpf);

        if (administradorRepositorio.BuscarPorCpf(cpf) != null)
            return false;

        Administrador administrador = new Administrador(nome.Trim(), cpf, senha);

        administradorRepositorio.Cadastrar(administrador);

        return true;
    }

    public bool CadastrarMotorista(string nome, string cpf, string senha)
    {
        if (!ValidarDados(nome, cpf, senha))
            return false;

        cpf = LimparCPF(cpf);

        if (motoristaRepositorio.BuscarPorCpf(cpf) != null)
            return false;

        Motorista motorista = new Motorista(nome.Trim(), cpf, senha);

        motoristaRepositorio.Cadastrar(motorista);

        return true;
    }

    public bool CadastrarPassageiro(string nome, string cpf, string senha)
    {
        if (!ValidarDados(nome, cpf, senha))
            return false;

        cpf = LimparCPF(cpf);

        if (passageiroRepositorio.BuscarPorCpf(cpf) != null)
            return false;

        Passageiro passageiro = new Passageiro(nome.Trim(), cpf, senha);

        passageiroRepositorio.Cadastrar(passageiro);

        return true;
    }

    public Administrador LoginAdministrador(string cpf, string senha)
    {
        if (!ValidarCPF(cpf) || string.IsNullOrWhiteSpace(senha))
            return null;

        cpf = LimparCPF(cpf);

        Administrador administrador = administradorRepositorio.BuscarPorCpf(cpf);

        if (administrador == null)
            return null;

        if (administrador.Senha != senha)
            return null;

        return administrador;
    }

    public Motorista LoginMotorista(string cpf, string senha)
    {
        if (!ValidarCPF(cpf) || string.IsNullOrWhiteSpace(senha))
            return null;

        cpf = LimparCPF(cpf);

        Motorista motorista = motoristaRepositorio.BuscarPorCpf(cpf);

        if (motorista == null)
            return null;

        if (motorista.Senha != senha)
            return null;

        return motorista;
    }

    public Passageiro LoginPassageiro(string cpf, string senha)
    {
        if (!ValidarCPF(cpf) || string.IsNullOrWhiteSpace(senha))
            return null;

        cpf = LimparCPF(cpf);

        Passageiro passageiro = passageiroRepositorio.BuscarPorCpf(cpf);

        if (passageiro == null)
            return null;

        if (passageiro.Senha != senha)
            return null;

        return passageiro;
    }
}
