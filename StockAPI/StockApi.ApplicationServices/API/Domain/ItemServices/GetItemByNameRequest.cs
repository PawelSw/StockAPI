using MediatR;

namespace StockApi.ApplicationServices.API.Domain.ItemServices
{
    public class GetItemByNameRequest : IRequest<GetItemByNameResponse>
    {
        public string ItemName { get; set; }
    }
}
