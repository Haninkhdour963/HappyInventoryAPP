
using SQLite;

namespace HappyInventoryAPP.Shared.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Unique]
        public string WarehouseName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
        public List<Item> Items { get; set; }









    }
}