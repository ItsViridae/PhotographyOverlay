using PhotographyOverlayAttempt2.Models;
using PhotographyOverlayAttempt2.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotographyOverlayAttempt2.ViewModels
{
    public class FlexButtonViewModel : ViewModel
    {
        public bool IsButtonEnabled = true;
        private byte[] _bytes;

        bool isToggled;
        public bool IsToggled
        {
            get { return isToggled; }
            set { isToggled = value; OnPropertyChanged(); }
        }

        // Just demonstrates the use of Commands
        Command buttonClickedCommand;
        public Command ButtonClickedCommand => buttonClickedCommand ?? (buttonClickedCommand = new Command(() =>
        {
            Application.Current.MainPage.DisplayAlert("Hello from the View Model", "The Flex Button rocks!", "Yeah");
        }, () => IsButtonEnabled));

        // Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

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
            if (photo == null)
            {
                return;
            }

            var stream = photo.GetStream();
            _bytes = ReadFully(stream);

            var imageToView = new NewImage()
            {
                PhotoBytes = _bytes
            };

            //do somthing ... like show the image
            var view = new ResultView(imageToView);
            ((NewImageViewModel)view.BindingContext).Initialize(imageToView);

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
    }
}
