using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhotographyOverlayAttempt2.CustomViews
{
    public enum CameraOptions
    {
        Rear,
        Front
    }

    public class CameraPreview : View
    {
        Command cameraClick;

        public static readonly BindableProperty CameraProperty = BindableProperty.Create(
            propertyName: "Camera",
            returnType: typeof(CameraOptions),
            declaringType: typeof(CameraPreview),
            defaultValue: CameraOptions.Front);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }

        public Command CameraClick
        {
            get { return cameraClick; }
            set { cameraClick = value; }
        }

        public void PictureTaken()
        {
            PictureFinished?.Invoke();
        }

        public event Action PictureFinished;
    }
}
