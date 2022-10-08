using HappyInventoryAPP.Shared.Data;
using HappyInventoryAPP.Shared.Models;

namespace HappyInventoryAPP.Client.Services
{
    public interface IItemService
    {
        Task<PagedResult<Item>> GetItem(string? name, string page);
        Task<Item> GetItem(int id);

        Task DeleteItem(int id);

        Task AddItem(Item item);

        Task UpdateItem(Item item);

    }
}
