using Microsoft.AspNetCore.Mvc;
using InventoryHub.Api.Models;
using InventoryHub.Api.Services;

namespace InventoryHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _service;

        public InventoryController(InventoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { success = true, data = _service.GetAll() });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
                return NotFound(new { success = false, message = "Item not found" });

            return Ok(new { success = true, data = item });
        }

        [HttpPost]
        public IActionResult Add([FromBody] Item item)
        {
            var created = _service.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = created.Id },
                new { success = true, data = created });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Item item)
        {
            var updated = _service.Update(id, item);
            if (!updated)
                return NotFound(new { success = false, message = "Item not found" });

            return Ok(new { success = true, message = "Item updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound(new { success = false, message = "Item not found" });

            return Ok(new { success = true, message = "Item deleted" });
        }
    }
}
