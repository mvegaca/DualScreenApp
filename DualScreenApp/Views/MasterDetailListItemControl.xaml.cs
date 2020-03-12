using System;
using DualScreenApp.Core.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DualScreenApp.Views
{
    public sealed partial class MasterDetailListItemControl : UserControl
    {
        public SampleOrder Item
        {
            get { return (SampleOrder)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register(nameof(Item), typeof(SampleOrder), typeof(MasterDetailListItemControl), new PropertyMetadata(null, OnItemPropertyChanged));        

        public MasterDetailListItemControl()
        {
            this.InitializeComponent();
        }

        private static void OnItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
