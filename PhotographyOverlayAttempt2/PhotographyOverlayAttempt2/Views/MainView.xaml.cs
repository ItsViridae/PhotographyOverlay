using PhotographyOverlayAttempt2.CustomRenderers;
using PhotographyOverlayAttempt2.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotographyOverlayAttempt2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
            NavigationPage.SetBackButtonTitle(this, string.Empty);
        }
        async void OnTakePhotoButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CameraPage());
        }
    }
}