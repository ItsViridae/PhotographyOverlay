using PhotographyOverlayAttempt2.Models;
using PhotographyOverlayAttempt2.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotographyOverlayAttempt2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverlayImageView : ContentPage
    {
        public OverlayImageView(OverlayImage viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}