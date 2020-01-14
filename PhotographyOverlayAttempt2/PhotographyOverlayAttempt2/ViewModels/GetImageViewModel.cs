using PhotographyOverlayAttempt2.Models;
using PhotographyOverlayAttempt2.Views;
using PhotographyOverlayAttempt2.CustomRenderers;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PhotographyOverlayAttempt2.SkSharpExample;
using SkiaSharp;

namespace PhotographyOverlayAttempt2.ViewModels
{
    public class GetImageViewModel : ViewModel
    {
        SKBitmap _imageBitmap { get; set; }
        private byte[] _bytes;

        public GetImageViewModel()
        {
            var empty = new object();
            PickPhoto.Execute(empty);
        }

        public ICommand PickPhoto => new Command(async () =>
        {
            var photo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions());

            if (photo != null)
                HandlePhoto(photo);
            else return;
        });

        private void HandlePhoto(MediaFile photo)
        {
            if (photo == null)
            {
                return;
            }

            var currentStream = photo.GetStream();
            _bytes = ReadFully(currentStream);

            using (Stream stream = new MemoryStream(_bytes))
            {
                _imageBitmap = SKBitmap.Decode(stream);
            }

            var imageToView = new ImageFile()
            {
                PhotoBytes = _bytes,
                ImageBitmap = _imageBitmap
            };
            

            //var view = new ResultView(imageToView);
            //((OverlayImageViewModel)view.BindingContext).Initialize(imageToView);
            var imagePage = new ImagePage(imageToView);
            Navigation.PushAsync(imagePage);

            //((OverlayImageViewModel)overlayImageView.BindingContext).Initialize(imageToView);
            //breaks before Navigation
            //Navigation.PushAsync(overlayImageView);
        }

        private byte[] ReadFully(Stream inputStream)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                inputStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
