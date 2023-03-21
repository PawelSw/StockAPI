using AutoMapper;
using MediatR;
using Microsoft.Identity.Client;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Handlers.ProducersHandler
{
    public class GetProducersHandler : IRequestHandler<GetProducersRequest, GetProducersResponse>
    {
        private readonly IRepository<Producer> producersRepository;
        private readonly IMapper mapper;

        public GetProducersHandler(IRepository<Producer> producersRepository, IMapper mapper) 
        {
            this.producersRepository = producersRepository;
            this.mapper = mapper;
        }
        public Task<GetProducersResponse> Handle(GetProducersRequest request, CancellationToken cancellationToken)
        {
            var producers = this.producersRepository.GetAll();
            var mappedProducers = this.mapper.Map<List<Domain.Models.Producer>>(producers);
            var response = new GetProducersResponse()
            {
                Data = mappedProducers,
            };
            return Task.FromResult(response);


        }
    }
}
