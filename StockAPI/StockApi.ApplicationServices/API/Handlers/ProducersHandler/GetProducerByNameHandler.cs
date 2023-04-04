using AutoMapper;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;

namespace StockApi.ApplicationServices.API.Handlers.ProducersHandler
{
    public class GetProducerByNameHandler : IRequestHandler<GetProducerByNameRequest, GetProducerByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetProducerByNameHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetProducerByNameResponse> Handle(GetProducerByNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProducerByNameQuerry()
            {
                Name = request.Name,
            };
            var items = await querryExecutor.Execute(query);
            var mappedItems = mapper.Map<List<Domain.Models.Producer>>(items);

            var response = new GetProducerByNameResponse()
            {
                Data = mappedItems
            };

            return response;

        }
    }
}
