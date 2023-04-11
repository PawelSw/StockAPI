using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.UserServices;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.UsersQuerry;

namespace StockApi.ApplicationServices.API.Handlers.UsersHandler
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuerryExecutor _queryExecutor;

        public GetUsersHandler(IMapper mapper, IQuerryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuerry();
            var users = await _queryExecutor.Execute(query);
            var mappedUsers = _mapper.Map<List<Domain.Models.User>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUsers
            };

            return response;
        }
    }
}
