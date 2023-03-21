using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Handlers.ItemsHandler
{
    public class GetItemsHandler : IRequestHandler<GetItemsRequest, GetItemsResponse>
    {
        private readonly IRepository<Item> itemRepository;
        private readonly IMapper mapper;
        public GetItemsHandler(IRepository<Item> itemRepository, IMapper mapper) 
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }
        public async Task<GetItemsResponse> Handle(GetItemsRequest request, CancellationToken cancellationToken)
        {
            var items = await this.itemRepository.GetAll();

            var mappedItems = this.mapper.Map<List<Domain.Models.Item>>(items);
            //var DomainItems = items.Select(x => new Domain.Models.Item()
            //{
            //    Id = x.Id,
            //    ItemName = x.ItemName,
            //    Category = x.Category,
        
            //});
            var response = new GetItemsResponse()
            {
                Data = mappedItems
            };
            return response;   

        }
    }
}
