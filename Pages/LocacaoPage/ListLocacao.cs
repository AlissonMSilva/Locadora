using System;
using Dapper;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.LocacaoPage
{
    public static class ListLocacao
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Locacoes");
            Console.WriteLine("-----------------------");
            List();
            Console.ReadKey();
            MenuLocacao.Load();
        }
        public static void List()
        {
            var repository = new Repository<Locacao>(DataBase.connection);
            var locacoes = repository.Read();
            foreach (var locacao in locacoes)
                Console.WriteLine($"ID:{locacao.Id} \n Nome Cliente:{GetName(locacao.Id_Cliente,"Cliente")} \n Filme:{GetName(locacao.Id_Filme,"Filme")} \n Data Locacao:{locacao.DataLocacao} \n Data Devolucao{locacao.DataDevolucao}");
        }
        static string GetName(int id,string column)
        {
            var columnSearch ="Nome";
            if (column != "Cliente")
                columnSearch = "Titulo";

            var sqlQueryName = @$"SELECT [{columnSearch}] FROM [{column}] WHERE [{column}].[Id] LIKE {id}";
            var items = DataBase.connection.Query(sqlQueryName);
            foreach (var item in items)
            {
                if(column != "Cliente")
                    return item.Titulo;
                return item.Nome;
            }
            return " ";
        }
    }
}