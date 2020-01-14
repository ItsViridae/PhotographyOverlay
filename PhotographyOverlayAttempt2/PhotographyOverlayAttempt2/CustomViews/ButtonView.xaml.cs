using PhotographyOverlayAttempt2.ViewModels;
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
    public partial class ButtonView : ContentView
    {
        public ButtonView()
        {
            InitializeComponent();
            BindingContext = new FlexButtonViewModel();
        }

        async void FlexButton_Clicked(object sender, EventArgs e)
        {
            // TODO: #7) Make Button Save and Photo 
            ((FlexButtonViewModel)BindingContext).IsButtonEnabled = !((FlexButtonViewModel)BindingContext).IsButtonEnabled;
            ((FlexButtonViewModel)BindingContext).ButtonClickedCommand.ChangeCanExecute();
            //await ((FlexButtonViewModel)BindingContext).TakePhotoTask();
        }
    }
}