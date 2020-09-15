using System;
using System.Text;

namespace CreateBarCodeTool.Utils {
    class RequestParam {

        public static string getGoldUserParam(string memberid) {
            string param = "{";
            param += "\"memberid\":\"" + memberid + "\"";
            param += "}";
            return param;
        }

        public static string getGoldUserUrl() {
            return "http://10.100.2.191/app/dataReceive400/getGoldUser";
        }

        public static string get4URequestParam(string memberid, string pincode) {
            StringBuilder strParameter = new StringBuilder();
            strParameter.Append("{");
            strParameter.AppendFormat("\"AccessCode\":\"{0}\",", "012345");
            strParameter.AppendFormat("\"EventCode\":\"{0}\",", "87");
            strParameter.AppendFormat("\"DeviceId\":\"{0}\",", "21");
            strParameter.Append("\"InputData\":\"{");
            strParameter.AppendFormat("\\\"IsEMoneyOnly\\\":\\\"{0}\\\",", "false");
            strParameter.AppendFormat("\\\"PointCardNo\\\":\\\"{0}\\\",", memberid);
            strParameter.AppendFormat("\\\"PointCardPin\\\":\\\"{0}\\\"", "00" + pincode);
            strParameter.Append("}\"}");
            return strParameter.ToString();
        }

        public static string get4URequestURL() {
            StringBuilder strParameter = new StringBuilder();
            strParameter.Append("https://testtrialappgw.japanwest.cloudapp.azure.com");
            strParameter.Append("/POSLogicWebService.svc/AcceptEvent/");
            strParameter.Append("1405000001");
            strParameter.Append("/");
            strParameter.Append("00400");
            strParameter.Append("/");
            strParameter.Append("1006");
            strParameter.Append("?Timestamp=");
            strParameter.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"));
            return strParameter.ToString();
        }

        public static string getSmartPhoneUrl() {
            return "https://testtrialappgw.japanwest.cloudapp.azure.com:443/POSLogicWebService.svc/GetOneTimeBarcode/1405000001";
        }

        public static string getSmartPhoneParam(string cardNo) {
            string param = "{";
            param += "\"AccessCode\":\"012345\"";
            param += ",\"CardNo\":\"881" + cardNo + "\"";
            param += "}";
            return param;
        }

    }
}
