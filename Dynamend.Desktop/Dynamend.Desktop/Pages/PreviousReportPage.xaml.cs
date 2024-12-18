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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dynamend.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for PreviousReportPage.xaml
    /// </summary>
    public partial class PreviousReportPage : Page
    {
        public PreviousReportPage()
        {
            InitializeComponent();
        }

        private void BtnNewReport_Click(object sender, RoutedEventArgs e)
        {
            var p = (NavigationWindow)this.Parent;
            p.Navigate(new Pages.NewReport());
        }
    }
}
