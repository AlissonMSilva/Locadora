using System;
using Dapper;
using Locadora.Models;
using Locadora.Pages.Clietes;
using Locadora.Pages.FilmePage;
using Locadora.Pages.LocacaoPage;
using Microsoft.Data.SqlClient;

namespace Locadora
{
    public class Program
    {
        const string connectionString =@"
        Server=localhost,1433;
        Database=Locadora;
        User ID=sa;
        Password=1q2w3e4r@#$
        ;Trusted_Connection=False;
        TrustServerCertificate=True";

        static void Main(string[] args)
        {
            DataBase.connection=new SqlConnection(connectionString);
            DataBase.connection.Open();
                Load();                    
            DataBase.connection.Close();
        }

        
        
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Locadora");
            Console.WriteLine("------------------------");
            Console.WriteLine("Escolha uma da opcoes");
            Console.WriteLine("1 - Usuario");
            Console.WriteLine("2 - Filme");
            Console.WriteLine("3 - Alugar");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();

            var opt=short.Parse(Console.ReadLine());

            switch(opt)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    MenuClient.Load();
                    break;
                case 2:
                    MenuFilme.Load();
                    break;
                case 3:
                    MenuLocacao.Load();
                    break;
                default:
                    Load();
                    break;
            }
        } 
    }
}
