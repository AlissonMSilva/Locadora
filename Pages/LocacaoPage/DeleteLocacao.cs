using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.LocacaoPage
{
    public static class DeleteLocacao
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Locacao");
            Console.WriteLine("----------------");
            Console.WriteLine("Informe o ID da Locacao que sera deletado");
            var id = int.Parse(Console.ReadLine());
            Delete(id);
            Console.ReadKey();
            MenuLocacao.Load();
        }
        private static void Delete(int id)
        {
            try
            {
                var repository=new Repository<Locacao>(DataBase.connection);
                repository.Delete(id);
                Console.WriteLine("Locacao apagada com sucesso");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nao foi possivel apagar Locacao");
                Console.WriteLine(ex.Message);
            }
        }
    }
}