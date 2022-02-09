using System;
using Locadora.Models;
using Locadora.Repositories;

namespace Locadora.Pages.FilmePage
{
    public static class ListFilme
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de filmes");
            Console.WriteLine("-----------------------");
            List();
            Console.ReadKey();
            MenuFilme.Load();
        }
        public static void List()
        {
            var repository=new Repository<Filme>(DataBase.connection);
            var filmes = repository.Read();
            foreach(var filme in filmes)
                Console.WriteLine($"Titulo: {filme.Titulo} \n Classificacao:{filme.ClassificacaoIndicativa}");
        }
    }
}