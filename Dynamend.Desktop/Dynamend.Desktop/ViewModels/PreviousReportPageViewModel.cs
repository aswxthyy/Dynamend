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
using Dynamend.Desktop.Repositories;

namespace Dynamend.Desktop.ViewModels
{
    internal class PreviousReportPageViewModel : INotifyPropertyChanged
    {
        private readonly Repository _repository;
        private readonly List<ServiceReport> _reports;
        public PreviousReportPageViewModel()
        {
            ServiceReportsToDisplay = new ObservableCollection<ServiceReport>();
            _repository = new Repository();
        }
        
        public ObservableCollection<ServiceReport> ServiceReportsToDisplay { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
