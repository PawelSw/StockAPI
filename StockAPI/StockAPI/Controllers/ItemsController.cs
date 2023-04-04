using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.ProducerService;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("AllItems")]
        public async Task<IActionResult> GetAllItems([FromQuery] GetItemsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("Name")]
        public async Task<IActionResult> GetItemByName([FromQuery] GetItemByNameRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<IActionResult> GetItemById([FromRoute] int itemId)
        {
            var request = new GetItemByIdRequest()
            {
                ItemId = itemId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{itemId}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int itemId)
        {
            var request = new DeleteItemRequest()
            {
                DeleteId = itemId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
            // return this.HandleRequest<DeleteItemRequest, DeleteItemResponse>(request);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItemById([FromRoute] int id, [FromBody] UpdateItemRequest request)
        {
            request.UpdateId = id;
            var response = await this.mediator.Send(request);
            return this.Ok(response);


            //request.UpdateId = id;
            //return this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }
    }
}
