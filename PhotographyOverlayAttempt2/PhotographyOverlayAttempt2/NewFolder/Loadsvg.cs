using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PhotographyOverlayAttempt2.NewFolder
{
    public class Loadsvg
    {
        public Loadsvg()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Loadsvg)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.LibTextResource.txt");
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
        }
    }
}
