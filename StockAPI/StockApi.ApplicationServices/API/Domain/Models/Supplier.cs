using System.ComponentModel.DataAnnotations;

namespace StockApi.ApplicationServices.API.Domain.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
