using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class KeyParamsRepository : IKeyParamsRepository
    {
        private readonly EntityDatabase _context;
        public KeyParamsRepository(EntityDatabase context)
        {
            _context = context;
        }

        public async Task<bool> Create(KeyParams entity)
        {
            try
            {
                _context.KeyParams.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(KeyParams entity)
        {
            try
            {
                _context.KeyParams.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<KeyParams> GetById(Guid id)
        {
            return await _context.KeyParams.FindAsync(id);
        }

        public async Task<IEnumerable<KeyParams>> Select()
        {
            return await _context.KeyParams.ToListAsync();
        }

        public async Task<IEnumerable<KeyParams>> SelectIncludeWords()
        {
            return await _context.KeyParams.Include(kp => kp.KeyWord).ToListAsync();
        }

        public async Task<KeyParams> Update(KeyParams entity)
        {
            var existingKeyParam = await _context.KeyParams.FindAsync(entity.Id);
            var existingWord = await _context.Users.FindAsync(entity.WordId);
            var existingProduct = await _context.Products.FindAsync(entity.ProductId);

            if (existingKeyParam == null || existingWord == null || existingProduct == null)
            {
                return null;
            }

            existingKeyParam.ProductId = entity.ProductId;
            existingKeyParam.WordId = entity.WordId;
            existingKeyParam.Product = entity.Product;
            existingKeyParam.KeyWord = entity.KeyWord;

            await _context.SaveChangesAsync();

            return existingKeyParam;
        }
    }
}
