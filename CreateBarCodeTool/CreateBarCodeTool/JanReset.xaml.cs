using CreateBarCodeTool.Dto;
using CreateBarCodeTool.Utils;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CreateBarCodeTool {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JanReset : Page {

        private JanBindButton janBindButton;

        public JanReset() {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            janBindButton = (JanBindButton)e.Parameter;
            this.tbx_restJan.Text = janBindButton.getJanCode();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e) {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(SimpleModePage));
        }

        private async void btn_saveJan_Click(object sender, RoutedEventArgs e) {
            DataBaseUtil.getSingleton().updateJanCode(janBindButton.getDbCol(), this.tbx_restJan.Text);
            MessageDialog dialog = new MessageDialog("保存しました！");
            dialog.ShowAsync();
        }

        private void btn_backToSimpleMode_Click(object sender, RoutedEventArgs e) {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(SimpleModePage));
        }
    }
}
