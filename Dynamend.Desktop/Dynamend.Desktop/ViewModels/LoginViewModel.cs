﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dynamend.Desktop.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged();
                ValidateName();
            }
        }

        private string _license;

        public string License
        {
            get { return _license; }
            set 
            { 
                _license = value;
                OnPropertyChanged();
                ValidateLicense();
            }
        }
        private void ValidateName()
        {
            var nameValidationErrors = new List<string>();
            if (string.IsNullOrWhiteSpace(Name))
                nameValidationErrors.Add("Name should not be empty.");
            if (Name.Length < 3)
                nameValidationErrors.Add("Name too short.");
            if (Name.Length > 25)
                nameValidationErrors.Add("Name too long.");

            if (nameValidationErrors.Any())
                _errors[nameof(Name)] = nameValidationErrors;
            else
                _errors.Remove(nameof(Name));

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Name)));
        }

        private void ValidateLicense()
        {
            var licenseValidationErrors = new List<string>();
            if (string.IsNullOrWhiteSpace(License))
                licenseValidationErrors.Add("License Number should not be empty.");
            if (License.Length < 6)
                licenseValidationErrors.Add("License Number too short.");
            if (License.Length > 15)
                licenseValidationErrors.Add("License Number too long.");

            if (licenseValidationErrors.Any())
                _errors[nameof(License)] = licenseValidationErrors;
            else
                _errors.Remove(nameof(License));

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(License)));
        }


        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }
    }
}
