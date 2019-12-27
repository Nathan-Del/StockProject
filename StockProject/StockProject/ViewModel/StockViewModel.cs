using StockProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockProject.DAL;

namespace StockProject.ViewModel
{
    class StockViewModel : INotifyPropertyChanged
    {
        private List<Stock> stocks; 
        public StockViewModel() 
        {
            LoadStock();
        }

        private async void LoadStock() 
        {
            Stock = await DAL.StockAPIDAL.LoadStock();
        }
         
        public List<Stock> Stock 
        {
            get { return stocks; }
            set
            {
                stocks = value;
                OnPropertyChange("Stocks");
            }
        }
        private Stock selectedStock;

        public Stock SelectedStock
        {
            get { return selectedStock; }
            set
            {
                selectedStock = value;

                OnPropertyChange("SelectedStock");

            }
        }

        private Stock loadedStocks;

        public Stock LoadedPokemon
        {
            get { return loadedStocks; }
            set
            {
                loadedStocks = value;

                OnPropertyChange("LoadedStock");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

