using System.ComponentModel.DataAnnotations;

namespace ServicioRestCore.Dtos
{
    /// <summary>
    /// Data Transfer Object for Category.
    /// </summary>
    public class CategoriaDTO
    {
        /// <summary>
        /// Gets or sets the category code.
        /// </summary>
        public int codcat { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre de la categoría no puede exceder los 100 caracteres.")]
        public string nomcat { get; set; }

        /// <summary>
        /// Gets or sets the category status.
        /// </summary>
        public bool estcat { get; set; }
    }
}
