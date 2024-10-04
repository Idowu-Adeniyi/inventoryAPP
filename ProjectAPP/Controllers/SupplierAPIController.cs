using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAPP.Interfaces;
using ProjectAPP.DTOs;

namespace ProjectAPP.Controllers
{
    /// <summary>
    /// API Controller responsible for managing supplier-related operations via HTTP requests.
    /// It supports CRUD operations for suppliers.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierAPIController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        /// <summary>
        /// Constructor for the SupplierAPIController. It takes an ISupplierService as a dependency.
        /// </summary>
        public SupplierAPIController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        /// <summary>
        /// HTTP GET: api/SupplierAPI
        /// Retrieves a list of all suppliers from the system.
        /// </summary>
        /// <returns>A list of SupplierDto objects representing all suppliers.</returns>
        // GET: api/SupplierAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        /// <summary>
        /// HTTP GET: api/SupplierAPI/{id}
        /// Retrieves a single supplier by its ID.
        /// </summary>
        /// <param name="id">The ID of the supplier to retrieve.</param>
        // GET: api/SupplierAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }


        /// <summary>
        /// HTTP POST: api/SupplierAPI
        /// Creates a new supplier in the system.
        /// </summary>
        /// <param name="supplierDto">The DTO containing the details of the new supplier to create.</param>
        // POST: api/SupplierAPI
        [HttpPost]
        public async Task<ActionResult<SupplierDto>> PostSupplier(SupplierDto supplierDto)
        {
            var newSupplier = await _supplierService.AddSupplierAsync(supplierDto);
            return CreatedAtAction(nameof(GetSupplier), new { id = newSupplier.SupplierId }, newSupplier);
        }

        /// <summary>
        /// HTTP PUT: api/SupplierAPI/{id}
        /// Updates an existing supplier by its ID.
        /// </summary>
        /// <param name="id">The ID of the supplier to update.</param>
        // PUT: api/SupplierAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, SupplierDto supplierDto)
        {
            if (id != supplierDto.SupplierId) return BadRequest();
            var updatedSupplier = await _supplierService.UpdateSupplierAsync(id, supplierDto);
            if (updatedSupplier == null) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// HTTP DELETE: api/SupplierAPI/{id}
        /// Deletes an existing supplier by its ID.
        /// </summary>
        /// <param name="id">The ID of the supplier to delete.</param>
        // DELETE: api/SupplierAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var result = await _supplierService.DeleteSupplierAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

