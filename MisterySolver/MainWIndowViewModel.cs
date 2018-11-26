using System;
using System.Windows.Media.Imaging;
using MisterySolver.Wrappers;
using Prism.Mvvm;

namespace MisterySolver
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            _personalityWrapper = new PersonalityWrapper();
            _code = string.Empty;
            OnCodeChanged();
            SetImage();
        }

        private string _code;
        private readonly PersonalityWrapper _personalityWrapper;

        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value, OnCodeChanged);
        }

        public string Greeting => _personalityWrapper.GetGreeting();

        public BitmapSource FromImage { get; private set; }

        public string GiftTo => _personalityWrapper.GetTo();

        private void OnCodeChanged()
        {
            _personalityWrapper.SetPersonalities(_code);
            RaisePropertiesChanged();
        }

        private void SetImage()
        {
            if (_personalityWrapper.Image != null)
            {
                var bmp = _personalityWrapper.Image;
                var width = bmp.Width;
                var height = bmp.Height;
                FromImage = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(width, height));
            }
            else
            {
                FromImage = null;
            }
        }

        private void RaisePropertiesChanged()
        {
            RaisePropertyChanged(nameof(Greeting));
            RaisePropertyChanged(nameof(GiftTo));
            RaisePropertyChanged(nameof(FromImage));
        }
    }
}
