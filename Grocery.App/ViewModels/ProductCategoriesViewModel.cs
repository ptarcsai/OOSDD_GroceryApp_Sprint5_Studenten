using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;


namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<ProductCategory> ProductCategories { get; } = new();
        public ObservableCollection<Product> AvailableProducts { get; } = new();

        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private string searchText = "";

        [ObservableProperty]
        private Category category;
        [ObservableProperty]
        string myMessage;
        partial void OnCategoryChanged(Category value)
        {
            Title = value.Name;
            Load(value.Id);
        }

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        private void Load(int categoryId)
        {
            ProductCategories.Clear();

            var list = _productCategoryService.GetAllByCategoryId(categoryId);
            foreach (var pc in list) ProductCategories.Add(pc);

            GetAvailableProducts();
        }

        private void GetAvailableProducts()
        {
            AvailableProducts.Clear();

            var links = _productCategoryService.GetAll();
            var linkedProductIds = new HashSet<int>();
            for (int i = 0; i < links.Count; i++)
                linkedProductIds.Add(links[i].ProductId);
            GetCategorilessProducts(linkedProductIds);
        }

        private void GetCategorilessProducts(HashSet<int> linkedProductIds)
        {
            foreach (var p in _productService.GetAll())
            {
                if (linkedProductIds.Contains(p.Id)) continue;

                if (string.IsNullOrWhiteSpace(searchText))
                    AvailableProducts.Add(p);
                else
                {
                    var name = p.Name ?? string.Empty;
                    if (name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        AvailableProducts.Add(p);
                }
            }
        }

        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText ?? "";
            GetAvailableProducts();
        }

        [RelayCommand]
        public void AddProduct(Product product)
        {
            if (product == null || Category == null) return;

            var link = new ProductCategory(0, product.Name, product.Id, Category.Id);
            _productCategoryService.Add(link);

            AvailableProducts.Remove(product);
            ProductCategories.Add(link);
        }
    }
}
