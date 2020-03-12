using DualScreenApp.Core.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DualScreenApp.Views
{
    public sealed partial class MasterDetailDetailControl : UserControl
    {
        public SampleOrder SelectedItem
        {
            get { return GetValue(SelectedItemProperty) as SampleOrder; }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(SampleOrder), typeof(MasterDetailDetailControl), new PropertyMetadata(null, OnSelectedItemPropertyChanged));

        public MasterDetailDetailControl()
        {
            this.InitializeComponent();
        }

        private static void OnSelectedItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MasterDetailDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
