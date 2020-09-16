using CreateBarCodeTool.Utils;
using System;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CreateBarCodeTool {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SimpleModePage : Page {

        private static string swingCardStart  = "?1300000613881";
        private static string swingCardEnd    = "00000000000;";
        private static string TEST_ONE        = "2960000000012";
        private static string TEST_TWO        = "2960000000029";
        private static string TEST_THREE      = "2960000000036";
        private static string TEST_FOUR       = "2960000000043";
        private static string TEST_FIVE       = "2960000000050";
        private static string TEST_SIX        = "2960000000067";
        private static string TEST_SEVEN      = "2960000000074";
        private static string TEST_EIGHT      = "2960000000081";
        private static string TEST_NINE       = "2960000000098";

        private static string TWOFIVEJAN      = "2531446000999";
        private static string TWENTYFORBIDDEN = "4902210170510";
        private static string DRUG            = "4987774264288";
        private static string SECURITY        = "4972940601189";
        private static string DISCOUNT        = "25000010279001000302";
        private static string HEAD0           = "080686816072";
        private static string POSA            = "45802958260810006375028312416600";
        private static string MARUKYU         = "7130207110001939";
        private static string TAMARU          = "4522646331332";
        private static string BRANDSWITCH     = "4902388057026";
        private static string TIMESCOUPON     = "4522646735680";
        private static string PERIOD          = "4930726000175";
        private static string CAMPAIN         = "4902102077354";
        private static string BAG             = "4522646330991";
        private static string ZEROPRICE       = "4908819933402";
        private static string GATE            = "000000010061";
        private static string STAFF           = "2000100764206";

        public SimpleModePage() {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(356, 610));
            ApplicationView.GetForCurrentView().TryResizeView(new Size(356, 610));
            this.hideLoading();
        }

        private void btn_testOne_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_ONE);
        }

        private void btn_testTwo_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_TWO);
        }

        private void btn_testThree_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_THREE);
        }

        private void btn_testFour_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_FOUR);
        }

        private void btn_testFive_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_FIVE);
        }

        private void btn_testSix_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_SIX);
        }

        private void btn_testSeven_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_SEVEN);
        }

        private void btn_testEight_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_EIGHT);
        }

        private void btn_testNine_Click(object sender, RoutedEventArgs e) {
            backToMainPage(TEST_NINE);
        }

        private void btn_25Jan_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(TWOFIVEJAN);
        }
        private void btn_twentyForbidden_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(TWENTYFORBIDDEN);
        }

        private void btn_drug_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(DRUG);
        }

        private void btn_security_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(SECURITY);
        }

        private void btn_discount_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(DISCOUNT);
        }

        private void btn_head0_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(HEAD0);
        }

        private void btn_POSA_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(POSA);
        }

        private void btn_marukyu_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(MARUKYU);
        }

        private void btn_tamaruCoupon_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(TAMARU);
        }

        private void btn_brandSwich_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(BRANDSWITCH);
        }

        private void btn_timesCoupon_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(TIMESCOUPON);
        }

        private void btn_period_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(PERIOD);
        }

        private void btn_campain_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(CAMPAIN);
        }

        private void btn_bag_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(BAG);
        }

        private void btn_zeroPrice_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(ZEROPRICE);
        }

        private void btn_gate_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(GATE);
        }

        private void btn_staff_Click(object sender, RoutedEventArgs e) {
            backToMainPageByProduct(STAFF);
        }

        private async void backToMainPage(string testCardNumber) {
            Frame root = Window.Current.Content as Frame;
            if ((bool)this.raBtn_both_no.IsChecked) {
                root.Navigate(typeof(MainPage), testCardNumber);
                return;
            } else if ((bool)this.raBtn_swingCard_yes.IsChecked) {
                string swingCard = swingCardStart + testCardNumber + swingCardEnd;
                root.Navigate(typeof(MainPage), swingCard);
                return;
            } else if ((bool)this.raBtn_smartPhone_yes.IsChecked) {
                showLoading();
                try {
                    JsonAnalyst result = await new HttpCaller().CallAppService(RequestParam.getSmartPhoneParam(testCardNumber), RequestParam.getSmartPhoneUrl());
                    string barcode = result.GetFirstLevelValue("Barcode");
                    root.Navigate(typeof(MainPage), barcode);
                } catch (Exception ex) {
                    showError(ex);
                } finally {
                    hideLoading();
                }
            }
        }

        private void backToMainPageByProduct(string productJan) {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(MainPage), productJan);
        }

        private void btn_testOne_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_ONE,"1111");
                }
            }
        }

        private void btn_testTwo_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_TWO,"2222");
                }
            }
        }

        private void btn_testThree_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_THREE,"3333");
                }
            }
        }

        private void btn_testFour_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_FOUR,"4444");
                }
            }
        }

        private void btn_testFive_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_FIVE,"5555");
                }
            }
        }

        private void btn_testSix_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_SIX,"6666");
                }
            }
        }

        private void btn_testSeven_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_SEVEN,"7777");
                }
            }
        }

        private void btn_testEight_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_EIGHT,"8888");
                }
            }
        }

        private void btn_testNine_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showPrePaidCardMessage(TEST_NINE,"9999");
                }
            }
        }

        private void btn_25Jan_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(TWOFIVEJAN);
                }
            }
        }

        private void btn_twentyForbidden_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(TWENTYFORBIDDEN);
                }
            }
        }

        private void btn_drug_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(DRUG);
                }
            }
        }

        private void btn_security_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(SECURITY);
                }
            }
        }

        private void btn_discount_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(DISCOUNT);
                }
            }
        }

        private void btn_head0_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(HEAD0);
                }
            }
        }

        private void btn_POSA_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(POSA);
                }
            }
        }

        private void btn_marukyu_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(MARUKYU);
                }
            }
        }

        private void btn_tamaruCoupon_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(TAMARU);
                }
            }
        }

        private void btn_brandSwich_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(BRANDSWITCH);
                }
            }
        }

        private void btn_timesCoupon_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(TIMESCOUPON);
                }
            }
        }

        private void btn_period_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(PERIOD);
                }
            }
        }

        private void btn_bag_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(BAG);
                }
            }
        }

        private void btn_zeroPrice_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(ZEROPRICE);
                }
            }
        }

        private void btn_campain_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(CAMPAIN);
                }
            }
        }

        private void btn_gate_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(GATE);
                }
            }
        }

        private void btn_staff_PointerPressed(object sender, PointerRoutedEventArgs e) {
            if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) {
                var properties = e.GetCurrentPoint(this).Properties;
                if (properties.IsRightButtonPressed) {
                    showJanCodeMessage(STAFF);
                }
            }
        }

        private async void showJanCodeMessage(string janCode) {
            MessageDialog dialog = new MessageDialog("このボタンのJANは： " + janCode, "メッセージ");
            dialog.Commands.Add(new UICommand("OK", cmd => { }, commandId: 0));
            dialog.Commands.Add(new UICommand("改修", cmd => { }, commandId: 1));
            await dialog.ShowAsync();
        }

        private async void showPrePaidCardMessage(string memberid, string pincode) {
            MessageDialog dialog = new MessageDialog("プリペイドカードの情報を取得たいですか？", "メッセージ");
            dialog.Commands.Add(new UICommand("Yes", async cmd => {
                showLoading();
                JsonAnalyst result;
                JsonAnalyst memberInfoResult;
                string memberType = "";
                string money = "";
                string point = "";
                string pointCanUse = "";
                try {
                    result = await new HttpCaller().CallAppService(RequestParam.getGoldUserParam(memberid), RequestParam.getGoldUserUrl());
                    memberInfoResult = await new HttpCaller().CallAppService(RequestParam.get4URequestParam(memberid, pincode), RequestParam.get4URequestURL());
                    money = memberInfoResult.GetFourthLevelValue("CurrentState", "Transaction", "PrepayedCardInfo", "AmountsAvailable");
                    point = memberInfoResult.GetFourthLevelValue("CurrentState", "Transaction", "PointCardInfo", "AmountsAvailable");
                    if ("".Equals(point)) {
                        point = "0";
                    }
                    string courtesyLevel = memberInfoResult.GetFourthLevelValue("CurrentState", "Transaction", "PointCardInfo", "CourtesyLevel");
                    if (int.Parse(courtesyLevel) % 2 == 0) {
                        pointCanUse = "〇";
                    } else {
                        pointCanUse = "×";
                    }
                    if ("true".Equals(result.GetFirstLevelValue("success").ToLower())) {
                        string isGoldUser = result.GetSecondLevelValueFromArray("data", "isGoldUser", 0).ToLower();
                        if ("true".Equals(isGoldUser)) {
                            memberType = "Gold User";
                        } else {
                            memberType = "非Gold User";
                        }
                    } else if (result == null || "false".Equals(result.GetFirstLevelValue("success").ToLower())) {
                        memberType = "error";
                    }
                } catch (Exception ex) {
                    memberType = "error";
                    money = "error";
                    point = "error";
                    pointCanUse = "error";
                } finally {
                    hideLoading();
                    showMemberInfo(memberid, memberType, money, point, pointCanUse);
                }
            }, commandId: 0));
            dialog.Commands.Add(new UICommand("No", cmd => { }, commandId: 1));
            await dialog.ShowAsync();
        }

        private void showLoading() {
            this.GridLoading.Visibility = Visibility.Visible;
            this.ProgressRingLoading.IsActive = true;
        }

        private void hideLoading() {
            this.ProgressRingLoading.IsActive = false;
            this.GridLoading.Visibility = Visibility.Collapsed;
        }

        private async void showMemberInfo(string memberid, string memberType, string money, string point, string pointCanUse) {
            string memeberInfo = "カードの番号: " + memberid + "\n";
                  memeberInfo += "ユーザー種類: " + memberType + "\n";
                  memeberInfo += "プリカの残高: " + money + "\n";
                  memeberInfo += "ポイント残高: " + point + "\n";
                  memeberInfo += "ポイント利用: " + pointCanUse + "\n";
            MessageDialog dialog = new MessageDialog(memeberInfo, "Member情報");
            dialog.Commands.Add(new UICommand("OK", cmd => { }, commandId: 0));
            await dialog.ShowAsync();
        }

        private async void showError(Exception ex) {
            MessageDialog dialog = new MessageDialog(ex.Message, "エラー");
            dialog.Commands.Add(new UICommand("OK", cmd => { }, commandId: 0));
            await dialog.ShowAsync();
        }

        private void btn_backToMain_Click(object sender, RoutedEventArgs e) {
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(MainPage));
        }
    }
}
