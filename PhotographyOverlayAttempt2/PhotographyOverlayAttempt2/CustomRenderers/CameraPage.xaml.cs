using PhotographyOverlayAttempt2.CustomViews;
using PhotographyOverlayAttempt2.Models;
using PhotographyOverlayAttempt2.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotographyOverlayAttempt2.CustomRenderers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        public CustomImageView Viewer => ImageViewer;

        public CameraPage()
        {
            InitializeComponent();
        }

        private void OnClick_PickPhoto(object sender, EventArgs e)
        {
            var imageViewModel = new GetImageViewModel();
            imageViewModel.PickPhoto.Execute(null);
            //await CameraPreview.Navigation.PushAsync(imageViewModel);
        }
    }
}