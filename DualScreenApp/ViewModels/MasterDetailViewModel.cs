using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DualScreenApp.Core.Models;
using DualScreenApp.Core.Services;
using DualScreenApp.Helpers;
using Microsoft.UI.Xaml.Controls;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace DualScreenApp.ViewModels
{
    public class MasterDetailViewModel : Observable
    {
        private TwoPaneView _twoPaneView;
        private ICommand _selectionChangedCommand;
        private SampleOrder _selected;

        private WinUI.TwoPaneViewPriority _twoPanePriority;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public WinUI.TwoPaneViewPriority TwoPanePriority
        {
            get { return _twoPanePriority; }
            set { Set(ref _twoPanePriority, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public ICommand SelectionChangedCommand => _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand(OnSelectionChanged));

        public MasterDetailViewModel()
        {
        }

        public void Initialize(TwoPaneView twoPaneView)
        {
            _twoPaneView = twoPaneView;
        }

        public async Task LoadDataAsync()
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetMasterDetailDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            Selected = SampleItems.First();
        }

        public bool TryCloseDetail(bool cancel)
        {
            if (!cancel)
            {
                if (TwoPanePriority == WinUI.TwoPaneViewPriority.Pane2)
                {
                    TwoPanePriority = WinUI.TwoPaneViewPriority.Pane1;
                    return true;
                }
            }

            return false;
        }

        private void OnSelectionChanged()
        {
            if (_twoPaneView.Mode == WinUI.TwoPaneViewMode.SinglePane)
            {
                TwoPanePriority = WinUI.TwoPaneViewPriority.Pane2;
            }
        }
    }
}
