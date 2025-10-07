using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategoryList;

        public ProductCategoryRepository()
        {
            productCategoryList = [
                new ProductCategory(1, "Melk", 1, 1),
                new ProductCategory(2, "Kaas", 2, 1),
                new ProductCategory(3, "Brood", 3 ,2),
                new ProductCategory(4, "Cornflakes", 4, 3)
            ];
        }

        public List<ProductCategory> GetAll()
        {
            return productCategoryList;
        }
    }
}
