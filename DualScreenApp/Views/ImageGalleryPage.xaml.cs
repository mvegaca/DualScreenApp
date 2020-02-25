using System;
using System.Drawing;
using DualScreenApp.ViewModels;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace DualScreenApp.Views
{
    public sealed partial class ImageGalleryPage : Page
    {
        private DispatcherTimer _dt;

        public ImageGalleryViewModel ViewModel { get; } = new ImageGalleryViewModel();

        public ImageGalleryPage()
        {
            InitializeComponent();
            Loaded += ImageGalleryPage_Loaded;
            _dt = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(30)
            };
            _dt.Tick += _dt_Tick;
        }

        private void _dt_Tick(object sender, object e)
        {
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            var size = new Size((int)(bounds.Width * scaleFactor), (int)(bounds.Height * scaleFactor));

            System.Diagnostics.Debug.WriteLine("*********************************************************************");
            System.Diagnostics.Debug.WriteLine($"TwoPaneView Mode: {twoPaneView.Mode}");
            System.Diagnostics.Debug.WriteLine($"Screen size: {size}");
        }

        private async void ImageGalleryPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
            _dt.Start();
        }
    }
}
