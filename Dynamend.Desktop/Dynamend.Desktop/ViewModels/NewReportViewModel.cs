using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Dynamend.Desktop.Commands;

namespace Dynamend.Desktop.ViewModels
{
    internal class NewReportViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
       
        public NewReportViewModel()
        {

            Command = new CustomCommand(ClearAll,CanClearAll);
        }

        private void ClearAll()
        {
            Kms = string.Empty;
            //selectedOption = null;
           
        }

        private bool CanClearAll()
        {
            return !string.IsNullOrEmpty(Kms);
        }

        

        private string _name;
        private string _license;
        private string _model;
        private string _kms;
        private double _cost;
        private double _totalCost;
        private string _KmsError;
        private string engine;
        private string shift;
        private string clutch;
        private string steering;
        private string grille;
        private string doors;
        private string bodypanels;
        private string glass;
        private string exterior;
        private string airbag;
        private string audio;
        private string vent;
        private string interior;
       
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
                ((CustomCommand)Command).RaiseCanExecuteChanged();
            }
            }
      
        public string KmsError
            {
                get => this[nameof(Kms)];
            }
        public string Engine
        {
            get => engine;
            set
            {
                engine = value;
                OnPropertyChanged();
            }
        }
        public string Shift
        {
            get => shift;
            set
            {
                shift = value;
                OnPropertyChanged();
            }
        }
        public string Clutch
        {
            get => clutch;
            set
            {
                clutch = value;
                OnPropertyChanged();
            }
        }
        public string Steering
        {
            get => steering;
            set
            {
                steering = value;
                OnPropertyChanged();
            }
        }
        public string Grille
        {
            get => grille;
            set
            {
                grille = value;
                OnPropertyChanged();
            }
        }
        public string Doors
        {
            get => doors;
            set
            {
                doors = value;
                OnPropertyChanged();
            }
        }
        public string Bodypanels
        {
            get => bodypanels;
            set
            {
                bodypanels = value;
                OnPropertyChanged();
            }
        }
        public string Glass
        {
            get => glass;
            set
            {
                glass = value;
                OnPropertyChanged();
            }
        }
        public string Exterior
        {
            get => exterior;
            set
            {
                exterior = value;
                OnPropertyChanged();
            }
        }
        public string Airbag
        {
            get => airbag;
            set
            {
                airbag = value;
                OnPropertyChanged();
            }
        }
        public string Audio
        {
            get => audio;
            set
            {
                audio = value;
                OnPropertyChanged();
            }
        }
        public string Vent
        {
            get => vent;
            set
            {
                vent = value;
                OnPropertyChanged();
            }
        }
        public string Interior
        {
            get => interior;
            set
            {
                interior = value;
                OnPropertyChanged();
            }
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

