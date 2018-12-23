using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsForms.Stock.GPService
{
    public class RequestHelper
    {

        public static List<StockInfo> SendQueryRequest(MyGP gp)
        {
            List<StockInfo> Results = new List<StockInfo>();
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var item in gp.Datas)
            {
                tasks.Add(SendRequest(item.URL));

            }
            Task.WaitAll(tasks.ToArray());
            foreach (var item in tasks)
            {
                //请求结果合并处理
                StockInfo info = Newtonsoft.Json.JsonConvert.DeserializeObject<StockInfo>(item.Result);
                Results.Add(info);
            }
            return Results;
        }

        public static async Task<string> SendRequest(string url)
        {
            using (HttpClient client = new HttpClient(new MyHttpClienHanlder()))
            {
                string result = "";
                var msg = await client.GetAsync(url);
                if (msg.IsSuccessStatusCode)
                {
                    result = await msg.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception("请求失败" + msg.StatusCode);
                }
                return result;
            }
        }

        public static async Task<StockInfo> GetStockInfoAsync(string code)
        {
            string url = "https://stock.xueqiu.com/v5/stock/quote.json?symbol=" + code;
            string result = await SendRequest(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<StockInfo>(result);
        }


        public static StockInfo GetStockInfo(string code)
        {
            string url = "https://stock.xueqiu.com/v5/stock/quote.json?symbol=" + code;

            string result = Request(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<StockInfo>(result);
        }


        /// <summary>
        /// 同步请求地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Request(string url)
        {
            //string uri = "http://stock.xueqiu.com/v5/stock/quote.json?symbol=sz002872";
            HttpClient client = new HttpClient(new MyHttpClienHanlder());
            var result = client.GetAsync(url).Result;

            if (result.IsSuccessStatusCode)
            {
                string content = result.Content.ReadAsStringAsync().Result;
                return content;

            }
            else
            {
                throw new Exception("请求错误:" + result.StatusCode);
            }
        }



    }

    public class MyHttpClienHanlder : HttpClientHandler
    {
        public MyHttpClienHanlder()
        {

            this.UseCookies = false;

        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Referer:https://xueqiu.com/S/SZ002872
            //request.Headers.Add("Referer", "https://xueqiu.com/S/SZ002872");
            //request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.26 Safari/537.36 Core/1.63.6788.400 QQBrowser/10.3.2767.400");
            request.Headers.Add("Cookie", "s=eg11m1mcsl; device_id=25aff45b70a70af2fea6bab4b0ddc414; _ga=GA1.2.1877971008.1544956887; _gid=GA1.2.92425315.1544956892; remember=1; remember.sig=K4F3faYzmVuqC0iXIERCQf55g2Y; xq_a_token=4bbe383cc438818efa1258affcaff3f7e4ac56c4; xq_a_token.sig=q8xUSZK_r6w70jsgMneHdvxZk3U; xqat=4bbe383cc438818efa1258affcaff3f7e4ac56c4; xqat.sig=VPQlgzfTcCSydeNuF61fQ78VXWk; xq_r_token=69f5092419a85cec69572fa79b55dacce1f81850; xq_r_token.sig=eabJT56QwkZoCALBa72-5Myt8FM; xq_is_login=1; xq_is_login.sig=J3LxgPVPUzbBg3Kee_PquUfih7Q; u=2355762923; u.sig=3clYngHBpnDwrH3reAI27O-xIvw; bid=e3a7a9105388503e35abd5a8945efecc_jpqsf5kr");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
