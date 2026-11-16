
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UrbanBus.Models;
using UrbanBus.Repositorios;

namespace UrbanBus.Servicos
{
    public class PontoServico
    {
        private PontoRepositorio repositorio = new PontoRepositorio();

        private bool ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            return Regex.IsMatch(nome.Trim(), @"^[\p{L}\s]+$");
        }

        private bool ValidarEndereco(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                return false;

            return Regex.IsMatch(endereco.Trim(), @"^[\p{L}\p{N}\s.,º°/-]+$");
        }

        private bool ValidarBairro(string bairro)
        {
            if (string.IsNullOrWhiteSpace(bairro))
                return false;

            return Regex.IsMatch(bairro.Trim(), @"^[\p{L}\s]+$");
        }

        private bool ValidarDados(string nome, string endereco, string bairro)
        {
            return ValidarNome(nome) &&
                   ValidarEndereco(endereco) &&
                   ValidarBairro(bairro);
        }

        public bool Cadastrar(string nome, string endereco, string bairro)
        {
            if (!ValidarDados(nome, endereco, bairro))
                return false;

            Ponto ponto = new Ponto(
                0,
                nome.Trim(),
                endereco.Trim(),
                bairro.Trim()
            );

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

            if (!ValidarDados(nome, endereco, bairro))
                return false;

            Ponto ponto = new Ponto(
                id,
                nome.Trim(),
                endereco.Trim(),
                bairro.Trim()
            );

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
