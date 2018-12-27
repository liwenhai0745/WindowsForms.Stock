using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Stock.GPService;

namespace WindowsForms.Stock
{
    public partial class Form1 : Form
    {
        SynchronizationContext synContext { get; set; }


        private List<stockExtend> MyStock = null;
        //private StockInfoEntities stockDb = new StockInfoEntities();

        private CancellationTokenSource cts = new CancellationTokenSource();

        private Task StockMainTask { get; set; }
        public Form1()
        {
            InitializeComponent();
            BindGridView();
            synContext = SynchronizationContext.Current;

            Task.Run(() =>
            {
                SystemTimerAsync();
            });


        }

        /// <summary>
        /// 系统后台任务，半小时执行一次，一直运行在后台，定时检测任务用的
        /// </summary>
        /// <returns></returns>
        private async Task<string> SystemTimerAsync()
        {
            do
            {

                bool isBuildTask = false;

                if (StockMainTask == null)
                {
                    isBuildTask = true;
                }
                else
                {
                    if (StockMainTask.IsCanceled || StockMainTask.IsCompleted || StockMainTask.IsFaulted)
                    {
                        isBuildTask = true;
                    }
                }

                if (isBuildTask)
                {
                    LoadStockInfo();
                }
                //cts = new CancellationTokenSource();
                Console.WriteLine(DateTime.Now.ToString() + "SystemTimer线程编号:" + Thread.CurrentThread.ManagedThreadId);
                //synContext.Post(x => toolStripStatusLabel1.Text = "上次操作时间:" + DateTime.Now.ToString(), null);



                int minute = DateTime.Now.Minute <= 30 ? (30 - DateTime.Now.Minute) : (60 - DateTime.Now.Minute);
                if (minute == 0) minute = 1;
                //StockMainTask();
                await Task.Delay(1000 * minute);


            } while (true);
        }

        private void LoadStockInfo()
        {
            cts = new CancellationTokenSource();
            StockMainTask = Task.Run(async () =>
            {
                await TaskTimerAsync();
            }, cts.Token);
        }

        private int Second = 15;
        private async Task TaskTimerAsync()
        {
            do
            {
                await GetCurStockPriceAsync();
                Console.WriteLine(DateTime.Now.ToString() + cts.IsCancellationRequested + "TaskTimer线程编号:" + Thread.CurrentThread.ManagedThreadId);

                await Task.Delay(1000 * Second);


            } while (!cts.IsCancellationRequested);
        }

        private async Task GetCurStockPriceAsync()
        {
            //await Task.Delay(1000 * 10);

            List<Task<StockInfo>> tasks = new List<Task<StockInfo>>();
            using (StockInfoEntities stockDb = new StockInfoEntities())
            {
                foreach (stock item in stockDb.stock.Where(t => t.type == "持有").ToList())
                {
                    var tempTask = Task.Run<StockInfo>(async () =>
                      {
                          using (StockInfoEntities db = new StockInfoEntities())
                          {
                              var stockinfo = db.stockInfos.SingleOrDefault(t => t.code == item.code);

                              return await RequestHelper.GetStockInfoAsync(stockinfo.area.ToUpper() + item.code);
                              //return new StockInfo();
                          }

                      });

                    tasks.Add(tempTask);
                }
            }

            var FinnalResult = await Task.WhenAll(tasks.ToArray());

            synContext.Post(x => toolStripStatusLabel1.Text = "上次操作时间:" + DateTime.Now.ToString(), null);

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                var temp = item.DataBoundItem as stock;
                var result = FinnalResult.FirstOrDefault(t => t.data.quote.code.ToLower() == temp.code);

                if (result != null)
                {
                    StaticInfo.StockStatus = result.data.market.status;
                    if (result.data.market.status == "休市" || result.data.market.status == "已收盘" || result.data.market.status == "休市")
                    {
                        synContext.Post(x => toolStripStatusLabel1.Text = "当前状态:" + result.data.market.status, null);
                        cts.Cancel();
                    }
                    decimal? earnMoney = (result.data.quote.current - temp.buyPrice) * temp.count;

                    MyStock.Find(t => t.code == temp.code).curPrice = result.data.quote.current;
                    //更新UI操作
                    synContext.Post(x =>
                    {
                        item.Cells["curPrice"].Value = result.data.quote.current;
                        item.Cells["earnMoney"].Value = earnMoney;
                        if (earnMoney > 0)
                        {
                            item.Cells["earnMoney"].Style.BackColor = Color.Red;
                        }
                    }, null);
                }
            }


        }

        private void BindGridView()
        {
            using (StockInfoEntities stockDb = new StockInfoEntities())
            {
                var Data = stockDb.stock.Where(t => t.type == "持有").ToList();
                MyStock = (from item in Data
                           select new stockExtend()
                           {
                               code = item.code,
                               buyPrice = item.buyPrice,
                               area = item.area,
                               count = item.count,
                               curPrice = 0,
                               name = item.name,
                               salePrice = item.salePrice,
                               type = item.type,
                               planEarnMoney = item.planEarnMoney
                           }
                          ).ToList();
                stockBindingSource.DataSource = Data;

            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            StockManager MyForm = new StockManager();
            MyForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //窗体关闭原因为单击"关闭"按钮或Alt+F4

            //if (e.CloseReason== CloseReason.UserClosing)
            //{
            //    e.Cancel= true;          //取消关闭操作
            //    this.Hide();              //隐藏窗体

            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //隐藏窗体
            //this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = true;//显示托盘图标
                this.Hide();//隐藏窗体
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.ShowInTaskbar == false)//该值决定一个 Form 对象是否出现在 Windows 任务栏中
                notifyIcon1.Visible = true;
            this.ShowInTaskbar = true;
            this.Show();
            this.Activate();
            this.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindGridView();
            LoadStockInfo();
        }
    }
}
