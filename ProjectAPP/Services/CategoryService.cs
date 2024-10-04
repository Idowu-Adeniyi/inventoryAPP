using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectAPP.Data;
using ProjectAPP.DTOs;
using ProjectAPP.Models;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .Select(c => new CategoryDto { CategoryId = c.CategoryId, CategoryName = c.CategoryName })
            .ToListAsync();
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return null;
        return new CategoryDto { CategoryId = category.CategoryId, CategoryName = category.CategoryName };
    }

    public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
    {
        var category = new Category { CategoryName = categoryDto.CategoryName };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        categoryDto.CategoryId = category.CategoryId;
        return categoryDto;
    }

    public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return null;

        category.CategoryName = categoryDto.CategoryName;
        await _context.SaveChangesAsync();

        return categoryDto;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}
