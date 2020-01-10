using StockProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockProject.DAL;
using System.Windows.Input;

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
                OnPropertyChange("Stock");
            }
        }
        private Stock selectedStock;

        public Stock SelectedStock
        {
            get { return selectedStock; }
            set
            {
                selectedStock = value;
                DeleteComand.productID = value.Id;
                UpdateNBRComand.StockID = value.Id;

                OnPropertyChange("SelectedStock");
            }
        }


        private Stock loadedStocks;

        public Stock LoadedStock 
        {
            get { return loadedStocks; }
            set
            {
                loadedStocks = value;

                OnPropertyChange("LoadedStock");
            }
        }


        //Prendre les valeurs des champs pour ajouter un produit
        private static string bookName;
        public static string BookName
        {
            get { return bookName; }
            set
            {
                bookName = value;
            }
        }

        private static string codeBarre;
        public static string CodeBarre
        {
            get { return codeBarre; }
            set
            {
                codeBarre = value;
            }
        }

        private static string description;
        public static string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }

        private static string prix;
        public static string Prix
        {
            get { return prix; }
            set
            {
                prix = value;
            }
        }

        private static string nbrstock;
        public static string nbrStock
        {
            get { return nbrstock; }
            set
            {
                nbrstock = value;
            }
        }


        



        //public static int toto = 0;

        //public static void ChangeCreate()
        //{
        //    OnPropertyChange("CREATE");
        //}






        //Bouton pour ajouter un produit
        private ICommand add;

        public ICommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new AddComand();
                }
                return add;
            }
            set { add = value; }
        }

        


        public class AddComand : ICommand
        {
            //public static string eventCreate = "non";

            public event EventHandler CanExecuteChanged;

            //public static void CreateChange()
            //{
            //    eventCreate = "oui";
            //}

            

            public bool CanExecute(object parameter)
            {
                //toto += 1;
                return true;
            }

            public void Execute(object parameter)
            {
                DAL.StockAPIDAL.CreatStock();
                //CreateChange();
                //ChangeCreate();
            }
        }



        private ICommand delete;

        public ICommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new DeleteComand();
                    
                }
                return delete;
            }
            set { delete = value; }
        }


        public class DeleteComand : ICommand
        {
            public static string productID;

            public event EventHandler CanExecuteChanged;

            
            public bool CanExecute(object parameter)
            {
                //toto = 1;
                return true;
            }

            public void Execute(object parameter)
            {
                //toto += 1;
                DAL.StockAPIDAL.DeleteStock(productID);
                //OnPropertyChange("Delete");
                
            }
        }



        private ICommand nextOptions;

        public ICommand NextOptions
        {
            get
            {
                if (nextOptions == null)
                {
                    nextOptions = new NextOptionsComand();
                }
                return nextOptions;
            }
            set { nextOptions = value; }
        } 

        class NextOptionsComand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                Info i = new Info((Stock)parameter);
                i.Show();
            }
        }



        private ICommand moreStock;

        public ICommand MoreStock
        {
            get
            {
                if (moreStock == null)
                {
                    moreStock = new MoreStockComand();
                }
                return moreStock;
            }
            set { moreStock = value; }
        }


        public class MoreStockComand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true; 
            }

            public void Execute(object parameter)
            {
                
            }
        }



        private ICommand lessStock;

        public ICommand LessStock
        {
            get
            {
                if (lessStock == null)
                {
                    lessStock = new LessStockComand();
                }
                return lessStock;
            }
            set { lessStock = value; }
        }


        public class LessStockComand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            { 
                return true;
            }

            public void Execute(object parameter)
            {

            }
        }



        private ICommand updateNBR;

        public ICommand UpdateNBR
        {
            get
            {
                if (updateNBR == null)
                {
                    updateNBR = new UpdateNBRComand();
                }
                return updateNBR;
            }
            set { updateNBR = value; }
        }

         
        public class UpdateNBRComand : ICommand
        {
            public static string StockID;
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                //DAL.StockAPIDAL.UpdateNBR(StockID); 
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if (propertyName != "Stock")
                {
                    if (propertyName == "SelectedStock" /*&& AddComand.eventCreate == "oui" || propertyName == "YOYO"*/ /*|| toto == 1*/)
                    {
                        //LoadStock();
                        
                        //AddComand.eventCreate = "non";
                        //toto = 0;
                    }

                }
            }
        }
    }
}

