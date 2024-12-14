using Microsoft.AspNetCore.Mvc;
using ProjectAPP.Services;
using ProjectAPP.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FitnessEquipmentController : ControllerBase
    {
        private readonly FitnessEquipmentService _fitnessEquipmentService;

        public FitnessEquipmentController(FitnessEquipmentService fitnessEquipmentService)
        {
            _fitnessEquipmentService = fitnessEquipmentService;
        }

        // Fetch items by supplier
        [HttpGet("by-supplier/{supplierName}")]
        public async Task<IActionResult> GetItemsBySupplier(string supplierName)
        {
            var items = await _fitnessEquipmentService.GetFitnessEquipmentsAsync(null, null, supplierName);
            if (items == null || items.Count == 0)
            {
                return NotFound($"No items found for supplier '{supplierName}'.");
            }
            return Ok(items);
        }

        // Fetch items by category
        [HttpGet("by-category/{categoryName}")]
        public async Task<IActionResult> GetItemsByCategory(string categoryName)
        {
            var items = await _fitnessEquipmentService.GetFitnessEquipmentsAsync(null, categoryName, null);
            if (items == null || items.Count == 0)
            {
                return NotFound($"No items found for category '{categoryName}'.");
            }
            return Ok(items);
        }

        // Fetch all items with optional filters
        [HttpGet]
        public async Task<IActionResult> GetAllItems([FromQuery] string? searchTerm = null, [FromQuery] string? category = null, [FromQuery] string? supplier = null)
        {
            var items = await _fitnessEquipmentService.GetFitnessEquipmentsAsync(searchTerm, category, supplier);
            return Ok(items);
        }

        // Add a new fitness equipment
        [HttpPost]
        public async Task<IActionResult> AddFitnessEquipment([FromBody] FitnessEquipmentDTO equipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEquipment = await _fitnessEquipmentService.AddFitnessEquipmentAsync(equipmentDto);
            return CreatedAtAction(nameof(GetAllItems), new { id = newEquipment.Id }, newEquipment);
        }

        // Update fitness equipment
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFitnessEquipment(int id, [FromBody] FitnessEquipmentDTO equipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedEquipment = await _fitnessEquipmentService.UpdateFitnessEquipmentAsync(id, equipmentDto);
            if (updatedEquipment == null)
            {
                return NotFound($"No equipment found with ID {id}.");
            }

            return Ok(updatedEquipment);
        }

        // Delete fitness equipment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessEquipment(int id)
        {
            var result = await _fitnessEquipmentService.DeleteFitnessEquipmentAsync(id);
            if (!result)
            {
                return NotFound($"No equipment found with ID {id}.");
            }

            return NoContent();
        }
    }
}
