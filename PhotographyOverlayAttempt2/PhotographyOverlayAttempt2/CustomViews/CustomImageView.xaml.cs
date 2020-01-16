using PhotographyOverlayAttempt2.Models;
using PhotographyOverlayAttempt2.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
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
    public partial class CustomImageView : ContentView
    {
        SKBitmap ImageBitmap { get; set; }
        private byte[] _bytes { get; set; }

        public CustomImageView()
        {
            InitializeComponent();
            BindingContext = new GetImageViewModel();
        }


        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Find rectangle to fit bitmap
            float scale = Math.Min((float)info.Width / ImageBitmap.Width,
                                   (float)info.Height / ImageBitmap.Height);
            SKRect rect = SKRect.Create(scale * ImageBitmap.Width,
                                        scale * ImageBitmap.Height);
            float x = (info.Width - rect.Width) / 2;
            float y = (info.Height - rect.Height) / 2;
            rect.Offset(x, y);

            // Get progress value from Slider
            float progress = (float)progressSlider.Value;

            // Display two bitmaps with transparency
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = paint.Color.WithAlpha((byte)(0xFF * (1 - progress)));
                canvas.DrawBitmap(ImageBitmap, rect, paint);
            }
        }
    }
}