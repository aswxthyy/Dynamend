using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dynamend.Desktop.Models;
using Dynamend.Desktop.Pages;
using Dynamend.Desktop.Repositories;

namespace Dynamend.Desktop.ViewModels
{
    internal class PreviousReportPageViewModel : INotifyPropertyChanged
    {
        private readonly Repository _repository;
        private Customer _searchResultCustomer;

        public Customer SearchResultCustomer
        {
            get { return _searchResultCustomer; }
            set 
            { 
                _searchResultCustomer = value;
                OnPropertyChanged();
            }
        }


        private string _resultCustomerName;

        public string ResultCustomerName
        {
            get { return _resultCustomerName; }
            set 
            {
                _resultCustomerName = value;
                OnPropertyChanged();
            }
        }
        private string _resultCustomerLicense;

        public string ResultCustomerLicense
        {
            get { return _resultCustomerLicense; }
            set
            {
                _resultCustomerLicense = value;
                OnPropertyChanged();
            }
        }
        private string _resultCustomerModel;

        public string ResultCustomerModel

        {
            get { return _resultCustomerModel; }
            set 
            {
                _resultCustomerModel = value;
                OnPropertyChanged();
            }
        }
        private string _selectedCustomerLicense;

        public string SelectedCustomerLicense
        {
            get { return _selectedCustomerLicense; }
            set 
            {
                _selectedCustomerLicense = value;
                OnPropertyChanged();
                UpdateServiceRreport();
            }
        }


        public PreviousReportPageViewModel(string selectedCustomerLicense)
        {
            _repository = new Repository();
            ServiceReportsToDisplay = new ObservableCollection<ServiceReport>();
            //SelectedCustomerName = selectedCustomerName;
            SelectedCustomerLicense = selectedCustomerLicense; 
        }
            

        public ObservableCollection<ServiceReport> ServiceReportsToDisplay { get; set; }

        private string _selectedCustomerName;

        public string SelectedCustomerName
        {
            get { return _selectedCustomerName; }
            set 
            {
                _selectedCustomerName = value;
               // UpdateServiceRreport();
                OnPropertyChanged();
            }
        }
        
        private void UpdateServiceRreport()
        {
            ServiceReportsToDisplay.Clear();
            if (SelectedCustomerLicense != null)
            {
                
                SearchResultCustomer = _repository.GetCustomerByLicense(SelectedCustomerLicense);
                ResultCustomerName = SearchResultCustomer.Name;
                ResultCustomerLicense = SearchResultCustomer.LicenseNumber;
                ResultCustomerModel = SearchResultCustomer.VehicleModelName;
                var reports = _repository.GetServiceReport(ResultCustomerName);
                ServiceReportsToDisplay.Add(reports);
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
