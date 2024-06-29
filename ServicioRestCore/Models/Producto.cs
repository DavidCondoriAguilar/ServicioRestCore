using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioRestCore.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codpro { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre del producto no puede tener más de 100 caracteres")]
        public string nompro { get; set; }

        [Required(ErrorMessage = "La descripción del producto es obligatoria")]
        [MaxLength(500, ErrorMessage = "La descripción del producto no puede tener más de 500 caracteres")]
        public string despro { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo")]
        public double prepro { get; set; }

        [Required(ErrorMessage = "La cantidad del producto es obligatoria")]
        [Range(0, double.MaxValue, ErrorMessage = "La cantidad debe ser un valor positivo")]
        public double canpro { get; set; }

        [Required(ErrorMessage = "El estado del producto es obligatorio")]
        public bool estpro { get; set; }

        [Required(ErrorMessage = "La categoría del producto es obligatoria")]
        public int codcat { get; set; }

        public virtual Categoria categoria { get; set; }
    }
}
