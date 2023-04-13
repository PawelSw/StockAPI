using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.UserServices;
using StockApi.ApplicationServices.API.ErrorHandling;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.UsersQuerry;

namespace StockApi.ApplicationServices.API.Handlers.UsersHandler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetUserByIdHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuerry()
            {
                Id = request.UserId
            };
            var user = await querryExecutor.Execute(query);

            if (user is null)
            {
                return new GetUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedUsers = mapper.Map<Domain.Models.User>(user);

            var response = new GetUserByIdResponse()
            {
                Data = mappedUsers
            };

            return response;

        }
    }
}
