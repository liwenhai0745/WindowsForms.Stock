using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //var handler = new HttpClientHandler() { UseCookies = false };

            string url = "http://stock.xueqiu.com/v5/stock/quote.json?symbol=sz002872";
            HttpClient client = new HttpClient(new MyHttpClienHanlder());
            client.DefaultRequestHeaders.Add("Cookie", "s=eg11m1mcsl; device_id=25aff45b70a70af2fea6bab4b0ddc414; _ga=GA1.2.1877971008.1544956887; _gid=GA1.2.92425315.1544956892; remember=1; remember.sig=K4F3faYzmVuqC0iXIERCQf55g2Y; xq_a_token=4bbe383cc438818efa1258affcaff3f7e4ac56c4; xq_a_token.sig=q8xUSZK_r6w70jsgMneHdvxZk3U; xqat=4bbe383cc438818efa1258affcaff3f7e4ac56c4; xqat.sig=VPQlgzfTcCSydeNuF61fQ78VXWk; xq_r_token=69f5092419a85cec69572fa79b55dacce1f81850; xq_r_token.sig=eabJT56QwkZoCALBa72-5Myt8FM; xq_is_login=1; xq_is_login.sig=J3LxgPVPUzbBg3Kee_PquUfih7Q; u=2355762923; u.sig=3clYngHBpnDwrH3reAI27O-xIvw; bid=e3a7a9105388503e35abd5a8945efecc_jpqsf5kr");
            var msg = client.GetAsync(url).Result;
            string result = msg.Content.ReadAsStringAsync().Result;



            //var handler = new HttpClientHandler() { UseCookies = false };
            //var client = new HttpClient(handler);// { BaseAddress = baseAddress };
            //var message = new HttpRequestMessage(HttpMethod.Get, url);
            //message.Headers.Add("Cookie", "s=eg11m1mcsl; device_id=25aff45b70a70af2fea6bab4b0ddc414; _ga=GA1.2.1877971008.1544956887; _gid=GA1.2.92425315.1544956892; remember=1; remember.sig=K4F3faYzmVuqC0iXIERCQf55g2Y; xq_a_token=4bbe383cc438818efa1258affcaff3f7e4ac56c4; xq_a_token.sig=q8xUSZK_r6w70jsgMneHdvxZk3U; xqat=4bbe383cc438818efa1258affcaff3f7e4ac56c4; xqat.sig=VPQlgzfTcCSydeNuF61fQ78VXWk; xq_r_token=69f5092419a85cec69572fa79b55dacce1f81850; xq_r_token.sig=eabJT56QwkZoCALBa72-5Myt8FM; xq_is_login=1; xq_is_login.sig=J3LxgPVPUzbBg3Kee_PquUfih7Q; u=2355762923; u.sig=3clYngHBpnDwrH3reAI27O-xIvw; bid=e3a7a9105388503e35abd5a8945efecc_jpqsf5kr");
            //var result = client.SendAsync(message).Result.Content.ReadAsStringAsync().Result;



            MessageBox.Show(result);
            //WebClient webClient = new WebClient();
            //webClient.re(uri);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uri = "http://stock.xueqiu.com/v5/stock/quote.json?symbol=sz002872";
            HttpClient client = new HttpClient(new MyHttpClienHanlder());
            var msg = client.GetStringAsync(uri).Result;
            MessageBox.Show(msg);

        }
    }
}
