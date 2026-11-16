
using System;
using System.Collections.Generic;
using UrbanBus.Models;
using UrbanBus.Repositorios;

namespace UrbanBus.Servicos
{
    public class HorarioServico
    {
        private HorarioRepositorio repositorio = new HorarioRepositorio();

        private bool ValidarHorario(TimeSpan horarioSaida)
        {
            return horarioSaida >= TimeSpan.Zero &&
                   horarioSaida < TimeSpan.FromDays(1);
        }

        private bool ValidarDiaSemana(string diaSemana)
        {
            if (string.IsNullOrWhiteSpace(diaSemana))
                return false;

            string dia = diaSemana.Trim().ToLower();

            return dia == "segunda-feira" ||
                   dia == "terça-feira" ||
                   dia == "quarta-feira" ||
                   dia == "quinta-feira" ||
                   dia == "sexta-feira" ||
                   dia == "sábado" ||
                   dia == "domingo";
        }

        public bool Cadastrar(int linhaId, TimeSpan horarioSaida, string diaSemana)
        {
            if (linhaId <= 0)
                return false;

            if (!ValidarHorario(horarioSaida))
                return false;

            if (!ValidarDiaSemana(diaSemana))
                return false;

            Horario horario = new Horario(
                0,
                linhaId,
                horarioSaida,
                diaSemana.Trim()
            );

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

            if (!ValidarHorario(horarioSaida))
                return false;

            if (!ValidarDiaSemana(diaSemana))
                return false;

            Horario horario = new Horario(
                id,
                linhaId,
                horarioSaida,
                diaSemana.Trim()
            );

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
