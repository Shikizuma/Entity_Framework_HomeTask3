namespace Entity_Framework_HomeTask3
{
    public class KeyParams
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid WordId { get; set; }
        public Word KeyWord { get; set; }
    }
}