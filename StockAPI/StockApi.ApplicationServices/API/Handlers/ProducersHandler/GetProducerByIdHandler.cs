using AutoMapper;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;
using MediatR;
using StockApi.ApplicationServices.API.ErrorHandling;

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
            var producer = await querryExecutor.Execute(query);

            if (producer is null)
            {
                return new GetProducerByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedProducers = mapper.Map<Domain.Models.Producer>(producer);

            var response = new GetProducerByIdResponse()
            {
                Data = mappedProducers
            };

            return response;

        }
    }
}
