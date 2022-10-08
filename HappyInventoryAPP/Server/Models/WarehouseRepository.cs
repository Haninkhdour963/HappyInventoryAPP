using HappyInventoryAPP.Shared.Data;
using Microsoft.EntityFrameworkCore;


using System.Linq.Dynamic.Core;

namespace HappyInventoryAPP.Server.Models
{
    public class WarehouseRepository : IWarehouseRepository

    {
        private readonly AppDbContext _db;

        public WarehouseRepository(AppDbContext _db)
        {
            _db = _db;
        }
        public async Task<Warehouse> AddWarehouse(Warehouse warehouse)
        {
            //Add New Warehouse In Entity
            var result = await _db.Warehouses.AddAsync(warehouse);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Warehouse?> DeleteWarehouse(int id)
        {
            //Delete Warehouse From Item Entity
            var result = await _db.Warehouses.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _db.Warehouses.Remove(result);
                await _db.SaveChangesAsync();

            }
            else
            {
                throw new KeyNotFoundException("Warehouse not found");
            }
            return result;
        }

        public Shared.Data.PagedResult<Warehouse> GetAll(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _db.Warehouses
                    .Where(p => p.WarehouseName.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(p => p.Id)
                    .Include(p => p.Items)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _db.Warehouses
                    .OrderBy(p => p.Id)
                    .Include(p => p.Items)
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<Warehouse?> GetWarehouse(int Id)
        {
            var result = await _db.Warehouses.FirstOrDefaultAsync(x => x.Id == Id);


            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Warehouse not found");
            }
        }

        public async Task<Warehouse?> UpdateWarehouse(Warehouse warehouse)
        {
            var result = await _db.Warehouses.FirstOrDefaultAsync(p => p.Id == warehouse.Id);
            if (result != null)
            {
                // Update existing person
                _db.Entry(result).CurrentValues.SetValues(warehouse);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("item not found");
            }
            return result;
        }

        System.Linq.Dynamic.Core.PagedResult<Warehouse> IWarehouseRepository.GetAll(string? name, int page)
        {
            throw new NotImplementedException();
        }
    }
}
