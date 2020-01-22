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
using System.Windows.Input;
using Xamarin.Forms;

namespace PhotographyOverlayAttempt2.ViewModels
{
    public class FlexButtonViewModel : ViewModel
    {
        public bool IsButtonEnabled = true;

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

        public ICommand TakePhoto => new Command(async () =>
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                //Saving the Image, but forced to use Default Camera
                // TODO: MAybe Change to not use Default Camera after MVP
                DefaultCamera = CameraDevice.Rear,
                SaveToAlbum = true
            });
        });

        // Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler CustomPropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) => CustomPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
