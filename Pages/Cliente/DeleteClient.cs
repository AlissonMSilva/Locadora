using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.Clietes
{
    public static class DeleteClient
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Usuario");
            Console.WriteLine("----------------");
            Console.WriteLine("Informe o nome do usuario que sera deletado");
            var name = Console.ReadLine();
            Delete(name.ToUpper());
            Console.ReadKey();
            MenuClient.Load();
        }
        public static void Delete(string name)
        {
            try
            {
                if(name!=null)
                {
                    var repository=new Repository<Cliente>(DataBase.connection);
                    repository.Delete("Cliente",name);
                    Console.WriteLine($"Cliente {name} deletado com sucesso");
                }
            }
             catch(Exception ex)
            {
                Console.WriteLine($"Nao foi possivel excluir o cliente {name}");
                Console.WriteLine(ex.Message);
            }
        }
    }
}