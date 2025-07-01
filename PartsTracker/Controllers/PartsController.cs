using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartsTracker.Models;
using PartsTracker.Services;

namespace PartsTracker.Controllers
{
    [ApiController]
    [Route("api/parts")]
    public class PartsController(ILogger<PartsController> logger, PartsService partsService) : ControllerBase
    {

        public ILogger<PartsController> Logger { get; } = logger;
        public PartsService PartsService { get; } = partsService;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetParts()
        {
            return await partsService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetPart(string id)
        {
            var part = await partsService.GetByIdAsync(id);
            return part is null ? NotFound() : Ok(part);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePart(Part part)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var success = await partsService.CreateAsync(part);
            if (!success)
                return Conflict("Part already exists.");

            return CreatedAtAction(nameof(GetPart), new { id = part.PartNumber }, part);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePart(string id, Part part)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var success = await partsService.UpdateAsync(id, part);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart(string id)
        {
            var success = await partsService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
