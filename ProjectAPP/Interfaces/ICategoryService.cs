using ProjectAPP.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(); // Declares an asynchronous method to get a list of all categories. 
    Task<CategoryDto> GetCategoryByIdAsync(int id);  // Declares an asynchronous method to get a specific category by its ID.
    Task<CategoryDto> AddCategoryAsync(CategoryDto category); // Declares an asynchronous method to add a new category.
    Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto category); // Declares an asynchronous method to update an existing category
    Task<bool> DeleteCategoryAsync(int id);  // Declares an asynchronous method to delete a category by its ID.
}
