using Sramski.MusicShop.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Sramski.MusicShop
{
    public partial class ProductEditWindow : Window
    {
        public ProductEditWindow(Product product)
        {
            this.DataContext = product;
            InitializeComponent();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
