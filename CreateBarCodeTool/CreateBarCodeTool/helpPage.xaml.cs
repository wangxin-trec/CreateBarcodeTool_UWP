using CreateBarCodeTool.Dto;
using System;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CreateBarCodeTool {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class helpPage : Page {
        public helpPage() {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            if ("".Equals(GlobalFlag.getInstance().getHelp())) {
                try {
                    Uri uri = new Uri("ms-appx:///Assets/readme.md");
                    StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);
                    GlobalFlag.getInstance().setHelp(await FileIO.ReadTextAsync(file));
                } catch (Exception ex) {
                    showError(ex);
                }
            }
            this.tbx_showHelp.Text = GlobalFlag.getInstance().getHelp();
        }

        private async void showError(Exception ex) {
            MessageDialog dialog = new MessageDialog(ex.Message, "エラー");
            dialog.Commands.Add(new UICommand("OK", cmd => { }, commandId: 0));
            await dialog.ShowAsync();
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(MainPage));
        }
    }
}
