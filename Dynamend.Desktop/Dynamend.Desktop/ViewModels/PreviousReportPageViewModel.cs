using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dynamend.Desktop.Models;
using Dynamend.Desktop.Pages;

namespace Dynamend.Desktop.ViewModels
{
    internal class PreviousReportPageViewModel : INotifyPropertyChanged
    {
        public PreviousReportPageViewModel()
        {
            ServiceReports = new ObservableCollection<ServiceReport>();
        }

      
      
        public ObservableCollection<ServiceReport> ServiceReports { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
