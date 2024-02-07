
namespace Entity_Framework_HomeTask3
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double ActionPrice { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Cart> Carts { get; set; }
        public List<KeyParams> KeyWords { get; set; }

        public Product ()
        {
            Carts = new List<Cart> ();
            KeyWords = new List<KeyParams> ();
        }
    }


}