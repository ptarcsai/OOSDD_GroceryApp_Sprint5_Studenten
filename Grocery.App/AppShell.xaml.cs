using Grocery.App.Views;
using System.Globalization;

namespace Grocery.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("nl-NL");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("nl-NL");

            InitializeComponent();
            Routing.RegisterRoute(nameof(GroceryListItemsView), typeof(GroceryListItemsView));
            Routing.RegisterRoute(nameof(ProductView), typeof(ProductView));
            Routing.RegisterRoute(nameof(ChangeColorView), typeof(ChangeColorView));
            Routing.RegisterRoute("Login", typeof(LoginView));
            Routing.RegisterRoute(nameof(BestSellingProductsView), typeof(BestSellingProductsView));
            Routing.RegisterRoute(nameof(BoughtProductsView), typeof(BoughtProductsView));
        }
    }
}
