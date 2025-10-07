using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public List<ProductCategory> GetAllByCategoryId(int categoryId)
        {
            var all = _productCategoryRepository.GetAll();
            var result = new List<ProductCategory>();

            foreach (var pc in all)
            {
                if (pc.CategoryId == categoryId)
                    result.Add(pc);
            }

            return result;
        }
    }
}
