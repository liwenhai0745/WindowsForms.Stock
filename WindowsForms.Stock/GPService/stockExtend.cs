using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms.Stock.GPService
{

    public delegate void PriceChange(decimal oldPrice, decimal newPrice);

    public class stockExtend : stock
    {
        /// <summary>
        /// 金额变动事件
        /// </summary>
        public event PriceChange PriceChanged;

        public DateTime ? SendEmailDate { get; set; }
        public decimal curPrice
        {
            get { return _curPrice; }
            set
            {
                var oldPrice = this._curPrice;
                this._curPrice = value;
                PriceChanged?.Invoke(oldPrice, _curPrice);
            }
        }
        public decimal _curPrice;

        public stockExtend() {
            this.PriceChanged += StockExtend_PriceChanged;
        }

        private void StockExtend_PriceChanged(decimal oldPrice, decimal newPrice)
        {
            if (oldPrice > 0&& newPrice>0) {
                if (this.type == "持有") {

                    decimal earnMoney = (newPrice - this.buyPrice.Value) *this.count.Value;
                    string MailContent = "销售提醒" + $"：[{this.name}]已经达到预期价格{this.salePrice},成本价格{this.buyPrice},预期盈利({newPrice} - {this.buyPrice}={newPrice - this.buyPrice}) * {this.count}={earnMoney}元\n";


                    //1.如果达到预期价格就提示卖出
                    //2.如果赚钱超过50就提示卖出

                    if (newPrice >= this.salePrice|| earnMoney >= 50) {
                        SendEmail(MailContent);
                    }

                }
            }
        }

        private void SendEmail(string content) {
            bool isSend = false;
            if (SendEmailDate == null)
            {
                isSend = true;
            }
            else {
                if ((SendEmailDate - DateTime.Now).Value.TotalMinutes >= 5) {
                    isSend = true;
                }
            }
            if (isSend) {
                this.SendEmailDate = DateTime.Now;
                //发邮件出去
                MailSend.SendEmail(content);
            }
        }
    }
}
