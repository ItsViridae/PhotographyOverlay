using PhotographyOverlayAttempt2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotographyOverlayAttempt2.CustomRenderers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetImagePage : ContentPage
    {
        public GetImagePage()
        {
            InitializeComponent();
            BindingContext = new GetImageViewModel();
        }
    }
}