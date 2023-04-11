using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry;
using StockAPI.DataAccess.CQRS;
using StockApi.ApplicationServices.API.Domain.UserServices;
using StockAPI.DataAccess.CQRS.Querries.UsersQuerry;

namespace StockApi.ApplicationServices.API.Handlers.UsersHandler
{
    public class GetUserByNameHandler : IRequestHandler<GetUserByNameRequest, GetUserByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetUserByNameHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetUserByNameResponse> Handle(GetUserByNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByNameQuerry()
            {
                UserName= request.UserName,
            };
            var users = await querryExecutor.Execute(query);
            var mappedUsers = mapper.Map<List<Domain.Models.User>>(users);

            var response = new GetUserByNameResponse()
            {
                Data = mappedUsers
            };

            return response;

        }
    }
}
