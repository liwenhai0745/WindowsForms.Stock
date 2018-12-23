
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Stock.GPService;

namespace WindowsForms.Stock
{
    public partial class StockManager : Form
    {

        private StockInfoEntities stockDb = new StockInfoEntities();

        public StockManager()
        {
            InitializeComponent();


            BindGridView();


        }

        private void BindGridView()
        {
            stockBindingSource.DataSource = stockDb.stock.ToList();
        }

        private void StockManager_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid != null && e.RowIndex >= 0)
            {
                if (grid.Columns[e.ColumnIndex].DataPropertyName == "code" || grid.Columns[e.ColumnIndex].DataPropertyName == "name")
                {
                    var temp = grid.Rows[e.RowIndex].DataBoundItem as stock;

                    string code = string.IsNullOrEmpty(temp.code) ? temp.name : temp.code;
                    if (!string.IsNullOrEmpty(code))
                    {
                        var result = stockDb.stockInfos.SingleOrDefault(t => t.code == code || t.name == code);
                        if (result == null)
                        {
                            MessageBox.Show("代码或者名称不存在！");
                        }
                        else
                        {
                            temp.name = result.name;
                            temp.code = result.code;

                            if (string.IsNullOrEmpty(temp.type))
                            {
                                temp.type = "持有";
                            }

                            grid.Rows[e.RowIndex].Cells["curPrice"].Value = RequestHelper.GetStockInfo(result.area + temp.code).data.quote.current; ;
                        }
                    }
                    //RequestHelper.SendRequest()
                    //grid.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value = "fox";
                }

                grid.Rows[e.RowIndex].Cells["changed"].Value = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<stock> stocks = new List<stock>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells["changed"].Value == null)
                {
                    continue;
                }
                string changed = item.Cells["changed"].Value.ToString();
                if (changed != "1") { continue; }
                var temp = item.DataBoundItem as stock;
                if (temp == null) { continue; }
                if (temp.id == 0)
                {
                    if (!string.IsNullOrEmpty(temp.code) && !string.IsNullOrEmpty(temp.name))
                    {

                        var result = stockDb.stockInfos.SingleOrDefault(t => t.code == temp.code || t.name == temp.code);
                        temp.area = result.area;
                        stockDb.stock.Add(temp);
                    }

                }
                else
                {
                    var Obj = stockDb.stock.Find(temp.id);
                    Obj.count = temp.count;
                    Obj.name = temp.name;
                    Obj.code = temp.code;
                    Obj.type = temp.type;
                    Obj.salePrice = temp.salePrice;
                    Obj.buyPrice = temp.buyPrice;
                    Obj.buyDate = temp.buyDate;
                    stocks.Add(Obj);

                }
            }
            stockDb.SaveChanges();
            BindGridView();
            toolStripStatusLabel1.Text = "操作成功！";

        }

        private void btnInitStock_Click(object sender, EventArgs e)
        {
            StockInit.InitAsync();
        }

        private void button2_ClickAsync(object sender, EventArgs e)
        {
            string result = RequestHelper.Request("http://stock.xueqiu.com/v5/stock/quote.json?symbol=sz002872");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<stock> stocks = new List<stock>();
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                var temp = item.DataBoundItem as stock;
                if (temp == null) { continue; }
                if (temp.id > 0)
                {
                    stocks.Add(temp);
                }
            }

            if (stocks.Count > 0)
            {
                stockDb.stock.RemoveRange(stocks);
                stockDb.SaveChanges();
            }
            BindGridView();
            toolStripStatusLabel1.Text = "操作成功！";

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //https://xueqiu.com/S/SZ002175
            DataGridView grid = sender as DataGridView;
            var temp = grid.Rows[e.RowIndex].DataBoundItem as stock;
            if (temp == null) { return; }
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "code" || grid.Columns[e.ColumnIndex].DataPropertyName == "name")
            {

                var result = stockDb.stockInfos.SingleOrDefault(t => t.code == temp.code || t.name == temp.code);

                var url = "https://xueqiu.com/S/" + result.area.ToUpper() + temp.code;
                //调用系统默认的浏览器 
                System.Diagnostics.Process.Start(url);
            } else if (grid.Columns[e.ColumnIndex].Name == "curPrice") {

                ////https://xueqiu.com/stock/forchartk/stocklist.json?symbol=SH600756&period=1day&type=before&begin=1478620800000&end=1510126200000&_=1510126200000
                //long timeUnix = ConvertDateTimeToInt(DateTime.Now.Date);
                //var url = $"https://xueqiu.com/stock/forchartk/stocklist.json?symbol={ temp.area.ToUpper() + temp.code}&period=1day&type=before&begin={timeUnix}&end={timeUnix}&_={timeUnix}";
                //string result = RequestHelper.Request(url);
            }
        }
       

        /// <summary>  
        /// 将c# DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }
    }
}
