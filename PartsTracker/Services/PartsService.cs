using Microsoft.EntityFrameworkCore;
using PartsTracker.Models;

namespace PartsTracker.Services
{
    public class PartsService(PartsContext context)
    {
        private PartsContext Context { get; } = context;

        public async Task<List<Part>> GetAllAsync()
        {
            return await Context.Parts.ToListAsync();
        }

        public async Task<Part?> GetByIdAsync(string partNumber)
        {
            return await Context.Parts.FindAsync(partNumber);
        }

        public async Task<bool> ExistsAsync(string partNumber)
        {
            return await Context.Parts.AnyAsync(p => p.PartNumber == partNumber);
        }

        public async Task<bool> CreateAsync(Part part)
        {
            part.LastStockTake = part.LastStockTake.ToUniversalTime();

            Context.Parts.Add(part);
            try
            {
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(string id, Part part)
        {
            if (id != part.PartNumber)
                return false;

            part.LastStockTake = part.LastStockTake.ToUniversalTime();

            Context.Entry(part).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return await ExistsAsync(id);
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var part = await Context.Parts.FindAsync(id);
            if (part == null)
                return false;

            Context.Parts.Remove(part);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
