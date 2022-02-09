using System;
using Dapper;

namespace Locadora.Pages.LocacaoPage
{
    public static class MenuLocacao
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestao de locacoes");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Locacoes");
            Console.WriteLine("2 - Cadastrar locacao");
            Console.WriteLine("3 - Atualizar locacao");
            Console.WriteLine("4 - Excluir locacao");
            Console.WriteLine("5 - Retornar Menu Pricipal");

            var opt = short.Parse(Console.ReadLine()!);

            switch (opt)
            {
                case 1:
                    ListLocacao.Load();
                    break;
                case 2:
                    CreateLocacao.Load();
                    break;
                case 3:
                    UpdateLocacao.Load();
                    break;
                case 4:
                    DeleteLocacao.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
        public static int GetID(string name, string column)
        {
            var columnSearch = $"{column}.Nome";
            if (column != "Cliente")
                columnSearch = $"{column}.Titulo";
            var selectSql = $@"
                SELECT [Id] FROM [{column}] WHERE({columnSearch} LIKE '{name}')
                ";
            var id = 0;
            var bus = DataBase.connection.Query(selectSql);
            foreach (var x in bus)
            {
                id = x.Id;
            }
            return id;
        }
    }
}