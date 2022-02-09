using System;

namespace Locadora.Pages.Clietes
{
    public static class MenuClient
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestao de Usuarios");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usuarios");
            Console.WriteLine("2 - Cadastrar usuario");
            Console.WriteLine("3 - Atualizar usuario");
            Console.WriteLine("4 - Excluir usuario");
            Console.WriteLine("5 - Retornar Menu Pricipal");

            var opt = short.Parse(Console.ReadLine()!);

            switch (opt)
            {
                case 1:
                    ListClient.Load();
                    break;
                case 2:
                    CreateClient.Load();
                    break;
                case 3:
                    UpdateClient.Load();
                    break;
                case 4:
                    DeleteClient.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}