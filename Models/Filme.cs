using System.ComponentModel.DataAnnotations.Schema;

namespace Locadora.Models
{
    [Table("Filme")]
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa{ get; set; }
        public byte Lancamento { get; set; }
    }
}