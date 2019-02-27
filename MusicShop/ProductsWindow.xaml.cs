using Sramski.MusicShop.ViewModels;
using System.Windows;

namespace Sramski.MusicShop
{
    public partial class ProductsWindow : Window
    {
        public ProductsWindow()
        {
            this.DataContext = new ProductsList();
            InitializeComponent();
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
