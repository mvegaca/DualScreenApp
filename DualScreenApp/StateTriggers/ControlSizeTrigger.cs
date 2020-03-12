using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace DualScreenApp.StateTriggers
{
    public class ControlSizeTrigger : StateTriggerBase
    {
        private double _minHeight = -1;
        private double _minWidth = -1;
        private double _currentHeight;
        private double _currentWidth;
        private FrameworkElement _targetElement;

        public double MinHeight
        {
            get { return _minHeight; }
            set { _minHeight = value; }
        }

        public double MinWidth
        {
            get { return _minWidth; }
            set { _minWidth = value; }
        }

        public FrameworkElement TargetElement
        {
            get { return _targetElement; }
            set
            {
                if (_targetElement != null)
                {
                    _targetElement.SizeChanged -= OnTargetElementSizeChanged;
                }

                _targetElement = value;
                _targetElement.SizeChanged += OnTargetElementSizeChanged;
            }
        }

        public ControlSizeTrigger()
        {
        }

        private void OnTargetElementSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _currentHeight = e.NewSize.Height;
            _currentWidth = e.NewSize.Width;
            UpdateTrigger();
        }
        private void UpdateTrigger()
        {
            if (_targetElement != null && (_minWidth > 0 || _minHeight > 0))
            {
                if (_minHeight > 0 && _minWidth > 0)
                {
                    SetActive((_currentHeight >= _minHeight) && (_currentWidth >= _minWidth));
                }
                else if (_minHeight > 0)
                {
                    SetActive(_currentHeight >= _minHeight);
                }
                else
                {
                    SetActive(_currentWidth >= _minWidth);
                }
            }
            else
            {
                SetActive(false);
            }
        }
    }
}
