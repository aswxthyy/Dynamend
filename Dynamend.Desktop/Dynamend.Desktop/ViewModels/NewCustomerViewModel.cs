using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using Dynamend.Desktop.Repositories;
using System.Windows;
using Dynamend.Desktop.Models;
using Dynamend.Desktop.Commands;


namespace Dynamend.Desktop.ViewModels
{
    internal class NewCustomerViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Repository _repository;
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public RelayCommands RegisterCommand { get;}

        public NewCustomerViewModel()
        {
            _repository = new Repository();
            RegisterCommand = new RelayCommands(SaveCustomer);
        }

        private void SaveCustomer()
        {
            if (HasErrors)
            {
              MessageBox.Show("Please fix the validation errors","Validation Error",MessageBoxButton.OK, MessageBoxImage.Error);
              return;
            }
                var newCustomer = new Customer
                {
                    Name = this.Name,
                    ContactNumber = this.Phone,
                    Address = this.Address,
                    LicenseNumber = this.License,
                    VehicleModelName = this.Model,
                };
            _repository.AddCustomer(newCustomer);
            MessageBox.Show("Customer Added Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Refresh();
        }

        private string _name;

        [Required]
        [MinLength(5)]
       
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
                Validate();
            }
        }

        private string _phone;
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Phone
        {
            get { return _phone; }
            set 
            {
                _phone = value;
                OnPropertyChanged();
                Validate();
            }
        }

        private string _address;
        [Required]
        [MinLength(10)]
        public string Address
        {
            get { return _address; }
            set 
            {
                _address = value;
                OnPropertyChanged();
                Validate();
            }
        }



        private string _license;
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string License
        {
            get { return _license; }
            set
            {
                _license = value;
                OnPropertyChanged();
                Validate();
            }
        }

        private string _model;
        [Required]
        public string Model
        {
            get { return _model; }
            set 
            {
                _model = value;
                OnPropertyChanged();
                Validate();
            }
        }

        private void Validate([CallerMemberName] string propertyName = null)
        {
            var context = new ValidationContext(this) { MemberName = propertyName };
            var result = new List<ValidationResult>();

            var value = this.GetType().GetProperty(propertyName).GetValue(this);
            var isValid = Validator.TryValidateProperty(value, context, result);

            if (!isValid)
            {
                _errors[propertyName] = result.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }
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
       public void Refresh()
       {
            Name = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
            License = string.Empty;
            Model = string.Empty;
       }
    }
}
