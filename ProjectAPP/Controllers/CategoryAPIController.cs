using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAPP.DTOs;
using ProjectAPP.Interfaces;

namespace ProjectAPP.Controllers
{

    /// <summary>
    /// API Controller for handling HTTP requests related to Category operations.
    /// Exposes API endpoints to interact with categories in the system.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private readonly ICategoryService _categoryService;  // Private field to hold the service that handles category operations.

        /// <summary>
        /// Constructor that injects the CategoryService into the controller. The service will handle the actual logic for categories.
        /// </summary>
        /// <param name="categoryService">An instance of ICategoryService injected via Dependency Injection (DI).</param>

        public CategoryAPIController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// HTTP GET: api/CategoryAPI
        /// Retrieves all the categories from the system.
        /// </summary>
        /// <returns>A list of CategoryDto objects.</returns>

        [HttpGet]  // Maps this method to a GET request at: api/CategoryAPI
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        /// <summary>
        /// HTTP POST: api/CategoryAPI
        /// Creates a new category in the system.
        /// </summary>
        /// <param name="categoryDto">The CategoryDto object containing the details of the new category.</param>
        /// <returns>The newly created CategoryDto object with a 201 Created status and the URI of the new category.</returns>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto categoryDto)
        {
            var newCategory = await _categoryService.AddCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetCategory), new { id = newCategory.CategoryId }, newCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.CategoryId) return BadRequest();
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, categoryDto);
            if (updatedCategory == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")] // Maps this method to a DELETE request at: api/CategoryAPI/{id}
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
