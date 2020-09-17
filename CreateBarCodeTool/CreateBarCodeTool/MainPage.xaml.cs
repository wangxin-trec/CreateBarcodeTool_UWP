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

        private async void showHelp(string help) {
            MessageDialog dialog = new MessageDialog(help, "Help");
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
            string help = " 一 主画面" + "\n" +
                          "     1.顶部的输入框输入字符后，电脑键盘回车即可在屏幕显示条形码和二维码。" + "\n" +
                          "     2.除了1的方式外也可以点击【生成】按钮。" + "\n" +
                          "     3.在条形码和二维码中间可以显示生成码的字符串。" + "\n" +
                          "     4.注意不要输入空字符串，汉字等非法字符，否则生成失败并且弹出error提示框。" + "\n" +
                          "     5.点击【簡易モード】按钮后，可进入到简单操作画面。" + "\n" +
                          "     6.点击【ヘルプ】按钮后，弹出程序使用说明对话框。" + "\n\n" +
                          " 二 简单操作画面" + "\n" +
                          "     1.简单操作画面三个单选按钮，默认是【スマホ】和【磁気】模式都不使用。" + "\n" +
                          "     2.简单操作画面中【スマホ】和【磁気】模式都不使用的条件下，【01号】~【09号】按钮在鼠标左键按下后，" + "\n" +
                          "       会自动跳转到主画面，显示测试卡1 ~测试卡9的条形码、字符串以及二维码。" + "\n" +
                          "     3.简单操作画面中【磁気】模式选中的条件下，【01号】~【09号】按钮在鼠标左键按下后，" + "\n" +
                          "       会自动跳转到主画面，显示测试卡1 ~测试卡9对应的【磁気】数据的条形码、字符串以及二维码。" + "\n" +
                          "     4.简单操作画面中【スマホ】模式选中的条件下，【01号】~【09号】按钮在鼠标左键按下后，" + "\n" +
                          "       先弹loading框，如果网络OK的情况下，会自动跳转到主画面，显示测试卡1 ~测试卡9对应的【スマホ】数据的条形码、字符串以及二维码；" + "\n" +
                          "       否则弹error提示框。" + "\n" +
                          "     5.简单操作画面商品JAN按钮在鼠标左键按下后，会自动跳转到主画面，显示按钮对应数据的条形码、字符串以及二维码。" + "\n" +
                          "     6.简单操作画面中【01号】~【09号】按钮在鼠标右键按下后，会弹确认取得卡信息的对话框，【Yes】表示同意，【No】表示不同意。" + "\n" +
                          "       点击【Yes】后会查询卡的信息显示到对话框里（将【カードの番号】、【ユーザー種類】、【プリカの残高】、【ポイント残高】、【ポイント利用】）。" + "\n" +
                          "     7.简单操作画面【戻る】按钮按下，会切回到主画面。" + "\n" +
                          "     8.简单操作画面商品JAN按钮在鼠标右键按下后，会弹出按钮绑定JAN的信息框，在信息框里可以选择要不要重置JAN，选择重置则跳转到【重置JAN】画面。" + "\n\n" +
                          " 三 重置JAN画面" + "\n" +
                          "     1.重置JAN画面的【戻る】按钮按下会回到简单操作画面。" + "\n" +
                          "     2.重置JAN画面的【保存】按钮按下会将文本框里的JAN保存下来，并弹出【保存しました！】的对话框。" + "\n" +
                          "     3.重置JAN画面的【取消】按钮按下会回到简单操作画面。";
            showHelp(help);
        }
    }
}
