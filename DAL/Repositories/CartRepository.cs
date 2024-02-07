using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly EntityDatabase _context;
        public CartRepository(EntityDatabase context)
        {
            _context = context;
        }

        public async Task<bool> Create(Cart entity)
        {
            try
            {
                _context.Carts.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {           
                return false;
            }
        }

        public async Task<bool> Delete(Cart entity)
        {
            try
            {
                _context.Carts.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Cart> GetById(Guid id)
        {
            return await _context.Carts.FindAsync(id);
        }

        public async Task<IEnumerable<Cart>> Select()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> Update(Cart entity)
        {
            var existingCart = await _context.Carts.FindAsync(entity.Id);
            var existingUser = await _context.Users.FindAsync(entity.UserId);
            var existingProduct = await _context.Products.FindAsync(entity.ProductId);

            if (existingCart == null || existingUser == null || existingProduct == null)
            {
                return null;
            }

            existingCart.UserId = entity.UserId;
            existingCart.ProductId = entity.ProductId;
            existingCart.User = entity.User;
            existingCart.Product = entity.Product;

            await _context.SaveChangesAsync();

            return existingCart;
        }
    }
}
