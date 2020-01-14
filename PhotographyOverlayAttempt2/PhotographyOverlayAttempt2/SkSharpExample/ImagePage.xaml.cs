using PhotographyOverlayAttempt2.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SkiaSharp;
using SkiaSharp.Views;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotographyOverlayAttempt2.SkSharpExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        SKBitmap ImageBitmap { get; set; }
        Stream PhotoStream { get; set; }
        MediaFile PhotoFile { get; set; }
        private byte[] _bytes { get; set; }

        public ImagePage(ImageFile image)
        {
            InitializeComponent();

            _bytes = image.PhotoBytes;
            ImageBitmap = image.ImageBitmap;
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

                //paint.Color = paint.Color.WithAlpha((byte)(0xFF * progress));
                //canvas.DrawBitmap(imageBitmap, rect, paint);
            }
        }
        
    }
}