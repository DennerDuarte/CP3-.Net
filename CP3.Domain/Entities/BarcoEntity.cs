using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP3.Domain.Entities
{
    [Table("tb_barco")]
    public class BarcoEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Modelo { get; set; } = string.Empty ;
        public int Ano { get; set; }
        public double Tamanho { get; set; }
    }
}
