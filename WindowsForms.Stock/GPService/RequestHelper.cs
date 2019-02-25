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

            HttpClientHandler handler = new HttpClientHandler();
            handler.UseCookies = true;
            var uri = new Uri("https://xueqiu.com/S/SZ002872");

            //handler.CookieContainer.SetCookies(uri, "aas=test");
            HttpClient client = new HttpClient(handler);


            var result = client.GetStringAsync(uri);

            Console.WriteLine(result.Result);
            var getCookies = handler.CookieContainer.GetCookies(uri);
            Console.WriteLine("获取到的cookie数量：" + getCookies.Count);
            Console.WriteLine("获取到的cookie：");
            string cookieString = "";
            for (int i = 0; i < getCookies.Count; i++)
            {
                //Console.WriteLine(getCookies[i].Name + ":" + getCookies[i].Value);
                cookieString += getCookies[i].Name + "=" + getCookies[i].Value+";";
            }

            //Referer:https://xueqiu.com/S/SZ002872
            request.Headers.Add("Referer", "https://xueqiu.com/S/SZ002872");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.26 Safari/537.36 Core/1.63.6788.400 QQBrowser/10.3.2767.400");
            request.Headers.Add("Cookie", "device_id=c9feb9cb8d7625c968a5d72640e6f8df; _ga=GA1.2.1877971008.1544956887; s=eq1ziwj5xb; _gid=GA1.2.1696714880.1547607491;"+cookieString+" _gat_gtag_UA_16079156_4=1");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
