using HappyInventoryAPP.Client.Shared;
using HappyInventoryAPP.Shared.Data;
using HappyInventoryAPP.Shared.Models;

namespace HappyInventoryAPP.Client.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IHttpService _httpService;

        public WarehouseService(IHttpService _httpService)
        {
            _httpService = _httpService;
        }
        public async Task AddWarehouse(Warehouse warehouse)
        {
            await _httpService.Post($"api/warehouse", warehouse);
        }

        public async Task DeleteWarehouse(int id)
        {
            await _httpService.Delete($"api/warehouse/{id}");
        }

        public async Task<PagedResult<Warehouse>> GetAll(string? name, string page)
        {
            return await _httpService.Get<PagedResult<Warehouse>>("api/warehouse" + "?page=" + page + "&name=" + name);
        }

        public async Task<Warehouse> GetWarehouse(int id)
        {
            return await _httpService.Get<Warehouse>($"api/warehouse/{id}");
        }

        public async Task UpdateWarehouse(Warehouse warehouse)
        {
            await _httpService.Put($"api/warehouse", warehouse);
        }
    }
}
