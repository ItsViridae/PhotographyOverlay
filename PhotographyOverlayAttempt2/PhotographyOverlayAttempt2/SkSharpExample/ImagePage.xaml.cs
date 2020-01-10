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
        SKBitmap imageBitmap;
        Stream photoStream;

        public ImagePage()
        {
            //InitializeComponent();
            // Load two bitmaps
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            GetPhotoForStream();

            using (Stream stream = photoStream)
            {
                imageBitmap = SKBitmap.Decode(stream);
            }
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
            float scale = Math.Min((float)info.Width / imageBitmap.Width,
                                   (float)info.Height / imageBitmap.Height);
            SKRect rect = SKRect.Create(scale * imageBitmap.Width,
                                        scale * imageBitmap.Height);
            float x = (info.Width - rect.Width) / 2;
            float y = (info.Height - rect.Height) / 2;
            rect.Offset(x, y);

            // Get progress value from Slider
            float progress = (float)progressSlider.Value;

            // Display two bitmaps with transparency
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = paint.Color.WithAlpha((byte)(0xFF * (1 - progress)));
                canvas.DrawBitmap(imageBitmap, rect, paint);

                //paint.Color = paint.Color.WithAlpha((byte)(0xFF * progress));
                //canvas.DrawBitmap(imageBitmap, rect, paint);
            }
        }
        public async void GetPhotoForStream()
        {
            var photo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions());
            photoStream = photo.GetStream();
        }
    }
}