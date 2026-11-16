
using System.Collections.Generic;
using UrbanBus.Models;
using UrbanBus.Repositorios;

namespace UrbanBus.Servicos
{
    public class HorarioServico
    {
        private HorarioRepositorio repositorio = new HorarioRepositorio();

        public bool Cadastrar(int linhaId, TimeSpan horarioSaida, string diaSemana)
        {
            if (linhaId <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(diaSemana))
                return false;

            Horario horario = new Horario(0, linhaId, horarioSaida, diaSemana);

            repositorio.Cadastrar(horario);

            return true;
        }

        public List<Horario> Listar()
        {
            return repositorio.Listar();
        }

        public Horario BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return repositorio.BuscarPorId(id);
        }

        public bool Atualizar(int id, int linhaId, TimeSpan horarioSaida, string diaSemana)
        {
            if (id <= 0 || linhaId <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(diaSemana))
                return false;

            Horario horario = new Horario(id, linhaId, horarioSaida, diaSemana);

            return repositorio.Atualizar(horario);
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
                return false;

            return repositorio.Excluir(id);
        }
    }
}
