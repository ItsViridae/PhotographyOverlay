using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PhotographyOverlayAttempt2.CustomRenderers;
using PhotographyOverlayAttempt2.Droid;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(CameraPage), typeof(CameraPageRenderer))]
namespace PhotographyOverlayAttempt2.Droid
{

    //public class CameraPageRenderer : PageRenderer, TextureView.ISurfaceTextureListener
    //{
    //    Android.Hardware.Camera2 _camera;
    //    //public Android.Hardware.Camera camera { get; set; }
    //    public Android.Widget.Button takePhotoButton { get; set; }
    //    public Android.Widget.Button toggleFlashButton { get; set; }
    //    public Android.Widget.Button switchCameraButton { get; set; }
    //    public Android.Views.View view { get; set; }

    //    Activity activity;
    //    CameraFacing cameraType;
    //    TextureView textureView;
    //    SurfaceTexture surfaceTexture;

    //    bool flashOn;


    //    public CameraPageRenderer(Context context) : base(context)
    //    {

    //    }

    //    protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
    //    {
    //        base.OnElementChanged(e);

    //        if (e.OldElement != null || Element == null)
    //        {
    //            return;
    //        }

    //        try
    //        {
    //            SetupUserInterface();
    //            SetupEventHandlers();
    //            AddView(view);
    //        }
    //        catch (Exception ex)
    //        {
    //            System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
    //        }
    //    }

    //    void SetupUserInterface()
    //    {
    //        activity = CrossCurrentActivity.Current.Activity;
    //        //activity = this.Context as Activity;
    //        view = activity.LayoutInflater.Inflate(Resource.Layout.CameraLayout, this, false);
    //        cameraType = CameraFacing.Back;

    //        textureView = view.FindViewById<TextureView>(Resource.Id.textureView);
    //        textureView.SurfaceTextureListener = this;
    //    }

    //    void SetupEventHandlers()
    //    {
    //        takePhotoButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.takePhotoButton);
    //        takePhotoButton.Click += TakePhotoButtonTapped;

    //        switchCameraButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.switchCameraButton);
    //        switchCameraButton.Click += SwitchCameraButtonTapped;

    //        toggleFlashButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.toggleFlashButton);
    //        toggleFlashButton.Click += ToggleFlashButtonTapped;
    //    }

    //    protected override void OnLayout(bool changed, int l, int t, int r, int b)
    //    {
    //        base.OnLayout(changed, l, t, r, b);

    //        var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
    //        var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

    //        view.Measure(msw, msh);
    //        view.Layout(0, 0, r - l, b - t);
    //    }


    //    void PrepareAndStartCamera()
    //    {
    //        camera.StopPreview();

    //        var display = activity.WindowManager.DefaultDisplay;
    //        if (display.Rotation == SurfaceOrientation.Rotation0)
    //        {
    //            camera.SetDisplayOrientation(90);
    //        }

    //        if (display.Rotation == SurfaceOrientation.Rotation270)
    //        {
    //            camera.SetDisplayOrientation(180);
    //        }

    //        camera.StartPreview();
    //    }

    //    void ToggleFlashButtonTapped(object sender, EventArgs e)
    //    {
    //        flashOn = !flashOn;
    //        if (flashOn)
    //        {
    //            if (cameraType == CameraFacing.Back)
    //            {
    //                toggleFlashButton.SetBackgroundResource(Resource.Drawable.FlashButton);
    //                cameraType = CameraFacing.Back;

    //                camera.StopPreview();
    //                camera.Release();
    //                camera = global::Android.Hardware.Camera.Open((int)cameraType);
    //                var parameters = camera.GetParameters();
    //                parameters.FlashMode = global::Android.Hardware.Camera.Parameters.FlashModeTorch;
    //                camera.SetParameters(parameters);
    //                camera.SetPreviewTexture(surfaceTexture);
    //                PrepareAndStartCamera();
    //            }
    //        }
    //        else
    //        {
    //            toggleFlashButton.SetBackgroundResource(Resource.Drawable.NoFlashButton);
    //            camera.StopPreview();
    //            camera.Release();

    //            camera = global::Android.Hardware.Camera.Open((int)cameraType);
    //            var parameters = camera.GetParameters();
    //            parameters.FlashMode = global::Android.Hardware.Camera.Parameters.FlashModeOff;
    //            camera.SetParameters(parameters);
    //            camera.SetPreviewTexture(surfaceTexture);
    //            PrepareAndStartCamera();
    //        }
    //    }

    //    void SwitchCameraButtonTapped(object sender, EventArgs e)
    //    {
    //        if (cameraType == CameraFacing.Front)
    //        {
    //            cameraType = CameraFacing.Back;

    //            camera.StopPreview();
    //            camera.Release();
    //            camera = global::Android.Hardware.Camera.Open((int)cameraType);
    //            camera.SetPreviewTexture(surfaceTexture);
    //            PrepareAndStartCamera();
    //        }
    //        else
    //        {
    //            cameraType = CameraFacing.Front;

    //            camera.StopPreview();
    //            camera.Release();
    //            camera = global::Android.Hardware.Camera.Open((int)cameraType);
    //            camera.SetPreviewTexture(surfaceTexture);
    //            PrepareAndStartCamera();
    //        }
    //    }

    //    async void TakePhotoButtonTapped(object sender, EventArgs e)
    //    {
    //        camera.StopPreview();

    //        var image = textureView.Bitmap;

    //        try
    //        {
    //            var absolutePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
    //            var folderPath = absolutePath + "/Camera";
    //            var filePath = System.IO.Path.Combine(folderPath, string.Format("photo_{0}.jpg", Guid.NewGuid()));

    //            var fileStream = new FileStream(filePath, FileMode.Create);
    //            await image.CompressAsync(Bitmap.CompressFormat.Jpeg, 50, fileStream);
    //            fileStream.Close();
    //            image.Recycle();

    //            var intent = new Android.Content.Intent(Android.Content.Intent.ActionMediaScannerScanFile);
    //            var file = new Java.IO.File(filePath);
    //            var uri = Android.Net.Uri.FromFile(file);
    //            intent.SetData(uri);
    //            MainActivity.Instance.SendBroadcast(intent);
    //        }
    //        catch (Exception ex)
    //        {
    //            System.Diagnostics.Debug.WriteLine(@"				", ex.Message);
    //        }

    //        camera.StartPreview();
    //    }

    //    public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
    //    {
    //        camera = global::Android.Hardware.Camera.Open((int)cameraType);
    //        textureView.LayoutParameters = new FrameLayout.LayoutParams(width, height);
    //        surfaceTexture = surface;

    //        camera.SetPreviewTexture(surface);
    //        PrepareAndStartCamera();
    //    }

    //    public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
    //    {
    //        camera.StopPreview();
    //        camera.Release();
    //        return true;
    //    }

    //    public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
    //    {
    //        PrepareAndStartCamera();
    //    }

    //    public void OnSurfaceTextureUpdated(SurfaceTexture surface)
    //    {
            
    //    }
    //}
}