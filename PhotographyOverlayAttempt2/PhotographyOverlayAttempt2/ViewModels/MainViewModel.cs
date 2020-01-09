using PhotographyOverlayAttempt2.Models;
using PhotographyOverlayAttempt2.Views;
using Plugin.Media;
using Autofac;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PhotographyOverlayAttempt2.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private byte[] _bytes;
        public MainViewModel()
        {
            Task.Run(async () => await TakePhotoTask());
        }

        public async Task TakePhotoTask()
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                DefaultCamera = CameraDevice.Rear
            });

            HandlePhoto(photo);
        }

        private void HandlePhoto(MediaFile photo)
        {
            if(photo == null)
            {
                return;
            }

            var stream = photo.GetStream();
            _bytes = ReadFully(stream);

            var imageToView = new OverlayImage()
            {
                PhotoBytes = _bytes
            };

            //do somthing ... like show the image
            var view = new ResultView(imageToView);
            ((OverlayImageViewModel)view.BindingContext).Initialize(imageToView);

            Navigation.PushAsync(view);
        }

        private byte[] ReadFully(Stream inputStream)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                inputStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public ICommand TakePhoto => new Command(async () =>
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                DefaultCamera = CameraDevice.Rear
            });

            HandlePhoto(photo);
        });

        public ICommand PickPhoto => new Command(async () =>
        {
            var photo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions());

            if (photo != null)
                HandlePhoto(photo);
            else return;
        });

      
    }
}