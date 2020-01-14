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

        public ImagePage()
        {
            InitializeComponent();

            Assembly assembly = GetType().GetTypeInfo().Assembly;

            // Load 1 bitmaps for the overlay Image
            GetPhotoForStream();

            if(PhotoStream == null)
            {
                PhotoStream = PhotoFile.GetStream();
            }

            using (Stream stream = new MemoryStream())
            {
                ImageBitmap = SKBitmap.Decode(stream);
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
        public async Task GetPhotoForStream()
        {
            var photo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions());
            PhotoFile = photo;
        }
    }
}