using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.Clietes
{
    public static class CreateClient
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Usuario");
            Console.WriteLine("-----------------------");

            Console.WriteLine("Nome: ");
            var name= Console.ReadLine();

            Console.WriteLine("CPF:");
            var cpf=Console.ReadLine();

            Console.WriteLine("Data de Nascimento:YYYY/MM/DD");
            var nasc=Console.ReadLine();

            Create(new Cliente
            {
                Nome=name,
                CPF=cpf,
                DataNascimento=nasc
            });

        }
        public static void Create(Cliente cliente)
        {
            try
            {
                var repository=new Repository<Cliente>(DataBase.connection);
                repository.Create(cliente);
                Console.WriteLine("Cliente Cadastrado");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nao foi possivel Cadastrar Cliente");
                Console.WriteLine(ex.Message);
            }
        }
    }
}