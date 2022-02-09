using System;
using Dapper;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.LocacaoPage
{
    public static class CreateLocacao
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Locacao");
            Console.WriteLine("-----------------------");

            Console.WriteLine("Nome Cliente: ");
            var nameCliente=Console.ReadLine();

            Console.WriteLine("Nome Filme: ");
            var nameFilme= Console.ReadLine();

            var daysDevolucao=3;

            if(IsLanc(nameFilme)!=0)
                daysDevolucao=2;
            Create(new Locacao
            {
                Id_Cliente=MenuLocacao.GetID(nameCliente,"Cliente"),
                Id_Filme=MenuLocacao.GetID(nameFilme,"Filme"),
                DataLocacao=DateTime.Now,
                DataDevolucao=DateTime.Now.AddDays(daysDevolucao)
            });
            Console.ReadKey();
            MenuLocacao.Load();
        }
        static int IsLanc(string nameFilme)
        {
            var selectSql = $@"SELECT [Lancamento] FROM [Filme] WHERE [Filme].[Titulo] LIKE'{nameFilme}'";
            var items = DataBase.connection.Query<Filme>(selectSql);

            foreach (var item in items)
                return item.Lancamento;
            return 0;
        }
        public static void Create(Locacao locacao)
        {
            try
            {
                var repository= new Repository<Locacao>(DataBase.connection);
                repository.Create(locacao);
                Console.WriteLine("Locacao cadastrado com sucesso");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nao foi possivel cadastrar locacao");
                Console.WriteLine(ex.Message);
            }
        }     
    }
}