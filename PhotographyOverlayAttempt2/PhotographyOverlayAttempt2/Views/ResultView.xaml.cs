using PhotographyOverlayAttempt2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotographyOverlayAttempt2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultView : ContentPage
    {
        public ResultView(OverlayImage newImage)
        {
            //var newImage = new OverlayImage();
            InitializeComponent();
            BindingContext = newImage;
        }
    }
}