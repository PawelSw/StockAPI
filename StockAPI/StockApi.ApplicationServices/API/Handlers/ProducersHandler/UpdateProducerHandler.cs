using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS.Commands.ItemsCommand;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;
using StockAPI.DataAccess.CQRS.Commands.ProducersCommand;

namespace StockApi.ApplicationServices.API.Handlers.ProducersHandler
{
    public class UpdateProducerHandler : IRequestHandler<UpdateProducerRequest, UpdateProducerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuerryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateProducerHandler(
            IMapper mapper,
            IQuerryExecutor queryExecutor,
            ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateProducerResponse> Handle(UpdateProducerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProducerByIdQuerry()
            {
                Id = request.UpdateId
            };
            //var product = await _queryExecutor.Execute(query);

            //if (product is null)
            //{
            //    return new UpdateProductResponse()
            //    {
            //        Error = new ErrorModel(ErrorType.NotFound)
            //    };
            //}

            var mappedProducer = _mapper.Map<StockAPI.DataAccess.Entities.Producer>(request);

            var command = new UpdateProducerCommand()
            {
                Parameter = mappedProducer,
            };

            var updatedProducer = await _commandExecutor.Execute(command);

            var response = new UpdateProducerResponse()
            {
                Data = _mapper.Map<Domain.Models.Producer>(updatedProducer)
            };

            return response;
        }
    }
}
