using App.Repositories.Products;

namespace App.Repositories.Categories
{
    public class Category : IAuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}