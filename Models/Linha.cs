namespace UrbanBus.Models
{
    public class Linha
    {
        private int id;
        private string nome;
        private string codigo;
        private string descricao;
        private string status;
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
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public Linha(int id, string nome, string codigo, string descricao, string status)
        {
            Id = id;
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            Status = status;
        }
    }
}