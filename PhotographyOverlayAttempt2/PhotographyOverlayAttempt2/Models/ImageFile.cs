using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotographyOverlayAttempt2.Models
{
    public class ImageFile
    {
        public SKBitmap ImageBitmap { get; set; }
        public byte[] PhotoBytes { get; set; }
    }
}
