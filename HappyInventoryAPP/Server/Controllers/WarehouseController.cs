using HappyInventoryAPP.Server.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyInventoryAPP.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository _warehouseRepository)
        {
            _warehouseRepository = _warehouseRepository;
        }

        /// <summary>
        /// Returns a list of paginated users with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAll([FromQuery] string? name, int page)
        {
            return Ok(_warehouseRepository.GetAll(name, page));
        }

        /// <summary>
        /// Gets a specific user by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetWarehouse(int id)
        {
            return Ok(await _warehouseRepository.GetWarehouse(id));
        }

        /// <summary>
        /// Creates a user and hashes password.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddWarehouse(Warehouse warehouse)
        {
            return Ok(await _warehouseRepository.AddWarehouse(warehouse));
        }

        /// <summary>
        /// Updates a user with a specific Id, hashing password if updated.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateWarehouse(Warehouse warehouse)
        {
            return Ok(await _warehouseRepository.UpdateWarehouse(warehouse));
        }

        /// <summary>
        /// Deletes a user with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWarehouse(int Id)
        {
            return Ok(await _warehouseRepository.DeleteWarehouse(Id));
        }
    }
}
