
using System;
using UrbanBus.Models;
using UrbanBus.Servicos;

class Program
{
    static UsuarioServico usuarioServico = new UsuarioServico();
    static LinhaServico linhaServico = new LinhaServico();
    static PontoServico pontoServico = new PontoServico();
    static HorarioServico horarioServico = new HorarioServico();
    static LinhaPontoServico linhaPontoServico = new LinhaPontoServico();

    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("===========================");
            Console.WriteLine("       SISTEMA URBANBUS");
            Console.WriteLine("===========================");
            Console.WriteLine();
            Console.WriteLine("1 - Administrador");
            Console.WriteLine("2 - Motorista");
            Console.WriteLine("3 - Passageiro");
            Console.WriteLine("0 - Sair");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
                AcessoAdministrador();
            else if (opcao == 2)
                AcessoMotorista();
            else if (opcao == 3)
                AcessoPassageiro();
            else if (opcao == 0)
                break;
            else
                Mensagem("Opção inválida!");
        }

        Console.WriteLine("Saindo do UrbanBus...");
    }

    static int LerInt(string mensagem)
    {
        int valor;

        while (true)
        {
            Console.Write(mensagem);

            if (int.TryParse(Console.ReadLine(), out valor))
                return valor;

            Console.WriteLine("Digite um número válido!");
        }
    }

    static string LerTexto(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine() ?? "";
    }

    static TimeSpan LerHorario()
    {
        TimeSpan horario;

        while (true)
        {
            Console.Write("Horário (HH:mm): ");

            if (TimeSpan.TryParse(Console.ReadLine(), out horario))
                return horario;

            Console.WriteLine("Horário inválido!");
        }
    }

    static void Mensagem(string mensagem)
    {
        Console.WriteLine();
        Console.WriteLine(mensagem);
        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }

    static void AcessoAdministrador()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== ADMINISTRADOR ===");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Entrar em conta existente");
            Console.WriteLine("0 - Voltar");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
            {
                Console.Clear();

                string nome = LerTexto("Nome: ");
                string cpf = LerTexto("CPF: ");
                string senha = LerTexto("Senha: ");

                bool resultado = usuarioServico.CadastrarAdministrador(nome, cpf, senha);

                if (resultado)
                {
                    Mensagem("Administrador cadastrado com sucesso! Entrando na conta...");
                    MenuAdministrador();
                }
                else
                {
                    Mensagem("Não foi possível cadastrar. Verifique os dados ou se o CPF já existe.");
                }
            }
            else if (opcao == 2)
            {
                Console.Clear();

                string cpf = LerTexto("CPF: ");
                string senha = LerTexto("Senha: ");

                var administrador = usuarioServico.LoginAdministrador(cpf, senha);

                if (administrador != null)
                {
                    Mensagem("Login realizado com sucesso!");
                    MenuAdministrador();
                }
                else
                {
                    Mensagem("CPF ou senha incorretos.");
                }
            }
            else if (opcao == 0)
            {
                break;
            }
            else
            {
                Mensagem("Opção inválida!");
            }
        }
    }

    static void AcessoMotorista()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== MOTORISTA ===");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Entrar em conta existente");
            Console.WriteLine("0 - Voltar");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
            {
                Console.Clear();

                string nome = LerTexto("Nome: ");
                string cpf = LerTexto("CPF: ");
                string senha = LerTexto("Senha: ");

                bool resultado = usuarioServico.CadastrarMotorista(nome, cpf, senha);

                if (resultado)
                {
                    Mensagem("Motorista cadastrado com sucesso! Entrando na conta...");
                    MenuConsulta("MOTORISTA");
                }
                else
                {
                    Mensagem("Não foi possível cadastrar. Verifique os dados ou se o CPF já existe.");
                }
            }
            else if (opcao == 2)
            {
                Console.Clear();

                string cpf = LerTexto("CPF: ");
                string senha = LerTexto("Senha: ");

                var motorista = usuarioServico.LoginMotorista(cpf, senha);

                if (motorista != null)
                {
                    Mensagem("Login realizado com sucesso!");
                    MenuConsulta("MOTORISTA");
                }
                else
                {
                    Mensagem("CPF ou senha incorretos.");
                }
            }
            else if (opcao == 0)
            {
                break;
            }
            else
            {
                Mensagem("Opção inválida!");
            }
        }
    }

    static void AcessoPassageiro()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== PASSAGEIRO ===");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Entrar em conta existente");
            Console.WriteLine("0 - Voltar");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
            {
                Console.Clear();

                string nome = LerTexto("Nome: ");
                string cpf = LerTexto("CPF: ");
                string senha = LerTexto("Senha: ");

                bool resultado = usuarioServico.CadastrarPassageiro(nome, cpf, senha);

                if (resultado)
                {
                    Mensagem("Passageiro cadastrado com sucesso! Entrando na conta...");
                    MenuConsulta("PASSAGEIRO");
                }
                else
                {
                    Mensagem("Não foi possível cadastrar. Verifique os dados ou se o CPF já existe.");
                }
            }
            else if (opcao == 2)
            {
                Console.Clear();

                string cpf = LerTexto("CPF: ");
                string senha = LerTexto("Senha: ");

                var passageiro = usuarioServico.LoginPassageiro(cpf, senha);

                if (passageiro != null)
                {
                    Mensagem("Login realizado com sucesso!");
                    MenuConsulta("PASSAGEIRO");
                }
                else
                {
                    Mensagem("CPF ou senha incorretos.");
                }
            }
            else if (opcao == 0)
            {
                break;
            }
            else
            {
                Mensagem("Opção inválida!");
            }
        }
    }

    static void MenuAdministrador()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("===========================");
            Console.WriteLine("    MENU ADMINISTRADOR");
            Console.WriteLine("===========================");
            Console.WriteLine("1 - Gerenciar linhas");
            Console.WriteLine("2 - Gerenciar pontos");
            Console.WriteLine("3 - Gerenciar horários");
            Console.WriteLine("4 - Gerenciar pontos das linhas");
            Console.WriteLine("0 - Sair da conta");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
                MenuLinhas();
            else if (opcao == 2)
                MenuPontos();
            else if (opcao == 3)
                MenuHorarios();
            else if (opcao == 4)
                MenuLinhaPontos();
            else if (opcao == 0)
                break;
            else
                Mensagem("Opção inválida!");
        }
    }

    static void MenuLinhas()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== GERENCIAR LINHAS ===");
            Console.WriteLine("1 - Cadastrar linha");
            Console.WriteLine("2 - Listar linhas");
            Console.WriteLine("3 - Atualizar linha");
            Console.WriteLine("4 - Excluir linha");
            Console.WriteLine("0 - Voltar");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
            {
                string nome = LerTexto("Nome da linha: ");
                string codigo = LerTexto("Código: ");

                bool resultado = linhaServico.Cadastrar(nome, codigo);

                Mensagem(resultado ? "Linha cadastrada com sucesso!" : "Não foi possível cadastrar a linha.");
            }
            else if (opcao == 2)
            {
                ListarLinhas();
                Pausar();
            }
            else if (opcao == 3)
            {
                int id = LerInt("ID da linha: ");

                var linha = linhaServico.BuscarPorId(id);

                if (linha == null)
                {
                    Mensagem("Linha não encontrada.");
                    continue;
                }

                string nome = LerTexto("Novo nome: ");
                string codigo = LerTexto("Novo código: ");

                bool resultado = linhaServico.Atualizar(id, nome, codigo);

                Mensagem(resultado ? "Linha atualizada com sucesso!" : "Não foi possível atualizar.");
            }
            else if (opcao == 4)
            {
                int id = LerInt("ID da linha: ");

                bool resultado = linhaServico.Excluir(id);

                Mensagem(resultado ? "Linha excluída com sucesso!" : "Não foi possível excluir a linha.");
            }
            else if (opcao == 0)
                break;
            else
                Mensagem("Opção inválida!");
        }
    }

    static void MenuPontos()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== GERENCIAR PONTOS ===");
            Console.WriteLine("1 - Cadastrar ponto");
            Console.WriteLine("2 - Listar pontos");
            Console.WriteLine("3 - Atualizar ponto");
            Console.WriteLine("4 - Excluir ponto");
            Console.WriteLine("0 - Voltar");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
            {
                string nome = LerTexto("Nome do ponto: ");
                string endereco = LerTexto("Endereço: ");
                string bairro = LerTexto("Bairro: ");

                bool resultado = pontoServico.Cadastrar(nome, endereco, bairro);

                Mensagem(resultado ? "Ponto cadastrado com sucesso!" : "Não foi possível cadastrar o ponto.");
            }
            else if (opcao == 2)
            {
                ListarPontos();
                Pausar();
            }
            else if (opcao == 3)
            {
                int id = LerInt("ID do ponto: ");

                var ponto = pontoServico.BuscarPorId(id);

                if (ponto == null)
                {
                    Mensagem("Ponto não encontrado.");
                    continue;
                }

                string nome = LerTexto("Novo nome: ");
                string endereco = LerTexto("Novo endereço: ");
                string bairro = LerTexto("Novo bairro: ");

                bool resultado = pontoServico.Atualizar(id, nome, endereco, bairro);

                Mensagem(resultado ? "Ponto atualizado com sucesso!" : "Não foi possível atualizar.");
            }
            else if (opcao == 4)
            {
                int id = LerInt("ID do ponto: ");

                bool resultado = pontoServico.Excluir(id);

                Mensagem(resultado ? "Ponto excluído com sucesso!" : "Não foi possível excluir o ponto.");
            }
            else if (opcao == 0)
                break;
            else
                Mensagem("Opção inválida!");
        }
    }

    static void MenuHorarios()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== GERENCIAR HORÁRIOS ===");
            Console.WriteLine("1 - Cadastrar horário");
            Console.WriteLine("2 - Listar horários");
            Console.WriteLine("3 - Atualizar horário");
            Console.WriteLine("4 - Excluir horário");
            Console.WriteLine("0 - Voltar");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
            {
                int linhaId = LerInt("ID da linha: ");
                TimeSpan horario = LerHorario();
                string dia = LerTexto("Dia da semana: ");

                bool resultado = horarioServico.Cadastrar(linhaId, horario, dia);

                Mensagem(resultado ? "Horário cadastrado com sucesso!" : "Não foi possível cadastrar o horário.");
            }
            else if (opcao == 2)
            {
                ListarHorarios();
                Pausar();
            }
            else if (opcao == 3)
            {
                int id = LerInt("ID do horário: ");

                var horario = horarioServico.BuscarPorId(id);

                if (horario == null)
                {
                    Mensagem("Horário não encontrado.");
                    continue;
                }

                int linhaId = LerInt("Novo ID da linha: ");
                TimeSpan hora = LerHorario();
                string dia = LerTexto("Novo dia da semana: ");

                bool resultado = horarioServico.Atualizar(id, linhaId, hora, dia);

                Mensagem(resultado ? "Horário atualizado com sucesso!" : "Não foi possível atualizar.");
            }
            else if (opcao == 4)
            {
                int id = LerInt("ID do horário: ");

                bool resultado = horarioServico.Excluir(id);

                Mensagem(resultado ? "Horário excluído com sucesso!" : "Não foi possível excluir o horário.");
            }
            else if (opcao == 0)
                break;
            else
                Mensagem("Opção inválida!");
        }
    }

    static void MenuLinhaPontos()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== PONTOS DAS LINHAS ===");
            Console.WriteLine("1 - Associar ponto a uma linha");
            Console.WriteLine("2 - Listar associações");
            Console.WriteLine("3 - Atualizar associação");
            Console.WriteLine("4 - Excluir associação");
            Console.WriteLine("0 - Voltar");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
            {
                int linhaId = LerInt("ID da linha: ");
                int pontoId = LerInt("ID do ponto: ");
                int ordem = LerInt("Ordem do ponto na linha: ");

                bool resultado = linhaPontoServico.Cadastrar(linhaId, pontoId, ordem);

                Mensagem(resultado ? "Ponto associado à linha com sucesso!" : "Não foi possível fazer a associação.");
            }
            else if (opcao == 2)
            {
                ListarLinhaPontos();
                Pausar();
            }
            else if (opcao == 3)
            {
                int id = LerInt("ID da associação: ");

                var associacao = linhaPontoServico.BuscarPorId(id);

                if (associacao == null)
                {
                    Mensagem("Associação não encontrada.");
                    continue;
                }

                int linhaId = LerInt("Novo ID da linha: ");
                int pontoId = LerInt("Novo ID do ponto: ");
                int ordem = LerInt("Nova ordem: ");

                bool resultado = linhaPontoServico.Atualizar(id, linhaId, pontoId, ordem);

                Mensagem(resultado ? "Associação atualizada com sucesso!" : "Não foi possível atualizar.");
            }
            else if (opcao == 4)
            {
                int id = LerInt("ID da associação: ");

                bool resultado = linhaPontoServico.Excluir(id);

                Mensagem(resultado ? "Associação excluída com sucesso!" : "Não foi possível excluir.");
            }
            else if (opcao == 0)
                break;
            else
                Mensagem("Opção inválida!");
        }
    }

    static void MenuConsulta(string perfil)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== MENU " + perfil + " ===");
            Console.WriteLine("1 - Consultar linhas");
            Console.WriteLine("2 - Consultar pontos");
            Console.WriteLine("3 - Consultar horários");
            Console.WriteLine("4 - Consultar pontos das linhas");
            Console.WriteLine("0 - Sair da conta");

            int opcao = LerInt("Escolha uma opção: ");

            if (opcao == 1)
            {
                ListarLinhas();
                Pausar();
            }
            else if (opcao == 2)
            {
                ListarPontos();
                Pausar();
            }
            else if (opcao == 3)
            {
                ListarHorarios();
                Pausar();
            }
            else if (opcao == 4)
            {
                ListarLinhaPontos();
                Pausar();
            }
            else if (opcao == 0)
                break;
            else
                Mensagem("Opção inválida!");
        }
    }

    static void ListarLinhas()
    {
        Console.Clear();
        Console.WriteLine("=== LINHAS CADASTRADAS ===");

        var linhas = linhaServico.Listar();

        foreach (Linha linha in linhas)
        {
            Console.WriteLine();
            Console.WriteLine("ID: " + linha.Id);
            Console.WriteLine("Nome: " + linha.Nome);
            Console.WriteLine("Código: " + linha.Codigo);
        }

        if (linhas.Count == 0)
            Console.WriteLine("Nenhuma linha cadastrada.");
    }

    static void ListarPontos()
    {
        Console.Clear();
        Console.WriteLine("=== PONTOS CADASTRADOS ===");

        var pontos = pontoServico.Listar();

        foreach (Ponto ponto in pontos)
        {
            Console.WriteLine();
            Console.WriteLine("ID: " + ponto.Id);
            Console.WriteLine("Nome: " + ponto.Nome);
            Console.WriteLine("Endereço: " + ponto.Endereco);
            Console.WriteLine("Bairro: " + ponto.Bairro);
        }

        if (pontos.Count == 0)
            Console.WriteLine("Nenhum ponto cadastrado.");
    }

    static void ListarHorarios()
    {
        Console.Clear();
        Console.WriteLine("=== HORÁRIOS CADASTRADOS ===");

        var horarios = horarioServico.Listar();

        foreach (Horario horario in horarios)
        {
            Console.WriteLine();
            Console.WriteLine("ID: " + horario.Id);
            Console.WriteLine("Linha: " + horario.LinhaId);
            Console.WriteLine("Horário: " + horario.HorarioSaida);
            Console.WriteLine("Dia: " + horario.DiaSemana);
        }

        if (horarios.Count == 0)
            Console.WriteLine("Nenhum horário cadastrado.");
    }

    static void ListarLinhaPontos()
    {
        Console.Clear();
        Console.WriteLine("=== ASSOCIAÇÕES DE LINHAS E PONTOS ===");

        var associacoes = linhaPontoServico.Listar();

        foreach (LinhaPonto associacao in associacoes)
        {
            Console.WriteLine();
            Console.WriteLine("ID da associação: " + associacao.Id);
            Console.WriteLine("ID da linha: " + associacao.LinhaId);
            Console.WriteLine("ID do ponto: " + associacao.PontoId);
            Console.WriteLine("Ordem: " + associacao.Ordem);
        }

        if (associacoes.Count == 0)
            Console.WriteLine("Nenhuma associação cadastrada.");
    }

    static void Pausar()
    {
        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}
