namespace MauiSummer25.Views;


public partial class CameraView : ContentPage
{
    public CameraView()
    {
        InitializeComponent();
       // cameraView.CamerasLoaded += CameraView_CamerasLoaded;
       // cameraView.BarcodeDetected += CameraView_BarcodeDetected;
    }

    //private void CameraView_CamerasLoaded(object sender, EventArgs e)
    //{
    //    if (cameraView.NumCamerasDetected > 0)
    //    {
    //        if (cameraView.NumMicrophonesDetected > 0)
    //            cameraView.Microphone = cameraView.Microphones.First();
    //        cameraView.Camera = cameraView.Cameras.First();
    //        MainThread.BeginInvokeOnMainThread(async () =>
    //        {
    //            if (await cameraView.StartCameraAsync() == CameraResult.Success)
    //            {
    //                controlButton.Text = "Stop";
    //                playing = true;
    //            }
    //        });
    //    }
    //}

    private async void cameraView_MediaCaptured(object sender, EventArgs e)
        //CaptureButton_Clicked(object sender, EventArgs e)
    {


        //if (!cameraView.IsCameraOpen)
        //{
        //    return;
        //}
    
        var result = await cameraView.CaptureImage(CancellationToken.None);
        if (result != null)
        {

            // Process the captured image stream (e.g., save to file, display in Image control)
            // Example: Display in an Image control
            //capturedImage.Source = ImageSource.FromStream(() => result);
        }
    }

    private void cameraView_MediaCaptured(object sender, CommunityToolkit.Maui.Core.MediaCapturedEventArgs e)
    {

    }
}