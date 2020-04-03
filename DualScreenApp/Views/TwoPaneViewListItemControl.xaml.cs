using System;

using DualScreenApp.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DualScreenApp.Views
{
    public sealed partial class TwoPaneViewListItemControl : UserControl
    {
        public SampleOrder Item
        {
            get { return (SampleOrder)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register(nameof(Item), typeof(SampleOrder), typeof(TwoPaneViewListItemControl), new PropertyMetadata(null, OnItemPropertyChanged));

        public TwoPaneViewListItemControl()
        {
            InitializeComponent();
        }

        private static void OnItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
