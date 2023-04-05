using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceBackend.Logic.Services;
using EcommerceBackend.Logic.Interfaces;
using Ecommerce.Common.Models;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreItemsController : ControllerBase
    {
        private readonly ILogger _log;
        private readonly IStoreItemService _storeItems;

        public StoreItemsController(IStoreItemService storeItemService, ILoggerFactory loggerFactory)
        {
            _log = loggerFactory.CreateLogger<StoreItemsController>();
            _storeItems = storeItemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreItem(string id)
        {
            var item = await _storeItems.GetStoreItemAsync(id);

            if (item == null) { return NotFound(); }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostStoreItem(StoreItem item)
        {
            var newItem = await _storeItems.CreateStoreItemAsync(item);
            return Ok(newItem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStoreItem(string id)
        {
            var item = await _storeItems.GetStoreItemAsync($"{id}");

            if (item == null) { return NotFound();}

            return Ok(item);
        }
    }
}
