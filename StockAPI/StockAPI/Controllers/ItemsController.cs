using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.ApplicationServices.API.Domain.ItemServices;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ApiControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        public ItemsController(IMediator mediator, ILogger<ItemsController> logger) : base(mediator) 
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("AllItems")]
        public Task<IActionResult> GetAllItems([FromQuery] GetItemsRequest request)
        {
            return this.HandleRequest<GetItemsRequest, GetItemsResponse>(request);
        }

        [HttpGet]
        [Route("Name")]
        public Task<IActionResult> GetItemByName([FromQuery] GetItemByNameRequest request)
        {
            return this.HandleRequest<GetItemByNameRequest, GetItemByNameResponse>(request);
        }

        [HttpGet]
        [Route("{itemId}")]
        public Task<IActionResult> GetItemById([FromRoute] int itemId)
        {
            var request = new GetItemByIdRequest()
            {
                ItemId = itemId
            };
            return this.HandleRequest<GetItemByIdRequest, GetItemByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddItem([FromBody] AddItemRequest request)
        {
            return this.HandleRequest<AddItemRequest, AddItemResponse>(request);
        }

        [HttpDelete]
        [Route("{itemId}")]
        public Task<IActionResult> DeleteItem([FromRoute] int itemId)
        {
            _logger.LogWarning($"Item with id: {itemId} DELETE action invoked.");
            var request = new DeleteItemRequest()
            {
                DeleteId = itemId
            };
     
            return this.HandleRequest<DeleteItemRequest, DeleteItemResponse>(request);
        }
        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> UpdateItemById([FromRoute] int id, [FromBody] UpdateItemRequest request)
        {
            request.UpdateId = id;
            return this.HandleRequest<UpdateItemRequest, UpdateItemResponse>(request);
        }
    }
}
