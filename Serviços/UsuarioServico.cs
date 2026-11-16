
using System;

public class UsuarioServico
{
    private AdministradorRepositorio administradorRepositorio = new AdministradorRepositorio();
    private MotoristaRepositorio motoristaRepositorio = new MotoristaRepositorio();
    private PassageiroRepositorio passageiroRepositorio = new PassageiroRepositorio();

    private bool ValidarDados(string nome, string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return false;

        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        if (string.IsNullOrWhiteSpace(senha))
            return false;

        string cpfNumeros = "";

        foreach (char caractere in cpf)
        {
            if (char.IsDigit(caractere))
                cpfNumeros += caractere;
        }

        return cpfNumeros.Length == 11;
    }

    public bool CadastrarAdministrador(string nome, string cpf, string senha)
    {
        if (!ValidarDados(nome, cpf, senha))
            return false;

        cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

        if (administradorRepositorio.BuscarPorCpf(cpf) != null)
            return false;

        Administrador administrador = new Administrador(nome, cpf, senha);

        administradorRepositorio.Cadastrar(administrador);

        return true;
    }

    public bool CadastrarMotorista(string nome, string cpf, string senha)
    {
        if (!ValidarDados(nome, cpf, senha))
            return false;

        cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

        if (motoristaRepositorio.BuscarPorCpf(cpf) != null)
            return false;

        Motorista motorista = new Motorista(nome, cpf, senha);

        motoristaRepositorio.Cadastrar(motorista);

        return true;
    }

    public bool CadastrarPassageiro(string nome, string cpf, string senha)
    {
        if (!ValidarDados(nome, cpf, senha))
            return false;

        cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

        if (passageiroRepositorio.BuscarPorCpf(cpf) != null)
            return false;

        Passageiro passageiro = new Passageiro(nome, cpf, senha);

        passageiroRepositorio.Cadastrar(passageiro);

        return true;
    }

    public Administrador LoginAdministrador(string cpf, string senha)
{
    cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

    Administrador administrador = administradorRepositorio.BuscarPorCpf(cpf);

    if (administrador == null)
        return null;

    if (administrador.Senha != senha)
        return null;

    return administrador;
}

public Motorista LoginMotorista(string cpf, string senha)
{
    cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

    Motorista motorista = motoristaRepositorio.BuscarPorCpf(cpf);

    if (motorista == null)
        return null;

    if (motorista.Senha != senha)
        return null;

    return motorista;
}

public Passageiro LoginPassageiro(string cpf, string senha)
{
    cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

    Passageiro passageiro = passageiroRepositorio.BuscarPorCpf(cpf);

    if (passageiro == null)
        return null;

    if (passageiro.Senha != senha)
        return null;

    return passageiro;
}
}
