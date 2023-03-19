using System.ComponentModel.DataAnnotations;

namespace StockAPI.DataAccess.Entities
{
    public class Supplier : EntityBase
    {
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        public List<Item> Items { get; set; }

    }
}
