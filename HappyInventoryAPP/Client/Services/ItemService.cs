using HappyInventoryAPP.Client.Shared;
using HappyInventoryAPP.Shared.Data;
using HappyInventoryAPP.Shared.Models;

namespace HappyInventoryAPP.Client.Services
{
    public class ItemService : IItemService
    {
        private readonly IHttpService _httpService;

        public ItemService(IHttpService _httpService)
        {
            _httpService = _httpService;
        }
        public async Task AddItem(Item item)
        {
            await _httpService.Post($"api/item", item);
        }

        public async Task DeleteItem(int id)
        {
            await _httpService.Delete($"api/item/{id}");
        }

        public async Task<PagedResult<Item>> GetItem(string? name, string page)
        {
            return await _httpService.Get<PagedResult<Item>>("api/item" + "?page=" + page + "&name=" + name);
        }

        public async Task<Item> GetItem(int id)
        {
            return await _httpService.Get<Item>($"api/item/{id}");
        }

        public async Task UpdateItem(Item item)
        {
            await _httpService.Put($"api/item", item);
        }
    }
}
