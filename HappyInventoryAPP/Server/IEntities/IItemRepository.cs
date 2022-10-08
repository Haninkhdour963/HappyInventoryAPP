
using System.Linq.Dynamic.Core;


namespace HappyInventoryAPP.Server
{
    public interface IItemRepository
    {
        PagedResult<Item> GetAll(string? name, int page);
        Task<Item?> GetItem(int Id);
        Task<Item> AddItem(Item item);
        Task<Item?> UpdateItem(Item item);
        Task<Item?> DeleteItem(int Id);
    }
}
