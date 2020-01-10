using StockProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockProject.ViewModel
{
    class InfoViewModel : INotifyPropertyChanged
    {
        private static Stock currentStock;

        public static Stock CurrentStock
        {
            get { return currentStock; }
            set {
                currentStock = value;
                UpdateComand.UpdateID = value.Id;
            }
        }


        private Stock stocks;

        public event PropertyChangedEventHandler PropertyChanged;

        public InfoViewModel(Stock s)
        {
            CurrentStock = s;
        }


        private ICommand update;

        public ICommand Update
        {
            get
            {
                if (update == null)
                {
                    update = new UpdateComand();
                }
                return update;
            }
            set { update = value; }
        }

        public class UpdateComand : ICommand
        { 
            public static string UpdateID;

            public event EventHandler CanExecuteChanged;


            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                DAL.StockAPIDAL.UpdateStock(UpdateID);
            }
        }
    }
}
