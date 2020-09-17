using CreateBarCodeTool.Utils;
using System;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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

        private void tbx_inputBarcode_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e) {
            if (VirtualKey.Enter == e.Key && e.KeyStatus.RepeatCount == 0) {
                string content = this.tbx_inputBarcode.Text;
                showResult(content);
            }
        }

        private void btn_help_Click(object sender, RoutedEventArgs e) {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(helpPage));
        }
    }
}
