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
        public event PropertyChangedEventHandler CustomPropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) => CustomPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
