using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coworking_salas.Models
{
    [Table("Salas")]
    public class Sala
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string TipoSala { get; set; }
        [Required]
        public string Capacidade { get; set; }
        [Required]
        public string Descrição { get; set; }
        [Required]
        public string Recursos { get; set; }
        [Required]
        public  int CriadoEm { get; set; }
        public ICollection<Uso> Usos { get; set; }
    }
}
