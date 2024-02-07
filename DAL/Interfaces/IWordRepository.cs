using DAL.Entity;

namespace DAL.Interfaces
{
    public interface IWordRepository : IBaseRepository<Word>
    {
        public Task<IEnumerable<Word>> SelectIncludeKeyParamsProducts();
    }
}
