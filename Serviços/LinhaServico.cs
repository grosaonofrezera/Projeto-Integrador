
using System.Collections.Generic;
using UrbanBus.Models;
using UrbanBus.Repositorios;

namespace UrbanBus.Servicos
{
    public class LinhaServico
    {
        private LinhaRepositorio repositorio = new LinhaRepositorio();

        public bool Cadastrar(string nome, string codigo, string descricao, string status)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            if (string.IsNullOrWhiteSpace(codigo))
                return false;

            if (string.IsNullOrWhiteSpace(status))
                return false;

            Linha linha = new Linha(0, nome, codigo, descricao, status);

            repositorio.Cadastrar(linha);

            return true;
        }

        public List<Linha> Listar()
        {
            return repositorio.Listar();
        }

        public Linha BuscarPorId(int id)
        {
            if (id <= 0)
                return null;

            return repositorio.BuscarPorId(id);
        }

        public bool Atualizar(int id, string nome, string codigo, string descricao, string status)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(codigo) ||
                string.IsNullOrWhiteSpace(status))
                return false;

            Linha linha = new Linha(id, nome, codigo, descricao, status);

            return repositorio.Atualizar(linha);
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
                return false;

            return repositorio.Excluir(id);
        }
    }
}
