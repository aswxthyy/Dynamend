using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dynamend.Desktop.Commands;

namespace Dynamend.Desktop.ViewModels
{
    internal class NewReportViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
       
        public NewReportViewModel()
        {

            Command = new CustomCommand(execute, canExecute);
        }
            private bool canExecute()
            {
                return true;
            }

            private void execute()
            {
                Kms = string.Empty;
            }

            private string _name;
            private string _license;
            private string _model;
            private string _kms;
            private double _cost;
            private double _totalCost;
            private string _KmsError;

            public string Name
            {
                get => _name;
                set
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
            public string License
            {
                get => _license;
                set
                {
                    _license = value;
                    OnPropertyChanged();
                }
            }

            public string Model
            {
                get => _model;
                set
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
            public double Cost
            {
                get => _cost;
                set
                {
                    _cost = value;
                    OnPropertyChanged();
                }
            }
            public double TotalCost
            {
                get => _totalCost;
                set
                {
                    _totalCost = value;
                    OnPropertyChanged();
                }
            }
            public string Kms
            {
                get => _kms;
                set
                {
                    _kms = value;
                    OnPropertyChanged(nameof(Kms));
                    OnPropertyChanged(nameof(KmsError));
                }
            }
            public string KmsError
            {
                get => this[nameof(Kms)];
            }

            public CustomCommand Command { get; set; }
            public string this[string columnName]
            {
                get
                {
                    if (columnName == nameof(Kms))
                    {
                        if (string.IsNullOrWhiteSpace(Kms))
                        {
                            return "Distance cannot be empty";
                        }
                        if (!double.TryParse(Kms, out double result))
                        {
                            return "Please enter a valid double value";
                        }
                        if (result < 0)
                        {
                            return "Negative values are not allowed";
                        }
                    }
                    return null;
                }
            }
            public string Error => null;

            public event PropertyChangedEventHandler PropertyChanged;
            public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }
}

