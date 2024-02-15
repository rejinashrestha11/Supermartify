namespace CRUD_dotnetProject.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category {CategoryId = 1, CategoryName = "Beverage", Description = "Consumable liquid, from water to alcoholic drinks" },
            new Category {CategoryId = 2, CategoryName = "Bakery", Description = "Baked goods from flour, sugar, and diverse ingredients" },
            new Category {CategoryId = 3, CategoryName = "Meat", Description = "Consumable animal flesh" }
        };

        public static void AddCategory(Category category)
        {
            if (!_categories.Any())
            {
                // If the collection is empty, set the initial value for CategoryId
                category.CategoryId = 1; // You can use any starting value you prefer
            }
            else
            {
                var maxId = _categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }

            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                };
            }
            return null;
        }

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = category.CategoryName;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
