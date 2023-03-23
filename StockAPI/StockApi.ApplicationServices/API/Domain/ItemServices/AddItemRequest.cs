using MediatR;
using System.ComponentModel.DataAnnotations;

namespace StockApi.ApplicationServices.API.Domain.ItemServices
{
    public class AddItemRequest : IRequest<AddItemResponse>
    {
        public string ItemName { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
    }
}
