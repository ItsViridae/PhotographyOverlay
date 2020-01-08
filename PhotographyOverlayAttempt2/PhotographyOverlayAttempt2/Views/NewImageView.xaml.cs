using PhotographyOverlayAttempt2.ViewModels;
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
    public partial class NewImageView : ContentPage
    {
        public NewImageView(NewImageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}