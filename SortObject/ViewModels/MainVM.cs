using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace SortObject.ViewModels
{
    internal class MainVM : INotifyPropertyChanged
    {
        private string _inputData;
        private StackPanel _typeSort;
        private string _outputData;

        // properties for input data
        public string InputData
        {
            get => _inputData;
            set
            {
                _inputData = value;
                OnPropertyChanged();
            }
        }
        // properties for type sort
        public StackPanel TypeSort
        {
            get => _typeSort;
            set
            {
                _typeSort = value;
                OnPropertyChanged();
            }
        }
        // properties for output data
        public string OutputData
        {
            get => _outputData;
            set
            {
                _outputData = value;
                OnPropertyChanged();
            }
        }


        // command for activate algorithm sort
        public ICommand ClickSort
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    Models.OrderObjects orderObjects = new Models.OrderObjects();
                    OutputData = orderObjects.Sort(InputData, Models.ConvertTypeSort.ConvertTypeSortToString(TypeSort));
                });
            }
        }

        public ICommand ExitApp
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    (obj as Window).Close();
                });
            }
        }
        public ICommand HiddenApp
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    (obj as Window).WindowState = WindowState.Minimized;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
