using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServicioRestCore.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codpro { get; set; }
        [Required]
        public string nompro { get; set; }
        [Required]
        public string despro { get; set; }
        [Required]
        public decimal prepro { get; set; }
        [Required]
        public decimal canpro { get; set; }
        [Required]
        public bool estpro { get; set; }
        [Required]
        public int codcat { get; set; }

        [ForeignKey("codcat")]
        public virtual Categoria categoria { get; set; }
    }
}