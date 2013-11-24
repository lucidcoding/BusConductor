using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusConductor.Admin.UI.ViewModels.Shared;
using BusConductor.Domain.Common;

namespace BusConductor.Admin.UI.Views.Shared
{
    /// <summary>
    /// Interaction logic for ValidationDialog.xaml
    /// </summary>
    public partial class ValidationDialog : Window
    {
        public ValidationDialog(ValidationMessageCollection validationMessages)
        {
            InitializeComponent();

            var validationViewModel = new ValidationViewModel();
            validationViewModel.Messages = new ObservableCollection<string>();

            foreach(var validationMessage in validationMessages)
            {
                validationViewModel.Messages.Add(validationMessage.Text);
            }

            DataContext = validationViewModel;
        }
    }
}
