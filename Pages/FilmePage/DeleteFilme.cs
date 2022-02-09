using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.FilmePage
{
    public static class DeleteFilme
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Usuario");
            Console.WriteLine("----------------");
            Console.WriteLine("Informe o nome do Filme que sera deletado");
            var name = Console.ReadLine();
            Delete(name.ToUpper());
            Console.ReadKey();
            MenuFilme.Load();
        }
        private static void Delete(string name)
        {
            try
            {
                if(name!=null)
                {
                    var repository=new Repository<Filme>(DataBase.connection);
                    repository.Delete("Filme",name);
                    Console.WriteLine("Filme apagado com sucesso");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nao foi possivel apagar filme");
                Console.WriteLine(ex.Message);
            }
        }
    }
}