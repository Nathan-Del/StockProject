using StockProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProject.ViewModel
{
    class InfoViewModel
    {
        private Stock currentStock;
        
        public Stock CurrentStock 
        {
            get { return currentStock; }
            set { currentStock = value; }
        }


        private List<Stock> stocks; 

        public event PropertyChangedEventHandler PropertyChanged;

        public InfoViewModel(Stock s)
        {
            CurrentStock = s;
        }
    }
}
