namespace UrbanBus.Models
{
    public class Linha
    {
        private int id;
        private string nome;
        private string codigo;

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

        public Linha(int id, string nome, string codigo)
        {
            Id = id;
            Nome = nome;
            Codigo = codigo;
        }
    }
}