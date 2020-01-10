using StockProject.Models;
using StockProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StockProject
{
    /// <summary>
    /// Logique d'interaction pour Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        private readonly InfoViewModel _viewModel;
        public Info(Stock s)
        {
            InitializeComponent();
            _viewModel = new InfoViewModel(s);
            DataContext = _viewModel;
        }
    }
}
