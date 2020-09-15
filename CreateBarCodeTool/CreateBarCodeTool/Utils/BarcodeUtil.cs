using System;
using Windows.UI.Xaml.Media.Imaging;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace CreateBarCodeTool.Utils {
    class BarcodeUtil {

        public static WriteableBitmap createBarcode(string content) {
            try {
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.CODE_128;
                EncodingOptions options = new EncodingOptions();
                options.Width = 356;
                options.Height = 100;
                barcodeWriter.Options = options;
                WriteableBitmap writeableBitmap = barcodeWriter.Write(content);
                return writeableBitmap;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static WriteableBitmap createQRcode(string content) {
            try {
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.QR_CODE;
                QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                options.CharacterSet = "UTF-8";
                options.Width = 270;
                options.Height = 270;
                barcodeWriter.Options = options;
                WriteableBitmap writeableBitmap = barcodeWriter.Write(content);
                return writeableBitmap;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
