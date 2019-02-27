using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Sramski.Interfaces;
using Sramski.BL;

namespace Sramski.MusicShop.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected Base Logic;
        protected IDAO Data;

        public ViewModel()
        {
            LoadBusinessLogic();
            LoadDataObject();
        }

        void LoadBusinessLogic()
        {
            Logic = Base.GetInstance();
        }

        void LoadDataObject()
        {
            Data = Logic.GetDataObject();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
