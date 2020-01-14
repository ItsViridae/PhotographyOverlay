using PhotographyOverlayAttempt2.CustomViews;
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
        public CameraPage()
        {
            InitializeComponent();
            CameraPreview.PictureFinished += OnPictureFinished;
        }

        void OnCameraClicked(object sender, EventArgs e)
        {
            CameraPreview.CameraClick?.Execute(null);
        }

        private void OnPictureFinished()
        {
            DisplayAlert("Confirm", "Picture Taken", "", "Ok");
        }

        private async void OnClick_CancelPhotoFeed(object sender, EventArgs e)
        {
            await CameraPreview.Navigation.PushAsync(new GetImagePage());
        }
    }
}