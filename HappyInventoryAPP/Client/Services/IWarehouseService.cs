using HappyInventoryAPP.Shared.Data;
using HappyInventoryAPP.Shared.Models;

namespace HappyInventoryAPP.Client.Services
{
    public interface IWarehouseService
    {
        Task<PagedResult<Warehouse>> GetAll(string? name, string page);
        Task<Warehouse> GetWarehouse(int id);

        Task DeleteWarehouse(int id);

        Task AddWarehouse(Warehouse warehouse);

        Task UpdateWarehouse(Warehouse warehouse);
    }
}
