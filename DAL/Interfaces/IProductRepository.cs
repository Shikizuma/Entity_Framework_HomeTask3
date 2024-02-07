using DAL.Entity;

namespace DAL.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<IEnumerable<Product>> SelectIncludeCategory();
        public Task<Product> GetByIdIncludWord(string name);
    }
}
