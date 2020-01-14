using PhotographyOverlayAttempt2.CustomRenderers;
using PhotographyOverlayAttempt2.SkSharpExample;
using PhotographyOverlayAttempt2.ViewModels;
using PhotographyOverlayAttempt2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotographyOverlayAttempt2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        protected override void OnStart()
        {

            MainPage = new MainPage();

            //Create Camera Page to Pass on Load

            #region Creating Navigational Pages

            var navigationCameraPage = new NavigationPage(new CameraPage());
            ViewModel.Navigation = navigationCameraPage.Navigation;
            var navigationImagePage = new NavigationPage(new GetImagePage());
            ViewModel.Navigation = navigationImagePage.Navigation;
            //ViewModel.Navigation.PushAsync(navigationCameraPage);
            //ViewModel.Navigation.PushAsync(navigationImagePage);


            MainPage = navigationCameraPage;
            #endregion
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
