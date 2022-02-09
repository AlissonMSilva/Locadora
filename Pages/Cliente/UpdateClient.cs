using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.Clietes
{
    public static class UpdateClient
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Usuario");
            Console.WriteLine("-----------------------");
            
            Console.WriteLine("ID: ");
            var id=int.Parse(Console.ReadLine());

            Console.WriteLine("Nome: ");
            var name= Console.ReadLine();

            Console.WriteLine("CPF:");
            var cpf=Console.ReadLine();

            Console.WriteLine("Data de Nascimento:YYYY/MM/DD");
            var nasc=Console.ReadLine();

            Update(new Cliente
            {
                Id=id,
                Nome=name,
                CPF=cpf,
                DataNascimento=nasc
            });
            Console.ReadKey();
            MenuClient.Load();
        }

        public static void Update(Cliente cliente)
        {
            try
            {
                var repository=new Repository<Cliente>(DataBase.connection);
                repository.Update(cliente);
                Console.WriteLine("Cliente Atualizado com sucesso");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nao foi possivel apagar cliente");
                Console.WriteLine(ex.Message);
            }
        }
    }
}