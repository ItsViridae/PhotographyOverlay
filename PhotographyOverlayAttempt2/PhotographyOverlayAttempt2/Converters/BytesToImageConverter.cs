﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.IO;
using Xamarin.Forms;

namespace PhotographyOverlayAttempt2.Converters
{
    public class BytesToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var bytes = (byte[])value;
            var stream = new MemoryStream(bytes);

            return ImageSource.FromStream(() => stream);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
