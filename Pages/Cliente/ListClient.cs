using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.Clietes
{
    public static class ListClient
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de clietes");
            Console.WriteLine("-----------------------");
            List();
            Console.ReadKey();
            MenuClient.Load();
        }
        public static void List()
        {
            var repository=new Repository<Cliente>(DataBase.connection);
            var users=repository.Read();
            foreach(var user in users)
                Console.WriteLine($"ID:{user.Id} \n Nome:{user.Nome} \n CPF:{user.CPF}");
        }
    }
}