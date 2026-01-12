namespace WebApplication2.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Producto> Productos { get; set; }
    }
}
