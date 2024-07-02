using System.ComponentModel.DataAnnotations;

namespace ServicioRestCore.Dtos
{
    /// <summary>
    /// Data Transfer Object for Product.
    /// </summary>
    public class ProductoDTO
    {
        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        public int codpro { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre del producto no puede exceder los 100 caracteres.")]
        public string nompro { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        [MaxLength(500, ErrorMessage = "La descripción del producto no puede exceder los 500 caracteres.")]
        public string despro { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "El precio del producto debe ser un valor positivo.")]
        public decimal prepro { get; set; }

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "La cantidad del producto debe ser un valor positivo.")]
        public decimal canpro { get; set; }

        /// <summary>
        /// Gets or sets the product status.
        /// </summary>
        public bool estpro { get; set; }

        /// <summary>
        /// Gets or sets the category code.
        /// </summary>
        public int codcat { get; set; }
    }
}