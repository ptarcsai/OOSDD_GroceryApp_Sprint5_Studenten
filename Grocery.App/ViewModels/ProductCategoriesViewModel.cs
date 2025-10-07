using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;


namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<ProductCategory> ProductCategories { get; } = new();
        private readonly IProductCategoryService _productCategoryService;

        [ObservableProperty]
        private Category category;
        partial void OnCategoryChanged(Category value)
        {
            Title = value.Name;
            Load(value.Id);
        }

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        private void Load(int categoryId)
        {
            ProductCategories.Clear();

            var list = _productCategoryService.GetAllByCategoryId(categoryId);
            foreach (var pc in list) ProductCategories.Add(pc);
        }
    }
}
