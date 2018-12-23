using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.Entity;
using AngleSharp.Dom;

namespace WindowsForms.Stock.GPService
{
    /// <summary>
    /// 股票信息初始化
    /// </summary>
    public class StockInit
    {
        public static async Task InitAsync()
        {
            StockInfoEntities stockDb = new StockInfoEntities();

            stockDb.Database.ExecuteSqlCommand("delete from stockInfos");
            var html = await RequestHelper.SendRequest("http://quote.eastmoney.com/stock_list.html");
            var parser = new HtmlParser();
            //Just get the DOM representation
            var document = parser.Parse(html);

            var stocks = document.QuerySelectorAll("div#quotesearch > ul > li > a");
            List<stockInfos> infos = new List<stockInfos>();

            bool isContinue = true;
            var skipCount = 0;
            do
            {
                //取一千条来处理
                var tempList = stocks.Skip(skipCount).Take(800);


                if (tempList.Count() == 0)
                {
                    isContinue = false;
                }
                else
                {
                   await Task.Run(async () => {
                         await DoAlLinkAsync(tempList, stockDb);
                    });
                    skipCount += tempList.Count();
                }

            } while (isContinue);
            //R003(201000)





            //if (infos.Count > 0) {
            //    StockInfoEntities stockDb = new StockInfoEntities();
            //    stockDb.stockInfos.AddRange(infos);
            //    stockDb.SaveChanges();
            //}
        }

        private static async Task DoAlLinkAsync(IEnumerable<IElement> elements, StockInfoEntities stockDb)
        {
            var reg = new Regex(@"(\w+)");
            foreach (var item in elements)
            {
                var Anchor = item as IHtmlAnchorElement;
                if (!string.IsNullOrEmpty(Anchor.InnerText))
                {
                    var result = reg.Matches(Anchor.InnerText);
                    try
                    {
                        var tmpobj = (new stockInfos()
                        {
                            code = result[1].Value,
                            name = result[0].Value,
                            area = Anchor.PathName.Substring(1, 2)
                        });
                        Console.WriteLine("正在处理：" + result[0].Value);
                        stockDb.stockInfos.Add(tmpobj);
                        await stockDb.SaveChangesAsync();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            }

        }
    }
}
