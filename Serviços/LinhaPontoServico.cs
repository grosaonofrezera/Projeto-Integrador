
using System.Collections.Generic;
using UrbanBus.Models;
using UrbanBus.Repositorios;

namespace UrbanBus.Servicos
{
    public class LinhaPontoServico
    {
        private LinhaPontoRepositorio repositorio = new LinhaPontoRepositorio();

        public bool Cadastrar(int linhaId, int pontoId, int ordem)
        {
            if (linhaId <= 0 || pontoId <= 0 || ordem <= 0)
                return false;

            LinhaPonto linhaPonto = new LinhaPonto(0, linhaId, pontoId, ordem);

            repositorio.Cadastrar(linhaPonto);

            return true;
        }

        public List<LinhaPonto> Listar()
        {
            return repositorio.Listar();
        }

        public LinhaPonto BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return repositorio.BuscarPorId(id);
        }

        public bool Atualizar(int id, int linhaId, int pontoId, int ordem)
        {
            if (id <= 0 || linhaId <= 0 || pontoId <= 0 || ordem <= 0)
                return false;

            LinhaPonto linhaPonto = new LinhaPonto(id, linhaId, pontoId, ordem);

            return repositorio.Atualizar(linhaPonto);
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
                return false;

            return repositorio.Excluir(id);
        }
    }
}
