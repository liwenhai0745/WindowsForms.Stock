using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WindowsForms.Stock.GPService
{
    public class DoRequestResult
    {

        public static Dictionary<string, GPTempInfo> sendInfo = new Dictionary<string, GPTempInfo>();

        List<StockInfo> stocks { get; set; }

        List<GPInfo> Datas { get; set; }
        public DoRequestResult(List<StockInfo> _stocks, List<GPInfo> _Datas)
        {
            this.stocks = _stocks;
            this.Datas = _Datas;
        }

        public bool isSleep { get; set; }
        public void Do()
        {
            string TextInfo = "";
            foreach (var item in stocks)
            {
                foreach (var x in Datas)
                {

                    if (!sendInfo.ContainsKey(x.Code))
                    {
                        sendInfo.Add(x.Code, new GPTempInfo()
                        {
                            mailSend = DateTime.Now,
                            Code = x.Code
                        });
                    }
                    else
                    {
                        sendInfo[x.Code] = new GPTempInfo()
                        {
                            mailSend = DateTime.Now,
                            Code = x.Code
                        };
                    }


                }

                if (item.data.market.status == "休市" || item.data.market.status == "已收盘")
                //if (false)
                {
                    isSleep = true;
                    break;
                }
                else
                {
                    //发邮件或者写文本

                    var quote = item.data.quote;
                    string Name = quote.name;
                    decimal CurPirce = quote.current;
                    var Item = Datas.Find(t => t.Code == quote.symbol);
                    if (Item == null) { return; }
                    decimal earnMoney = (CurPirce - Item.MyPrice) * Item.MyCount;

                    sendInfo[Item.Code].Name = Name;


                    string GPDesc = $"【{Name}】当前：{CurPirce} 持有:{Item.MyCount} 预期{(Item.Type == 1 ? Item.SalePrice : Item.LowBuyPrice)}";
                    Console.WriteLine(GPDesc);

                    if ((sendInfo[Item.Code].Price > 0 && sendInfo[Item.Code].Price != CurPirce) || sendInfo[Item.Code].Price == 0)
                    {
                        decimal moneyChange = sendInfo[Item.Code].Price - CurPirce;
                        if (sendInfo[Item.Code].Price == 0) { moneyChange = 0; }
                        sendInfo[Item.Code].Price = CurPirce;
                        sendInfo[Item.Code].EarnMony = earnMoney;
                        //重新设置价格，并记录到文本文件里
                        //LogTool.TempWriteLog(Item.Type + "", GPDesc + $" \t 预期盈利：{earnMoney}元,【{(moneyChange > 0 ? "增加" : "亏损")}{moneyChange}】元");
                        TextInfo += GPDesc + $" \t 盈利：{earnMoney}元,同比【{(moneyChange > 0 ? "增加" : "亏损")}{moneyChange}】元 "+Environment.NewLine;
                    }
                    else if (sendInfo[Item.Code].Price == CurPirce)
                    {
                        return;
                    }

                    bool isMailRemind = false;
                    if ((DateTime.Now - sendInfo[Item.Code].mailSend).TotalMinutes > 5)
                    {
                        switch (Item.Type)
                        {
                            case 1:
                                isMailRemind = (CurPirce >= Item.SalePrice);
                                break;
                            case 2:
                                isMailRemind = (CurPirce <= Item.LowBuyPrice);
                                break;
                            default:
                                break;
                        }
                    }

                    //如果5分钟前发了邮件就不要再发了
                    if (isMailRemind)
                    {
                        sendInfo[Item.Code].mailSend = DateTime.Now;
                        string MailContent = "";
                        switch (Item.Type)
                        {
                            case 1:
                                MailContent = "买入提醒" + $"：[{Name}]已经达到预期价格{Item.LowBuyPrice}";
                                break;
                            case 2:
                                MailContent = "销售提醒" + $"：[{Name}]已经达到预期价格{Item.SalePrice},成本价格{Item.MyPrice},预期盈利({CurPirce} - {Item.MyPrice}={CurPirce - Item.MyPrice}) * {Item.MyCount}={earnMoney}元\n" + GPDesc;
                                break;
                            default:
                                break;
                        }
                        //MailSend.SendEmail(MailContent + "\n https://xueqiu.com/S/" + quote.symbol);
                    }
                }
            }
            LogTool.TempWriteLog("GPINFO",DateTime.Now+Environment.NewLine+ TextInfo);
        }


       
    }
}
