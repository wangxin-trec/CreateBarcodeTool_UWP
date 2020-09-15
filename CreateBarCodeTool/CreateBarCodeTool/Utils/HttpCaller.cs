using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Security.Cryptography.Certificates;
using System.Threading;
using System.Diagnostics;

namespace CreateBarCodeTool.Utils {
    class HttpCaller {
        public async Task<JsonAnalyst> CallAppService(string posInfo, string reqUri) {
            string result = "";
            JsonAnalyst json = null;
            try {
                var filter = new HttpBaseProtocolFilter();
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);         // 期限を無視
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);       // 発行元を無視
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);     // ホスト名を無視

                CancellationTokenSource source = new CancellationTokenSource(10000);
                HttpClient apiHttpClient = new HttpClient(filter);
                HttpStringContent content = new HttpStringContent(posInfo, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                Uri url = new Uri(reqUri);
                Debug.WriteLine("-----http URL   :  " + url + " param:" + content.ToString().Replace("\r\n", ""));
                using (HttpResponseMessage response = await apiHttpClient.PostAsync(new Uri(reqUri), content).AsTask(source.Token)) {
                    result = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("-----http Result:　　url:" + url + "\n                  result:" + result);
                }

                json = new JsonAnalyst(result);
            } catch (Exception ex) {
                throw ex;
            }
            return json;
        }
    }
}
