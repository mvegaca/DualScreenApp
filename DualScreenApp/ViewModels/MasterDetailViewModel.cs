using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DualScreenApp.Core.Models;
using DualScreenApp.Core.Services;
using DualScreenApp.Helpers;
using Windows.UI.Xaml;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace DualScreenApp.ViewModels
{
    public class MasterDetailViewModel : Observable
    {
        private WinUI.TwoPaneView _twoPaneView;
        private SampleOrder _selected;
        private ICommand _itemClickCommand;
        private ICommand _modeChangedCommand;

        private bool _isWidePaneMode;
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

        public bool IsWidePaneMode
        {
            get { return _isWidePaneMode; }
            set { Set(ref _isWidePaneMode, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand(OnItemClick));

        public ICommand ModeChangedCommand => _modeChangedCommand ?? (_modeChangedCommand = new RelayCommand<WinUI.TwoPaneView>(OnModeChanged));

        public MasterDetailViewModel()
        {
        }

        public void Initialize(WinUI.TwoPaneView twoPaneView)
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

        private void OnItemClick()
        {
            if (_twoPaneView.Mode == WinUI.TwoPaneViewMode.SinglePane)
            {
                TwoPanePriority = WinUI.TwoPaneViewPriority.Pane2;
            }
        }

        private void OnModeChanged(WinUI.TwoPaneView twoPaneView)
        {
            if (twoPaneView.Mode == WinUI.TwoPaneViewMode.SinglePane)
            {
                TwoPanePriority = WinUI.TwoPaneViewPriority.Pane2;
            }

            IsWidePaneMode = twoPaneView.Mode == WinUI.TwoPaneViewMode.Wide;
        }
    }
}
