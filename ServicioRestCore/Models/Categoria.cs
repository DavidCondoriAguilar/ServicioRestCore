using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioRestCore.Models
{
    public class Categoria
    {
        [Key]
        public int codcat { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre de la categoría no puede tener más de 100 caracteres")]
        public string nomcat { get; set; }

        [Required(ErrorMessage = "El estado de la categoría es obligatorio")]
        public bool escat { get; set; }

        public Categoria()
        {
            this.producto = new HashSet<Producto>();
        }

        public virtual ICollection<Producto> producto { get; set; }
    }
}
