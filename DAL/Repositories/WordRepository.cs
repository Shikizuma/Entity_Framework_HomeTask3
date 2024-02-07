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
    public class WordRepository : IWordRepository
    {
        private readonly EntityDatabase _context;
        public WordRepository(EntityDatabase context)
        {
            _context = context;
        }
        public async Task<bool> Create(Word entity)
        {
            try
            {
                _context.Words.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Word entity)
        {
            try
            {
                _context.Words.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Word> GetById(Guid id)
        {
            return await _context.Words.FindAsync(id);
        }

        public async Task<IEnumerable<Word>> Select()
        {
            return await _context.Words.ToListAsync();
        }

        public async Task<IEnumerable<Word>> SelectIncludeKeyParamsProducts()
        {
            return await _context.Words
          .Include(w => w.ProductLinks) 
              .ThenInclude(kp => kp.Product)  
          .ToListAsync();
        }

        public async Task<Word> Update(Word entity)
        {
            var existingWord = await _context.Words.FindAsync(entity.Id);

            if (existingWord == null)
            {
                return null;
            }

            existingWord.Header = entity.Header;
            existingWord.KeyWord = entity.KeyWord;
            existingWord.ProductLinks = entity.ProductLinks;

            await _context.SaveChangesAsync();

            return existingWord;
        }
    }
}
