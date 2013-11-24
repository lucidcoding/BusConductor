using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using BusConductor.Admin.UI.ViewModels.Bus;
using BusConductor.Application.Contracts;
using BusConductor.Application.Requests.Bus;
using BusConductor.Data.Common;
using BusConductor.Domain.RepositoryContracts;
using StructureMap;
using ListViewItemValidation;

namespace BusConductor.Admin.UI.Views.Bus
{
    public partial class Edit : Page
    {
        private IContextProvider _contextProvider;
        private IBusRepository _busRepository;
        private IBusService _busService;

        public Edit(Guid id)
        {
            InitializeComponent();
            _contextProvider = ObjectFactory.GetInstance<IContextProvider>();
            _busRepository = ObjectFactory.GetInstance<IBusRepository>();
            _busService = ObjectFactory.GetInstance<IBusService>();
            InitializeComponent();

            using (_contextProvider)
            {
                var detailsViewModel = new EditViewModel();
                detailsViewModel.PricingPeriods = new ObservableCollection<EditPricingPeriodViewModel>();
                var bus = _busRepository.GetById(id);
                detailsViewModel.Id = bus.Id.Value;
                detailsViewModel.Name = bus.Name;
                detailsViewModel.Description = bus.Description;
                detailsViewModel.Overview = bus.Overview;
                detailsViewModel.Details = bus.Details;
                detailsViewModel.DriveSide = bus.DriveSide;
                detailsViewModel.Berth = bus.Berth;
                detailsViewModel.Year = bus.Year;

                foreach(var pricingPeriod in bus.PricingPeriods)
                {
                    var editPricingPeriodViewModel = new EditPricingPeriodViewModel();
                    editPricingPeriodViewModel.Id = pricingPeriod.Id.Value;
                    editPricingPeriodViewModel.StartMonth = pricingPeriod.StartMonth;
                    editPricingPeriodViewModel.StartDay = pricingPeriod.StartDay;
                    editPricingPeriodViewModel.EndMonth = pricingPeriod.EndMonth;
                    editPricingPeriodViewModel.EndDay = pricingPeriod.EndDay;
                    editPricingPeriodViewModel.FridayToFridayRate = pricingPeriod.FridayToFridayRate;
                    editPricingPeriodViewModel.FridayToMondayRate = pricingPeriod.FridayToMondayRate;
                    editPricingPeriodViewModel.MondayToFridayRate = pricingPeriod.MondayToFridayRate;
                    detailsViewModel.PricingPeriods.Add(editPricingPeriodViewModel);
                }

                DataContext = detailsViewModel;
            }
        }

        public void Save_Clicked(object sender, RoutedEventArgs e)
        {
            var yearError = Validation.GetHasError(Year);

            var viewModel = DataContext as EditViewModel;
            var request = new EditRequest();
            request.Id = viewModel.Id;
            request.Name = viewModel.Name;
            request.Description = viewModel.Description;
            request.Overview = viewModel.Overview;
            request.Details = viewModel.Details;
            request.DriveSide = viewModel.DriveSide;
            request.Berth = viewModel.Berth;
            request.Year = viewModel.Year;
            request.PricingPeriods = new List<EditPricingPeriodRequest>();

            foreach (var editPricingPeriodViewModel in viewModel.PricingPeriods)
            {
                var editPricingPeriodRequest = new EditPricingPeriodRequest();
                editPricingPeriodRequest.Id = editPricingPeriodViewModel.Id;
                editPricingPeriodRequest.StartMonth = editPricingPeriodViewModel.StartMonth;
                editPricingPeriodRequest.StartDay = editPricingPeriodViewModel.StartDay;
                editPricingPeriodRequest.EndMonth = editPricingPeriodViewModel.EndMonth;
                editPricingPeriodRequest.EndDay = editPricingPeriodViewModel.EndDay;
                editPricingPeriodRequest.FridayToFridayRate = editPricingPeriodViewModel.FridayToFridayRate;
                editPricingPeriodRequest.FridayToMondayRate = editPricingPeriodViewModel.FridayToMondayRate;
                editPricingPeriodRequest.MondayToFridayRate = editPricingPeriodViewModel.MondayToFridayRate;
                request.PricingPeriods.Add(editPricingPeriodRequest);
            }

            using(_contextProvider)
            {
                _busService.Edit(request);
            }

            //var a = ListViewPricingPeriods.ItemContainerGenerator.ContainerFromItem(ListViewPricingPeriods.Items[0]);
            //var ab = Validation.GetHasError(a);
            //    var d = a.GetDescendantByType<TextBox>();

            //    var f = a.FindName("StartDay");
            //    var b = ListViewPricingPeriods.ItemContainerGenerator.ContainerFromItem(ListViewPricingPeriods.Items[1]);
            //    var c = ListViewPricingPeriods.ItemContainerGenerator.ContainerFromItem(ListViewPricingPeriods.Items[2]);

            // get the current selected item
            //ListViewItem item = ListViewPricingPeriods.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
            //TextBox startDay = null;
            //if (item != null)
            //{
            //    //get the item's template parent
            //    ContentPresenter templateParent = GetFrameworkElementByName<ContentPresenter>(item);
            //    //get the DataTemplate that TextBlock in.
            //    DataTemplate dataTemplate = ListViewPricingPeriods.ItemTemplate;
            //    if (dataTemplate != null && templateParent != null)
            //    {
            //        startDay = dataTemplate.FindName("StartDay", templateParent) as TextBox;
            //    }

            //}
        }

        private static T GetFrameworkElementByName<T>(FrameworkElement referenceElement) where T : FrameworkElement
        {
            FrameworkElement child = null;
            for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(referenceElement); i++)
            {
                child = VisualTreeHelper.GetChild(referenceElement, i) as FrameworkElement;
                System.Diagnostics.Debug.WriteLine(child);
                if (child != null && child.GetType() == typeof(T))
                { break; }
                else if (child != null)
                {
                    child = GetFrameworkElementByName<T>(child);
                    if (child != null && child.GetType() == typeof(T))
                    {
                        break;
                    }
                }
            }
            return child as T;
        }
    }
}