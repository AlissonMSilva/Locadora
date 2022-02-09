using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.LocacaoPage
{
    public static class UpdateLocacao
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Locacao");
            Console.WriteLine("-----------------------");

            Console.WriteLine("ID: ");
            var id= int.Parse(Console.ReadLine());

            Console.WriteLine("Nome Cliente: ");
            var nameCliente=Console.ReadLine();

            Console.WriteLine("Nome Filme: ");
            var nameFilme= Console.ReadLine();

            Console.WriteLine("Adicionar dias a data de Devolucao 1-Sim\n 0-Nao:");
            var opc=int.Parse(Console.ReadLine());
            if(opc==1)
            {
                Update(new Locacao
                {
                    Id=id,
                    Id_Cliente=MenuLocacao.GetID(nameCliente,"Cliente"),
                    Id_Filme=MenuLocacao.GetID(nameFilme,"Filme"),
                    DataLocacao=DateTime.Now,
                    DataDevolucao=DateTime.Now.AddDays(3),
                });
            }
            
            Console.ReadKey();
            MenuLocacao.Load();
        }
        public static void Update(Locacao locacao)
        {
             try
            {
                var repository=new Repository<Locacao>(DataBase.connection);
                repository.Update(locacao);
                Console.WriteLine("Locacao Atualizado com sucesso");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nao foi possivel atualizar o locacao");
                Console.WriteLine(ex.Message);
            }
        }
    }
}