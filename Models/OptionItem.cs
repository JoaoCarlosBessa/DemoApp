using DemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class OptionItem : BaseViewModel
    {
        public string ImageSource { get; set; }
        public string LabelText { get; set; }
        public int Position { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }

        }
    }
}
