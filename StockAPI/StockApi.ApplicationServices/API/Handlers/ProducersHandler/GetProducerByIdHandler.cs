using AutoMapper;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;
using MediatR;

namespace StockApi.ApplicationServices.API.Handlers.ProducersHandler
{
    public class GetProducerByIdHandler : IRequestHandler<GetProducerByIdRequest, GetProducerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetProducerByIdHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetProducerByIdResponse> Handle(GetProducerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProducerByIdQuerry()
            {
                Id = request.ProducerId
            };
            var producers = await querryExecutor.Execute(query);
            var mappedProducers = mapper.Map<Domain.Models.Producer>(producers);

            var response = new GetProducerByIdResponse()
            {
                Data = mappedProducers
            };

            return response;

        }
    }
}
