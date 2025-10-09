﻿using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly List<Category> categoryList;

        public CategoryRepository()
        {
            categoryList = [
                new Category(1, "Zuivel"),
                new Category(2, "Bakkerij"),
                new Category(3, "Ontbijt"),
            ];
        }

        public List<Category> GetAll()
        {
            return categoryList;
        }
    }
}
