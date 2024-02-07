using DAL.Entity;

namespace DAL.Interfaces
{
    public interface IKeyParamsRepository : IBaseRepository<KeyParams>
    {
        public Task<IEnumerable<KeyParams>> SelectIncludeWords();
    }
}
