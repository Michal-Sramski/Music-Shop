using System;
using Sramski.Interfaces;

namespace Sramski.MusicShop.ViewModels
{
    public class Producer : ViewModel
    {
        private IProducer _producer;
        private IProducer _originalProducer;
        private RelayCommand _saveCommand;
        public bool IsNew = false;

        public Producer(IProducer producer)
        {
            _originalProducer = producer;
            _producer = producer.Clone() as IProducer;
            InitCommands();
        }

        public void ReloadProducer()
        {
            Name = _originalProducer.Name;
        }

        void InitCommands()
        {
            _saveCommand = new RelayCommand(new Action<object>(this.SaveCommandExecute), new Predicate<object>(this.IsProducerValid));
        }

        private void SaveCommandExecute(object o)
        {
            _originalProducer.OverwriteValues(_producer);
            Data.SaveProducer(_originalProducer);
            if (IsNew)
            {
                (ParentViewModel as ProducersList).AddProducer(this);
            }
            (ParentViewModel as ProducersList).ReloadProducers();
        }

        private bool IsProducerValid(object o)
        {
            return (Name != null && Name.Length > 0);
        }

        public IProducer ProducerObject
        {
            get => _originalProducer;
        }

        public int Id
        {
            get => _producer.Id;
        }

        public string Name
        {
            get => _producer.Name;
            set
            {
                _producer.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public RelayCommand SaveCommand
        {
            get => _saveCommand;
        }

        public ViewModel ParentViewModel { get; set; }
    }
}
