
using DualScreenApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DualScreenApp.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        public MasterDetailViewModel ViewModel { get; } = new MasterDetailViewModel();

        public MasterDetailPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(twoPaneView);
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadDataAsync();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);           
            if (e.NavigationMode == NavigationMode.Back && ViewModel.TryCloseDetail(e.Cancel))
            {
                e.Cancel = true;
            }
        }
    }
}
