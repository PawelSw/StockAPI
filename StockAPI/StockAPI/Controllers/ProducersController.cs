using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockApi.ApplicationServices.API.Domain.SupplierServices;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducersController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProducersController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("AllProducers")]
        public async Task<IActionResult> GetAllProducers([FromQuery] GetProducersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("Name")]
        public async Task<IActionResult> GetItemByName([FromQuery] GetProducerByNameRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{producerId}")]
        public async Task<IActionResult> GetProducerById([FromRoute] int producerId)
        {
            var request = new GetProducerByIdRequest()
            {
                ProducerId = producerId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProducer([FromBody] AddProducerRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpDelete]
        [Route("{producerId}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int producerId)
        {
            var request = new DeleteProducerRequest()
            {
                DeleteId = producerId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
            // return this.HandleRequest<DeleteItemRequest, DeleteItemResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProducerById([FromRoute] int id, [FromBody] UpdateProducerRequest request)
        {
            request.UpdateId = id;
            var response = await this.mediator.Send(request);
            return this.Ok(response);


            //request.UpdateId = id;
            //return this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }
    }
}
