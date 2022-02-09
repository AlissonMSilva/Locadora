using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.FilmePage
{
    public static class UpdateFilme
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Filme");
            Console.WriteLine("-----------------------");
            
            Console.WriteLine("ID: ");
            var id=int.Parse(Console.ReadLine());

            Console.WriteLine("Titulo: ");
            var titulo= Console.ReadLine();

            Console.WriteLine("Classificacao: ");
            var classificacao= int.Parse(Console.ReadLine());

            Console.WriteLine("Lancamento: ");
            var lanc=byte.Parse(Console.ReadLine());

            Update(new Filme
            {
                Id=id,
                Titulo=titulo,
                ClassificacaoIndicativa=classificacao,
                Lancamento=lanc
            });
            Console.ReadKey();
            MenuFilme.Load();
            
        }
        public static void Update(Filme filme)
        {
            try
            {
                var repository=new Repository<Filme>(DataBase.connection);
                repository.Update(filme);
                Console.WriteLine("Filme Atualizado com sucesso");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nao foi possivel apagar o filme");
                Console.WriteLine(ex.Message);
            }
        }
    }

}