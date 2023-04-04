using MediatR;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Domain.ItemServices
{
    public class UpdateItemRequest : IRequest<UpdateItemResponse>
    {
        public int UpdateId { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public int SupplierId { get; set; }

    }
}
