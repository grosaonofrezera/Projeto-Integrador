namespace UrbanBus.Models
{
    public class LinhaPonto
    {
        private int id;
        private int linhaid;
        private int pontoid;
        private int ordem;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int LinhaId
        {
            get { return linhaid; }
            set { linhaid = value; }
        }
        public int PontoId
        {
            get { return pontoid; }
            set { pontoid = value; }
        }
        public int Ordem
        {
            get { return ordem; }
            set { ordem = value; }
        }
        public LinhaPonto(int id, int linhaid, int pontoid, int ordem)
        {
            LinhaId = linhaid;
            PontoId = pontoid;
            Ordem = ordem;
        }
    }
}