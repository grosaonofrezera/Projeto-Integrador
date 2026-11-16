
using System;
using UrbanBus.Servicos;

UsuarioServico usuarioServico = new UsuarioServico();

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
    Console.WriteLine();

    int opcao;

    while (true)
    {
        Console.Write("Escolha uma opção: ");
        string entrada = Console.ReadLine() ?? "";

        if (int.TryParse(entrada, out opcao) &&
            opcao >= 0 && opcao <= 3)
        {
            break;
        }

        Console.WriteLine("Opção inválida!");
    }

    if (opcao == 1)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("===========================");
            Console.WriteLine("       ADMINISTRADOR");
            Console.WriteLine("===========================");
            Console.WriteLine();
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Entrar em conta existente");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();

            int opcaoAdministrador;

            while (true)
            {
                Console.Write("Escolha uma opção: ");
                string entrada = Console.ReadLine() ?? "";

                if (int.TryParse(entrada, out opcaoAdministrador) &&
                    opcaoAdministrador >= 0 && opcaoAdministrador <= 2)
                {
                    break;
                }

                Console.WriteLine("Opção inválida!");
            }

            if (opcaoAdministrador == 1)
            {
                Console.Clear();

                Console.WriteLine("=== CADASTRO DE ADMINISTRADOR ===");
                Console.WriteLine();

                Console.Write("Nome: ");
                string nome = Console.ReadLine() ?? "";

                Console.Write("CPF: ");
                string cpf = Console.ReadLine() ?? "";

                Console.Write("Senha: ");
                string senha = Console.ReadLine() ?? "";

                bool resultado = usuarioServico.CadastrarAdministrador(nome, cpf, senha);

                if (resultado)
                    Console.WriteLine("\nAdministrador cadastrado com sucesso!");
                else
                    Console.WriteLine("\nNão foi possível cadastrar. Verifique os dados ou se o CPF já existe.");
            }
            else if (opcaoAdministrador == 2)
            {
                Console.Clear();

                Console.WriteLine("=== LOGIN DE ADMINISTRADOR ===");
                Console.WriteLine();

                Console.Write("CPF: ");
                string cpf = Console.ReadLine() ?? "";

                Console.Write("Senha: ");
                string senha = Console.ReadLine() ?? "";

                var administrador = usuarioServico.LoginAdministrador(cpf, senha);

                if (administrador != null)
                    Console.WriteLine("\nLogin realizado com sucesso!");
                else
                    Console.WriteLine("\nCPF ou senha incorretos.");
            }
            else if (opcaoAdministrador == 0)
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
    else if (opcao == 2)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("===========================");
            Console.WriteLine("         MOTORISTA");
            Console.WriteLine("===========================");
            Console.WriteLine();
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Entrar em conta existente");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();

            int opcaoMotorista;

            while (true)
            {
                Console.Write("Escolha uma opção: ");
                string entrada = Console.ReadLine() ?? "";

                if (int.TryParse(entrada, out opcaoMotorista) &&
                    opcaoMotorista >= 0 && opcaoMotorista <= 2)
                {
                    break;
                }

                Console.WriteLine("Opção inválida!");
            }

            if (opcaoMotorista == 1)
            {
                Console.Clear();

                Console.WriteLine("=== CADASTRO DE MOTORISTA ===");
                Console.WriteLine();

                Console.Write("Nome: ");
                string nome = Console.ReadLine() ?? "";

                Console.Write("CPF: ");
                string cpf = Console.ReadLine() ?? "";

                Console.Write("Senha: ");
                string senha = Console.ReadLine() ?? "";

                bool resultado = usuarioServico.CadastrarMotorista(nome, cpf, senha);

                if (resultado)
                    Console.WriteLine("\nMotorista cadastrado com sucesso!");
                else
                    Console.WriteLine("\nNão foi possível cadastrar. Verifique os dados ou se o CPF já existe.");
            }
            else if (opcaoMotorista == 2)
            {
                Console.Clear();

                Console.WriteLine("=== LOGIN DE MOTORISTA ===");
                Console.WriteLine();

                Console.Write("CPF: ");
                string cpf = Console.ReadLine() ?? "";

                Console.Write("Senha: ");
                string senha = Console.ReadLine() ?? "";

                var motorista = usuarioServico.LoginMotorista(cpf, senha);

                if (motorista != null)
                    Console.WriteLine("\nLogin realizado com sucesso!");
                else
                    Console.WriteLine("\nCPF ou senha incorretos.");
            }
            else if (opcaoMotorista == 0)
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
    else if (opcao == 3)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("===========================");
            Console.WriteLine("         PASSAGEIRO");
            Console.WriteLine("===========================");
            Console.WriteLine();
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Entrar em conta existente");
            Console.WriteLine("0 - Voltar");
            Console.WriteLine();

            int opcaoPassageiro;

            while (true)
            {
                Console.Write("Escolha uma opção: ");
                string entrada = Console.ReadLine() ?? "";

                if (int.TryParse(entrada, out opcaoPassageiro) &&
                    opcaoPassageiro >= 0 && opcaoPassageiro <= 2)
                {
                    break;
                }

                Console.WriteLine("Opção inválida!");
            }

            if (opcaoPassageiro == 1)
            {
                Console.Clear();

                Console.WriteLine("=== CADASTRO DE PASSAGEIRO ===");
                Console.WriteLine();

                Console.Write("Nome: ");
                string nome = Console.ReadLine() ?? "";

                Console.Write("CPF: ");
                string cpf = Console.ReadLine() ?? "";

                Console.Write("Senha: ");
                string senha = Console.ReadLine() ?? "";

                bool resultado = usuarioServico.CadastrarPassageiro(nome, cpf, senha);

                if (resultado)
                    Console.WriteLine("\nPassageiro cadastrado com sucesso!");
                else
                    Console.WriteLine("\nNão foi possível cadastrar. Verifique os dados ou se o CPF já existe.");
            }
            else if (opcaoPassageiro == 2)
            {
                Console.Clear();

                Console.WriteLine("=== LOGIN DE PASSAGEIRO ===");
                Console.WriteLine();

                Console.Write("CPF: ");
                string cpf = Console.ReadLine() ?? "";

                Console.Write("Senha: ");
                string senha = Console.ReadLine() ?? "";

                var passageiro = usuarioServico.LoginPassageiro(cpf, senha);

                if (passageiro != null)
                    Console.WriteLine("\nLogin realizado com sucesso!");
                else
                    Console.WriteLine("\nCPF ou senha incorretos.");
            }
            else if (opcaoPassageiro == 0)
            {
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
    else if (opcao == 0)
    {
        Console.WriteLine("Saindo do UrbanBus...");
        break;
    }
}
