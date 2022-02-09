using System;

namespace Locadora.Pages.FilmePage
{
    public static class MenuFilme
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestao de Filmes");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Cadastrar filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Retornar Menu Pricipal");

            var opt = short.Parse(Console.ReadLine()!);

            switch (opt)
            {
                case 1:
                    ListFilme.Load();
                    break;
                case 2:
                    CreateFilme.Load();
                    break;
                case 3:
                    UpdateFilme.Load();
                    break;
                case 4:
                    DeleteFilme.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}