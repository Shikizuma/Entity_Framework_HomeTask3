using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EntityDatabase _context;
        public UserRepository(EntityDatabase context)
        {
            _context = context;
        }

        public async Task<bool> Create(User entity)
        {
            try
            {
                _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(User entity)
        {
            try
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> Select()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            var existingUser = await _context.Users.FindAsync(entity.Id);
      
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = entity.Name;
            existingUser.Login = entity.Login;
            existingUser.Email = entity.Email;
            existingUser.Password = entity.Password;
            existingUser.Carts = entity.Carts;

            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}
