using FindIt.Data;
using FindIt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FindIt.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Dictionary<string, Dictionary<int, string>> GetCategories()
        {
            List<CategoryModel> categories = _context.Categories.ToList();
            Dictionary<string, Dictionary<int,  string>> categoryMap = [];

            foreach (CategoryModel category in categories)
            {
                if (category.ParentId == 0) {
                    categoryMap[category.Name] = new Dictionary<int, string>();
                } else {
                    // Find parent category
                    CategoryModel? parentCategory = categories.FirstOrDefault(c => c.Id == category.ParentId);

                    if (parentCategory != null) {
                        categoryMap[parentCategory.Name].Add(category.Id, category.Name);
                    }
                }
            }
            
            return categoryMap;
        }
    }
}