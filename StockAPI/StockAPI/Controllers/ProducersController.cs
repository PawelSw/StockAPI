using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockApi.ApplicationServices.API.Domain.SupplierServices;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducersController : ApiControllerBase
    {
        public ProducersController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        [Route("AllProducers")]
        public Task<IActionResult> GetAllProducers([FromQuery] GetProducersRequest request)
        {
            return this.HandleRequest<GetProducersRequest, GetProducersResponse>(request); 
        }

        [HttpGet]
        [Route("Name")]
        public Task<IActionResult> GetProducerByName([FromQuery] GetProducerByNameRequest request)
        {
            return this.HandleRequest<GetProducerByNameRequest, GetProducerByNameResponse>(request);
        }

        [HttpGet]
        [Route("{producerId}")]
        public Task<IActionResult> GetProducerById([FromRoute] int producerId)
        {
            var request = new GetProducerByIdRequest()
            {
                ProducerId = producerId
            };
            return this.HandleRequest<GetProducerByIdRequest, GetProducerByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProducer([FromBody] AddProducerRequest request)
        {

            return this.HandleRequest<AddProducerRequest, AddProducerResponse>(request);
        }
        [HttpDelete]
        [Route("{producerId}")]
        public Task<IActionResult> DeleteProducer([FromRoute] int producerId)
        {
            var request = new DeleteProducerRequest()
            {
                DeleteId = producerId
            };
         
            return this.HandleRequest<DeleteProducerRequest, DeleteProducerResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> UpdateProducerById([FromRoute] int id, [FromBody] UpdateProducerRequest request)
        {
            request.UpdateId = id;
            return this.HandleRequest<UpdateProducerRequest, UpdateProducerResponse>(request);
        }
    }
}
