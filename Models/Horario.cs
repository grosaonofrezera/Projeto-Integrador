namespace UrbanBus.Models
{
    public class Horario
    {
        private int id;
        private int linhaid;
        private TimeSpan horarioSaida;
        private string diaSemana;
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
        public TimeSpan HorarioSaida
        {
            get { return horarioSaida; }
            set { horarioSaida = value; }
        }
        public string DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }
        public Horario(int id, int linhaid, TimeSpan horarioSaida, string diaSemana)
        {
            Id = id;
            LinhaId = linhaid;
            HorarioSaida = horarioSaida;
            DiaSemana = diaSemana;
        }
    }
}