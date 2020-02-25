using DualScreenApp.Core.Models;
using DualScreenApp.Core.Services;
using DualScreenApp.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DualScreenApp.ViewModels
{
    public class ImageGalleryViewModel : Observable
    {
        private SampleImage _selectedImage;

        public SampleImage SelectedImage
        {
            get { return _selectedImage; }
            set { Set(ref _selectedImage, value); }
        }

        public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();

        public ImageGalleryViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            var data = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            foreach (var item in data)
            {
                Source.Add(item);
            }

            SelectedImage = Source.First();
        }
    }
}
