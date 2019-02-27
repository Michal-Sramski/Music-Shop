using System;
using System.Collections.ObjectModel;
using Sramski.Interfaces;

namespace Sramski.MusicShop.ViewModels
{
    class ProductsList : ViewModel
    {
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
    
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;

        public ProductsList() : base()
        {
            LoadProducts();
            InitCommands();
        }

        void LoadProducts()
        {
            Products = new ObservableCollection<Product>();
            foreach(IProduct product in Data.GetProducts())
            {
                Products.Add(CreateChildProductViewModel(product));
            }
        }

        public void AddProduct(Product product)
        {
            if(!Products.Contains(product))
            {
                Products.Add(product);
            }
        }

        public void ReloadProducts()
        {
            foreach (Product product in Products)
            {
                product.ReloadProduct();
            }
        }

        void InitCommands()
        {
            _editCommand = new RelayCommand(new Action<object>(this.EditCommandExecute), new Predicate<object>(this.IsProductSelected));
            _deleteCommand = new RelayCommand(new Action<object>(this.DeleteCommandExecute), new Predicate<object>(this.IsProductSelected));
            _addCommand = new RelayCommand(new Action<object>(this.AddCommandExecute));
        }

        Product CreateChildProductViewModel(IProduct product)
        {
            Product p = new Product(product);
            p.ParentViewModel = this;
            return p;
        }

        private void EditCommandExecute(object o)
        {
            Product product = CreateChildProductViewModel(SelectedProduct.ProductObject);
            ProductEditWindow window = new ProductEditWindow(product);
            window.Show();
        }

        private void DeleteCommandExecute(object o)
        {
            Data.DeleteProduct(SelectedProduct.ProductObject);
            Products.Remove(SelectedProduct);
        }

        private void AddCommandExecute(object o)
        {
            Product product = CreateChildProductViewModel(Data.CreateProduct());
            product.IsNew = true;
            ProductEditWindow window = new ProductEditWindow(product);
            window.Show();
        }

        private bool IsProductSelected(object o)
        {
            return (SelectedProduct != null);
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public RelayCommand EditCommand
        {
            get => _editCommand;
        }
        public RelayCommand DeleteCommand
        {
            get => _deleteCommand;
        }
        public RelayCommand AddCommand
        {
            get => _addCommand;
        }
    }
}
