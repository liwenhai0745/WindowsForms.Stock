using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static async Task<string> SendRequestAsync(string url)
        {
            string uri = "http://stock.xueqiu.com/v5/stock/quote.json?symbol=sz002872";
            HttpClient client = new HttpClient(new MyHttpClienHanlder());
            var result = await client.GetStringAsync(uri);
            return result;
        }

        //public static string SendRequest(string url)
        //{
        //    string uri = "https://stock.xueqiu.com/v5/stock/quote.json?symbol=sz002872";
        //    HttpClient client = new HttpClient(new MyHttpClienHanlder());
        //    string body = client.GetStringAsync(uri).Result;
        //    return body;
        //}


        public static  string GetResponse(string url)
        {
            string result = "";
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            var httpClient = new HttpClient(new MyHttpClienHanlder());
            //httpClient.DefaultRequestHeaders.Accept.Add(
            //   new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;


            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = s;
            }
            return result;
        }
    }


    public class MyHttpClienHanlder : HttpClientHandler
    {
        public MyHttpClienHanlder() {
            this.UseCookies = false;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Cookie", "s=eg11m1mcsl; device_id=25aff45b70a70af2fea6bab4b0ddc414; _ga=GA1.2.1877971008.1544956887; _gid=GA1.2.92425315.1544956892; remember=1; remember.sig=K4F3faYzmVuqC0iXIERCQf55g2Y; xq_a_token=4bbe383cc438818efa1258affcaff3f7e4ac56c4; xq_a_token.sig=q8xUSZK_r6w70jsgMneHdvxZk3U; xqat=4bbe383cc438818efa1258affcaff3f7e4ac56c4; xqat.sig=VPQlgzfTcCSydeNuF61fQ78VXWk; xq_r_token=69f5092419a85cec69572fa79b55dacce1f81850; xq_r_token.sig=eabJT56QwkZoCALBa72-5Myt8FM; xq_is_login=1; xq_is_login.sig=J3LxgPVPUzbBg3Kee_PquUfih7Q; u=2355762923; u.sig=3clYngHBpnDwrH3reAI27O-xIvw; bid=e3a7a9105388503e35abd5a8945efecc_jpqsf5kr");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
