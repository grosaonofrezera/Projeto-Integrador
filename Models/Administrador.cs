class Administrador
{
    private int id;
    private string nome;
    private string cpf;
    private string senha;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Cpf
    {
        get { return cpf; }
        set { cpf = value; }
    }

    public string Senha
    {
        get { return senha; }
        set { senha = value; }
    }

    public Administrador(string nome, string cpf, string senha)
    {
        this.nome = nome;
        this.cpf = cpf;
        this.senha = senha;
    }
}
