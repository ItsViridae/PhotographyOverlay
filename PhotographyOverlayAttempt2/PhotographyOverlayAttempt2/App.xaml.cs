using PhotographyOverlayAttempt2.CustomRenderers;
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

            MainPage = new MainPage();

            //var mainViewModel = new MainViewModel();
            //var mainView = new MainView(mainViewModel);

            //Create Camera Page to Pass on Load
            var cameraPageModel = new CameraPage();

            var navigationPage = new NavigationPage(cameraPageModel);
            ViewModel.Navigation = navigationPage.Navigation;

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
