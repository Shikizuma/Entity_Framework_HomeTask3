
namespace Entity_Framework_HomeTask3
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string KeyWord { get; set; }
        public List<KeyParams> ProductLinks { get; set; }

        public Word ()
        {
            ProductLinks = new List<KeyParams> ();
        }
    }
}