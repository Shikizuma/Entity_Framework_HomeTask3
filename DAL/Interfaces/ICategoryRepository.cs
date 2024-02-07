using DAL.Entity;

namespace DAL.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        public Task<IEnumerable<Category>> SelectIncludeProducts();
    }
}
