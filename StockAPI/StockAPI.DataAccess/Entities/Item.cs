
using System.ComponentModel.DataAnnotations;

namespace StockAPI.DataAccess.Entities
{
    public class Item : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string ItemName { get; set; }
        public int Price { get; set; }
        [MaxLength(150)]
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<Producer> Producers { get; set; }
    }
}
