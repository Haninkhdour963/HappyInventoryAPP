using HappyInventoryAPP.Server.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyInventoryAPP.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository _itemRepository)
        {
            _itemRepository = _itemRepository;
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAll([FromQuery] string? name, int page)
        {
            return Ok(_itemRepository.GetAll(name, page));
        }
        /// <summary>
        /// Gets a specific user by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            return Ok(await _itemRepository.GetItem(id));
        }

        /// <summary>
        /// Creates a user and hashes password.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddItem(Item item)
        {
            return Ok(await _itemRepository.AddItem(item));
        }

        /// <summary>
        /// Updates a user with a specific Id, hashing password if updated.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateItem(Item item)
        {
            return Ok(await _itemRepository.UpdateItem(item));
        }
        /// <summary>
        /// Deletes a user with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            return Ok(await _itemRepository.DeleteItem(id));
        }
    }
}
