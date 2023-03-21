using AutoMapper;
using MediatR;
using Microsoft.Identity.Client;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;
using StockAPI.DataAccess.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StockApi.ApplicationServices.API.Handlers.ProducersHandler
{
    public class GetProducersHandler : IRequestHandler<GetProducersRequest, GetProducersResponse>
    {
        private readonly IQuerryExecutor querryExecutor;
        private readonly IMapper mapper;

        public GetProducersHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;

        }
        public async Task<GetProducersResponse> Handle(GetProducersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProducersQuerry();
            var producers = await querryExecutor.Execute(query);
            var mappedProducers = this.mapper.Map<List<Domain.Models.Producer>>(producers);
            var response = new GetProducersResponse()
            {
                Data = mappedProducers,
            };
            return response;


        }
    }
}
