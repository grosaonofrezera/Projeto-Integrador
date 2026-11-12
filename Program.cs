
while (true)
{
    Console.Clear();

    Console.WriteLine("===========================");
    Console.WriteLine("       SISTEMA URBANBUS");
    Console.WriteLine("===========================");
    Console.WriteLine();
    Console.WriteLine("1 - Gerenciar linhas");
    Console.WriteLine("2 - Gerenciar pontos");
    Console.WriteLine("3 - Gerenciar horários");
    Console.WriteLine("4 - Consultar rotas");
    Console.WriteLine("5 - Consultar horários");
    Console.WriteLine("0 - Sair");
    Console.WriteLine();

    int opcao;

    while (true)
    {
        Console.Write("Escolha uma opção: ");
        string entrada = Console.ReadLine();

        if (int.TryParse(entrada, out opcao) &&
            opcao >= 0 && opcao <= 5)
        {
            break;
        }

        Console.WriteLine("Opção inválida!");
    }

    if (opcao == 1)
    {
        // Menu de linhas
    }
    else if (opcao == 2)
    {
        // Menu de pontos
    }
    else if (opcao == 3)
    {
        // Menu de horários
    }
    else if (opcao == 4)
    {
        // Consulta de rotas
    }
    else if (opcao == 5)
    {
        // Consulta de horários
    }
    else if (opcao == 0)
    {
        Console.WriteLine("Saindo do UrbanBus...");
        break;
    }

    Console.WriteLine();
    Console.Write("Quer continuar? (S/N): ");
    string continuar = Console.ReadLine();

    if (continuar.ToLower() == "n")
    {
        Console.WriteLine("Saindo do UrbanBus...");
        break;
    }
}
