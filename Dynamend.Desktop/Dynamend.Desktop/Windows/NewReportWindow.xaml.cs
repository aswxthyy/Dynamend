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
    /// Interaction logic for NewReportWindow.xaml
    /// </summary>
    public partial class NewReportWindow : Window
    {
        private readonly NewReportViewModel _viewModel;
        public NewReportWindow(string selectedLicense)
        {
            SelectedLicense = selectedLicense;
            _viewModel = new NewReportViewModel(SelectedLicense);
            DataContext = _viewModel;
            InitializeComponent();
        }

        public string SelectedLicense { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Report Generated");
        }
    }
}
