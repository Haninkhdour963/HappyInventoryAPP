
using SQLite;



namespace HappyInventoryAPP.Shared.Models
{
    public class Item
    {

        public int Id { get; set; }
        [Unique]
        public string ItemName { get; set; }
        public string SKUCode { get; set; }
        public int Qty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal MSRPPrice { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse? warehouse { get; set; }


    }
}