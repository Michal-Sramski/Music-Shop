using System;
using System.Collections.Generic;
using Sramski.Interfaces;

namespace Sramski.MusicShop.ViewModels
{
    public class Product : ViewModel
    {
        private IProduct _product;
        private IProduct _originalProduct;
        private RelayCommand _saveCommand;
        public bool IsNew = false;
        private List<IProducer> _producers;

        public Product(IProduct product)
        {
            _originalProduct = product;
            _product = product.Clone() as IProduct;
            _producers = new List<IProducer>();
            InitCommands();
            LoadProducers();
        }

        void LoadProducers()
        {
            foreach(IProducer producer in Data.GetProducers())
            {
                _producers.Add(producer);
            }
        }

        public void ReloadProduct()
        {
            Name = _originalProduct.Name;
        }

        void InitCommands()
        {
            _saveCommand = new RelayCommand(new Action<object>(this.SaveCommandExecute), new Predicate<object>(this.IsProductValid));
        }

        private void SaveCommandExecute(object o)
        {
            _originalProduct.OverwriteValues(_product);
            Data.SaveProduct(_originalProduct);
            if (IsNew)
            {
                (ParentViewModel as ProductsList).AddProduct(this);
            }
            (ParentViewModel as ProductsList).ReloadProducts();
        }

        private bool IsProductValid(object o)
        {
            return (Name != null && Name.Length > 0 && Price > 0);
        }

        public IProduct ProductObject
        {
            get => _originalProduct;
        }

        public int Id
        {
            get => _product.Id;
        }

        public string Name
        {
            get => _product.Name;
            set
            {
                _product.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public IProducer Producer
        {
            get => _product.Producer;
            set
            {
                _product.Producer = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public double Price
        {
            get => _product.Price;
            set
            {
                _product.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public bool Promotion
        {
            get => _product.Promotion;
            set
            {
                _product.Promotion = value;
                OnPropertyChanged(nameof(Promotion));
            }
        }

        public List<IProducer> Producers
        {
            get => _producers;
        }

        public RelayCommand SaveCommand
        {
            get => _saveCommand;
        }

        public ViewModel ParentViewModel { get; set; }
    }
}
