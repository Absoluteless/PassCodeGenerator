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
            _personalityWrapper.SolvedChanged += RaisePropertiesChanged;
            _code = string.Empty;
            RaisePropertiesChanged();
        }

        private string _code;
        private readonly PersonalityWrapper _personalityWrapper;

        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value, OnCodeChanged);
        }

        public string Greeting => _personalityWrapper.GetGreeting();

        public BitmapSource Image { get; private set; }

        public string GiftTo => _personalityWrapper.GetTo();

        private void OnCodeChanged()
        {
            _personalityWrapper.SetPersonalities(_code);
        }

        private void SetImage()
        {
            if (_personalityWrapper.Image != null)
            {
                var bmp = _personalityWrapper.Image;
                var width = bmp.Width;
                var height = bmp.Height;
                Image = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(width, height));
            }
            else
            {
                Image = null;
            }
        }

        private void RaisePropertiesChanged()
        {
            SetImage();
            RaisePropertyChanged(nameof(Greeting));
            RaisePropertyChanged(nameof(GiftTo));
            RaisePropertyChanged(nameof(Image));
        }
    }
}
