﻿using PhotographyOverlayAttempt2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PhotographyOverlayAttempt2.ViewModels
{
    public class OverlayImageViewModel : ViewModel
    {
        //public Image OverlayImage { get; set; }

        private byte[] photoBytes;

        public byte[] PhotoBytes
        {
            get => photoBytes;
            set => Set(ref photoBytes, value);
        }

        public void Initialize(OverlayImage image)
        {
            PhotoBytes = image.PhotoBytes;
        }
    }
}
