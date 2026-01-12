using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        public int CategoriaId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El precio del producto debe ser mayor a 0")]
        public decimal Price { get; set; }= decimal.Zero;

        public virtual Proveedor Proveedor { get; set; }
        
        public virtual Categoria Categoria { get; set; }
    }
}