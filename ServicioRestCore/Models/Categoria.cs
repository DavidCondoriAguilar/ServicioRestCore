using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServicioRestCore.Models
{
    public class Categoria
    {
        //los nombres de los atributos de la clase
        //seran los nombres de los campos de la tabla
        //llave primaria
        [Key]
        //sea autonumerico --> identity(1,1)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codcat { get; set; }
        //no nulos
        [Required]
        //tamaño del campo
        [MaxLength(60, ErrorMessage = "El campo {0} de de tebe como " +
            "maximo {1}")]
        public string nomcat { get; set; }
        //no nulos
        [Required]
        public bool escat { get; set; }
        //metodo constructor
        public Categoria()
        {
            this.producto = new HashSet<Producto>();
        }
        //coleccion virtual es referencia a la tabla
        //con la cual hay relacion 
        public virtual ICollection<Producto> producto { get; set; }
    }
}