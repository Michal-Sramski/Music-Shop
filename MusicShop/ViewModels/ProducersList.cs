using System;
using System.Collections.ObjectModel;
using Sramski.Interfaces;

namespace Sramski.MusicShop.ViewModels
{
    class ProducersList : ViewModel
    {
        private ObservableCollection<Producer> _producers;
        private Producer _selectedProducer;
    
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _addCommand;

        public ProducersList() : base()
        {
            LoadProducers();
            InitCommands();
        }

        void LoadProducers()
        {
            Producers = new ObservableCollection<Producer>();
            foreach(IProducer producer in Data.GetProducers())
            {
                Producers.Add(CreateChildProducerViewModel(producer));
            }
        }

        public void AddProducer(Producer producer)
        {
            if(!Producers.Contains(producer))
            {
                Producers.Add(producer);
            }
        }

        public void ReloadProducers()
        {
            foreach (Producer producer in Producers)
            {
                producer.ReloadProducer();
            }
        }

        void InitCommands()
        {
            _editCommand = new RelayCommand(new Action<object>(this.EditCommandExecute), new Predicate<object>(this.IsProducerSelected));
            _deleteCommand = new RelayCommand(new Action<object>(this.DeleteCommandExecute), new Predicate<object>(this.IsProducerSelected));
            _addCommand = new RelayCommand(new Action<object>(this.AddCommandExecute));
        }

        Producer CreateChildProducerViewModel(IProducer producer)
        {
            Producer p = new Producer(producer);
            p.ParentViewModel = this;
            return p;
        }

        private void EditCommandExecute(object o)
        {
            Producer producer = CreateChildProducerViewModel(SelectedProducer.ProducerObject);
            ProducerEditWindow window = new ProducerEditWindow(producer);
            window.Show();
        }

        private void DeleteCommandExecute(object o)
        {
            Data.DeleteProducer(SelectedProducer.ProducerObject);
            Producers.Remove(SelectedProducer);
        }

        private void AddCommandExecute(object o)
        {
            Producer producer = CreateChildProducerViewModel(Data.CreateProducer());
            producer.IsNew = true;
            ProducerEditWindow window = new ProducerEditWindow(producer);
            window.Show();
        }

        private bool IsProducerSelected(object o)
        {
            return (SelectedProducer != null);
        }

        public ObservableCollection<Producer> Producers
        {
            get => _producers;
            set
            {
                _producers = value;
                OnPropertyChanged(nameof(Producers));
            }
        }

        public Producer SelectedProducer
        {
            get
            {
                return _selectedProducer;
            }
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
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
