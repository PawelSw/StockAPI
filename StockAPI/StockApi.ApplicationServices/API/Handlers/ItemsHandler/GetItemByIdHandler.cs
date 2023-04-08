using AutoMapper;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;
using MediatR;
using StockApi.ApplicationServices.API.ErrorHandling;

namespace StockApi.ApplicationServices.API.Handlers.ItemsHandler
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, GetItemByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetItemByIdHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetItemByIdResponse> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetItemByIdQuerry()
            {
                Id = request.ItemId
            };
            var item = await querryExecutor.Execute(query);

            if (item is null)
            {
                return new GetItemByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedItems = mapper.Map<Domain.Models.Item>(item);

            var response = new GetItemByIdResponse()
            {
                Data = mappedItems
            };

            return response;

        }
    }
}
