using Sramski.MusicShop.ViewModels;
using System.Windows;

namespace Sramski.MusicShop
{
    public partial class ProducersWindow : Window
    {
        public ProducersWindow()
        {
            this.DataContext = new ProducersList();
            InitializeComponent();
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
