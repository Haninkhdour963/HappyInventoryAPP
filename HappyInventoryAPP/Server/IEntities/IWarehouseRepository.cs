
using System.Linq.Dynamic.Core;


namespace HappyInventoryAPP.Server
{
    public interface IWarehouseRepository
    {
        PagedResult<Warehouse> GetAll(string? name, int page);
        Task<Warehouse?> GetWarehouse(int Id);
        Task<Warehouse> AddWarehouse(Warehouse warehouse);
        Task<Warehouse?> UpdateWarehouse(Warehouse warehouse);
        Task<Warehouse?> DeleteWarehouse(int Id);
    }
}
