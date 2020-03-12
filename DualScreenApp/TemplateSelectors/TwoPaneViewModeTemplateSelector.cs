using System.Collections.ObjectModel;
using System.Linq;
using DualScreenApp.Core.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace DualScreenApp.TemplateSelectors
{
    public class TwoPaneViewModeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WideTemplate { get; set; }

        public DataTemplate SinglePaneTemplate { get; set; }

        public ObservableCollection<SampleOrder> Items { get; set; }

        public WinUI.TwoPaneViewMode _mode;

        public WinUI.TwoPaneViewMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                Items?.ToList().ForEach(i => SelectTemplateCore(i, null));
            }
        }



        public TwoPaneViewModeTemplateSelector()
        {
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch (Mode)
            {
                case WinUI.TwoPaneViewMode.Wide:
                    return WideTemplate;
                default:
                    return SinglePaneTemplate;
            }
        }
    }
}
