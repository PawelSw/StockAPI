using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Handlers.ItemsHandler
{
    public class GetItemsHandler : IRequestHandler<GetItemsRequest, GetItemsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetItemsHandler(IMapper mapper, IQuerryExecutor querryExecutor) 
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetItemsResponse> Handle(GetItemsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetItemsQuerry();
            var items = await querryExecutor.Execute(query);
            var mappedItems = mapper.Map<List<Domain.Models.Item>>(items);

            var response = new GetItemsResponse()
            {
                Data = mappedItems
            };

            return response;

        }
    }
}
