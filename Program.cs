
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
        string entrada = Console.ReadLine();

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
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out opcaoAdministrador) &&
                    opcaoAdministrador >= 0 && opcaoAdministrador <= 2)
                {
                    break;
                }

                Console.WriteLine("Opção inválida!");
            }

            if (opcaoAdministrador == 1)
            {
                Console.WriteLine("Cadastro de administrador será implementado.");
            }
            else if (opcaoAdministrador == 2)
            {
                Console.WriteLine("Login de administrador será implementado.");
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
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out opcaoMotorista) &&
                    opcaoMotorista >= 0 && opcaoMotorista <= 2)
                {
                    break;
                }

                Console.WriteLine("Opção inválida!");
            }

            if (opcaoMotorista == 1)
            {
                Console.WriteLine("Cadastro de motorista será implementado.");
            }
            else if (opcaoMotorista == 2)
            {
                Console.WriteLine("Login de motorista será implementado.");
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
                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out opcaoPassageiro) &&
                    opcaoPassageiro >= 0 && opcaoPassageiro <= 2)
                {
                    break;
                }

                Console.WriteLine("Opção inválida!");
            }

            if (opcaoPassageiro == 1)
            {
                Console.WriteLine("Cadastro de passageiro será implementado.");
            }
            else if (opcaoPassageiro == 2)
            {
                Console.WriteLine("Login de passageiro será implementado.");
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
