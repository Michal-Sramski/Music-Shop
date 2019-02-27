using Sramski.MusicShop.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Sramski.MusicShop
{
    public partial class ProducerEditWindow : Window
    {
        public ProducerEditWindow(Producer producer)
        {
            this.DataContext = producer;
            InitializeComponent();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
