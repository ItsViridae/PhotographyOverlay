﻿using PhotographyOverlayAttempt2.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotographyOverlayAttempt2.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraView : ContentView
    {
        public CameraView()
        {
            InitializeComponent();
        }

        private async void OnClick_CancelPhotoFeed(object sender, EventArgs e)
        {
            await CameraPreview.Navigation.PushAsync(new GetImagePage());
        }
    }
}