using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;

namespace StockApi.ApplicationServices.API.Handlers.ItemsHandler
{
    public class GetItemByNameHandler : IRequestHandler<GetItemByNameRequest, GetItemByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetItemByNameHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetItemByNameResponse> Handle(GetItemByNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetItemByNameQuerry()
            {
               ItemName = request.ItemName,
            };
            var items = await querryExecutor.Execute(query);
            var mappedItems = mapper.Map<List<Domain.Models.Item>>(items);

            var response = new GetItemByNameResponse()
            {
                Data = mappedItems
            };

            return response;

        }
    }
}
