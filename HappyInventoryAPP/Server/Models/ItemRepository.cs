using HappyInventoryAPP.Shared.Data;
using Microsoft.EntityFrameworkCore;

using System.Linq.Dynamic.Core;

namespace HappyInventoryAPP.Server.Models
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext _db)
        {
            _db = _db;
        }

        public async Task<Item> AddItem(Item item)
        {
            // Add New Item
            var result = await _db.Items.AddAsync(item);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Item?> DeleteItem(int id)
        {
            //Delete Item
            var result = await _db.Items.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                _db.Items.Remove(result);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Item not found");
            }
            return result;
        }

        public Shared.Data.PagedResult<Item> GetAll(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _db.Items
                    .Where(p => p.ItemName.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(p => p.Id)
                    .Include(p => p.warehouse)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _db.Items
                     .OrderBy(p => p.Id)
                    .Include(p => p.warehouse)
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<Item?> GetItem(int Id)
        {
            var result = await _db.Items
                .Include(p => p.WarehouseId)
                .FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Item not found");
            }
        }

        public async Task<Item?> UpdateItem(Item item)
        {

            var result = await _db.Items.FirstOrDefaultAsync(p => p.Id == item.Id);
            if (result != null)
            {
                // Update existing person
                _db.Entry(result).CurrentValues.SetValues(item);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("item not found");
            }
            return result;
        }

        System.Linq.Dynamic.Core.PagedResult<Item> IItemRepository.GetAll(string? name, int page)
        {
            throw new NotImplementedException();
        }
    }
}
