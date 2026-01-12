namespace WebApplication2.Models
{
    public class Proveedor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
