using PhotographyOverlayAttempt2.CustomRenderers;
using PhotographyOverlayAttempt2.CustomViews;
using PhotographyOverlayAttempt2.ViewModels;
using PhotographyOverlayAttempt2.Views;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PhotographyOverlayAttempt2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //var cameraPageModel = new CameraPage();

            
            //var navigationPage = new NavigationPage(cameraPageModel);
            //ViewModel.Navigation = navigationPage.Navigation;

            Task.Run(async () => await StartCameraOnStartup());
        }

        public async Task StartCameraOnStartup()
        {
            await Navigation.PushAsync(new CameraPage());
        }

        async void OnTakePhotoButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CameraPage());
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            bool hasCameraPermission = await GetCameraPermission();

            if (hasCameraPermission)
            {
                await Navigation.PushModalAsync(new CameraPage());
            }
        }

        async Task<bool> GetCameraPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync<CameraPermission>();
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        var result = await DisplayAlert("Camera access needed", "App needs Camera access enabled to work.", "ENABLE", "CANCEL");

                        if (!result)
                            return false;
                    }

                    var results = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();
                    //Best practice to always check that the key exists
                    //if (results.HasFlag(Permission.Camera))
                    //{
                    //    status = results[Permission.Camera];
                    //}
                }

                if (status == PermissionStatus.Granted)
                {
                    return true;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Could not access Camera", "App needs Camera access to work. Go to Settings >> App to enable Camera access ", "GOT IT");
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
