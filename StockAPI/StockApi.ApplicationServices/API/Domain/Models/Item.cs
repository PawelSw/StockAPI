using System.ComponentModel.DataAnnotations;

namespace StockApi.ApplicationServices.API.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public List<string> ProducersNames{ get; set; }
        public string SupplierName { get; set; }

    }
}
