
using System.Collections.Generic;
using UrbanBus.Models;
using UrbanBus.Repositorios;

namespace UrbanBus.Servicos
{
    public class PontoServico
    {
        private PontoRepositorio repositorio = new PontoRepositorio();

        public bool Cadastrar(string nome, string endereco, string bairro)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            if (string.IsNullOrWhiteSpace(endereco))
                return false;

            if (string.IsNullOrWhiteSpace(bairro))
                return false;

            Ponto ponto = new Ponto(0, nome, endereco, bairro);

            repositorio.Cadastrar(ponto);

            return true;
        }

        public List<Ponto> Listar()
        {
            return repositorio.Listar();
        }

        public Ponto BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return repositorio.BuscarPorId(id);
        }

        public bool Atualizar(int id, string nome, string endereco, string bairro)
        {
            if (id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(endereco) ||
                string.IsNullOrWhiteSpace(bairro))
                return false;

            Ponto ponto = new Ponto(id, nome, endereco, bairro);

            return repositorio.Atualizar(ponto);
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
                return false;

            return repositorio.Excluir(id);
        }
    }
}
