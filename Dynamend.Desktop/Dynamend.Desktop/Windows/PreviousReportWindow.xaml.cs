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
using Dynamend.Desktop.ViewModels;

namespace Dynamend.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for PreviousReportWindow.xaml
    /// </summary>
    public partial class PreviousReportWindow : Window
    {
        private readonly PreviousReportPageViewModel _viewModel;
        
        public PreviousReportWindow( string license)
        {
            InitializeComponent();
            //SelectedName = data;
            SelectedLicense = license;
            _viewModel = new PreviousReportPageViewModel(SelectedLicense);
            DataContext = _viewModel;
        }

        public string SelectedName { get;  set; }
        public string SelectedLicense { get; set; }

        private void BtnNewReport_Click(object sender, RoutedEventArgs e)
        {
            new NewReportWindow(SelectedLicense).Show();
        }
    }
}
