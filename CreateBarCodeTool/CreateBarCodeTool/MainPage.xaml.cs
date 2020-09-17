using CreateBarCodeTool.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CreateBarCodeTool
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            string context = (string)e.Parameter;
            if ("".Equals(context) || context == null) {
                return;
            }
            showResult(context);
        }

        private void btn_simpleMode_Click(object sender, RoutedEventArgs e) {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(SimpleModePage));
        }

        private void btn_showBarcodeImage_Click(object sender, RoutedEventArgs e) {
            string content = this.tbx_inputBarcode.Text;
            showResult(content);
        }

        private void showResult(string content) {
            try {
                this.img_showBarcode.Source = BarcodeUtil.createBarcode(content);
                this.img_showQRCode.Source = BarcodeUtil.createQRcode(content);
                this.tbx_showBarcode.Text = this.tbx_showBarcode.PlaceholderText + "\n"+ content;
            } catch (Exception ex) {
                showError(ex);
            } finally {
                tbx_inputBarcode.Text = "";
            }
        }

        private async void showError(Exception ex) {
            MessageDialog dialog = new MessageDialog(ex.Message, "エラー");
            dialog.Commands.Add(new UICommand("OK", cmd => { }, commandId: 0));
            await dialog.ShowAsync();
        }

        private void tbx_inputBarcode_KeyDown(object sender, KeyRoutedEventArgs e) {
            if (VirtualKey.Enter == e.Key && e.KeyStatus.RepeatCount == 0) {
                string content = this.tbx_inputBarcode.Text;
                showResult(content);
            }
        }

        private void btn_help_Click(object sender, RoutedEventArgs e) {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(helpPage));
        }

        private async void saveImage(Image image) {
            var rtb = new RenderTargetBitmap();
            await rtb.RenderAsync(image);
            var saveFile = new FileSavePicker();
            saveFile.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            saveFile.FileTypeChoices.Add("JPEG files", new List<string>() { ".jpg" });
            saveFile.FileTypeChoices.Add("PNG files", new List<string>() { ".png" });
            saveFile.SuggestedFileName = this.tbx_showBarcode.Text.Split('\r')[1];
            StorageFile sFile = await saveFile.PickSaveFileAsync();
            if (sFile == null)
                return;
            var pixels = await rtb.GetPixelsAsync();
            using (IRandomAccessStream stream = await sFile.OpenAsync(FileAccessMode.ReadWrite)) {
                var encoder = await
                BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                byte[] bytes = pixels.ToArray();
                encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                        BitmapAlphaMode.Ignore,
                                        (uint)rtb.PixelWidth,
                                        (uint)rtb.PixelHeight,
                                        200,
                                        200,
                                        bytes);

                await encoder.FlushAsync();
            }
        }

        private void image_showBarcode_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    MessageDialog dialog = new MessageDialog("このイメージが欲しいですか？");
                    dialog.Commands.Add(new UICommand("Yes", cmd => {
                        saveImage(this.img_showBarcode);
                    }, commandId: 0));
                    dialog.Commands.Add(new UICommand("No", cmd => { }, commandId: 1));
                    dialog.ShowAsync();
                }
            }
        }

        private void img_showQRCode_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    MessageDialog dialog = new MessageDialog("このイメージが欲しいですか？");
                    dialog.Commands.Add(new UICommand("Yes", cmd => {
                        saveImage(this.img_showQRCode);
                    }, commandId: 0));
                    dialog.Commands.Add(new UICommand("No", cmd => { }, commandId: 1));
                    dialog.ShowAsync();
                }
            }
        }
    }
}
