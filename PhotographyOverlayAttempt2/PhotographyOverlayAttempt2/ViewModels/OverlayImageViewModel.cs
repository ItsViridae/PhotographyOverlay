using PhotographyOverlayAttempt2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PhotographyOverlayAttempt2.ViewModels
{
    public class OverlayImageViewModel : ViewModel
    {
        public ImageSource OverlayImage { get; set; }

        private byte[] photoBytes;
        private int opacity;
        public byte[] PhotoBytes
        {
            get => photoBytes;
            set => Set(ref photoBytes, value);
        }
        public int Opacity
        {
            get => opacity;
            set => Set(ref opacity, value);
        }

        /// <summary>
        /// Takes in a Byte array from stream, and (int) % opacity for the image.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="opacity"></param>
        public void Initialize(OverlayImage image)
        {
            PhotoBytes = image.PhotoBytes;
            Opacity = opacity;
        }
    }
}
