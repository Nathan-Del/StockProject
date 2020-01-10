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


        //Livre en cour de modification
        private static Stock currentStock;

        public static Stock CurrentStock
        {
            get { return currentStock; }
            set {
                currentStock = value;
                //Pour récupérer l'id du produit en modification
                UpdateComand.UpdateID = value.Id;
            }
        }


        private Stock stocks;

        public event PropertyChangedEventHandler PropertyChanged;

        public InfoViewModel(Stock s)
        {
            CurrentStock = s;
        }




        
        //Options pour AUGMENTER le stock avec bounton
        private ICommand more;

        public ICommand More
        {
            get
            {
                if (more == null)
                {
                    more = new MoreComand();
                }
                return more;
            }
            set { more = value; }
        }

        public class MoreComand : ICommand
        {
            public static string UpdateID;

            public event EventHandler CanExecuteChanged;


            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                CurrentStock.nbrStock += 1;
            }
        }


        //Options pour DIMINUER le stock avec bounton
        private ICommand less;

        public ICommand Less
        {
            get
            {
                if (less == null)
                {
                    less = new LessComand();
                }
                return less;
            }
            set { less = value; }
        }

        public class LessComand : ICommand
        {
            public static string UpdateID;

            public event EventHandler CanExecuteChanged;


            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                CurrentStock.nbrStock -= 1;
            }
        }





        //Bouton pour Modifier les valeurs d'un produit
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
