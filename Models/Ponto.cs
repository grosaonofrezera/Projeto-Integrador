namespace UrbanBus.Models
{
    public class Ponto
    {
        private int id;
        private string nome;
        private string endereco;
        private string bairro;

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
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        public Ponto(int id, string nome, string endereco, string bairro)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Bairro = bairro;
        }


    }
}