namespace Entity_Framework_HomeTask3
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Product> Products { get; set; }

        public Category() 
        { 
            Products = new List<Product>();
        }
    }
}