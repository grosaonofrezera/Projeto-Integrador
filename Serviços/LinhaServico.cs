
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UrbanBus.Models;
using UrbanBus.Repositorios;

namespace UrbanBus.Servicos
{
    public class LinhaServico
    {
        private LinhaRepositorio repositorio = new LinhaRepositorio();

        private bool ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            return Regex.IsMatch(nome.Trim(), @"^[\p{L}\s]+$");
        }

        private bool ValidarCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return false;

            return Regex.IsMatch(codigo.Trim(), @"^[a-zA-Z0-9]+$");
        }

        public bool Cadastrar(string nome, string codigo)
        {
            if (!ValidarNome(nome))
                return false;

            if (!ValidarCodigo(codigo))
                return false;

            Linha linha = new Linha(
                0,
                nome.Trim(),
                codigo.Trim()
            );

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

        public bool Atualizar(int id, string nome, string codigo)
        {
            if (id <= 0)
                return false;

            if (!ValidarNome(nome))
                return false;

            if (!ValidarCodigo(codigo))
                return false;

            Linha linha = new Linha(
                id,
                nome.Trim(),
                codigo.Trim()
            );

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
