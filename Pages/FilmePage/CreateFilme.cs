using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.FilmePage
{
    public static class CreateFilme
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Filme");
            Console.WriteLine("-----------------------");

            Console.WriteLine("Titulo: ");
            var titulo= Console.ReadLine();

            Console.WriteLine("Classificacao: ");
            var classificacao= int.Parse(Console.ReadLine());

            Console.WriteLine("Lancamento: 1-Sim\n 0-Nao ");
            var lanc=byte.Parse(Console.ReadLine());

            Create(new Filme
            {
                Titulo=titulo,
                ClassificacaoIndicativa=classificacao,
                Lancamento=lanc
            });
            Console.ReadKey();
            MenuFilme.Load();

        }
        public static void Create(Filme filme)
        {
            try
            {
                var repository= new Repository<Filme>(DataBase.connection);
                repository.Create(filme);
                Console.WriteLine("Filme cadastrado com sucesso");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nao foi possivel cadastrar filme");
                Console.WriteLine(ex.Message);
            }
        }
    }

}