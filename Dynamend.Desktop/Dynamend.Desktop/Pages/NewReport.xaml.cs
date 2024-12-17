using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
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
using Dynamend.Desktop.Commands;

namespace Dynamend.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for NewReport.xaml
    /// </summary>
    public partial class NewReport : Page
    {
        public NewReport()
        {
            InitializeComponent();
           
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Report Generated");
        }
    }
}
