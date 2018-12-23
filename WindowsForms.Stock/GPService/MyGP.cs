using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsForms.Stock.GPService
{

    public class MyGP
    {
        public string HaveDatas { get; set; }
        public string ExpectDatas { get; set; }

        public List<GPInfo> Datas { get; set; }
    }

    //public class MyGP
    //{
    //    public List<GPInfo> Datas { get; set; }
    //}

    public class GPInfo
    {
        public string Code { get; set; }
        public decimal MyPrice { get; set; }
        public decimal SalePrice { get; set; }

        public string URL { get; set; }

        public int MyCount { get; set; }
        /// <summary>
        /// 低买价格
        /// </summary>
        public decimal LowBuyPrice { get; set; }
        /// <summary>
        /// 类型 1.持有  2.预估
        /// </summary>
        public int Type { get; set; }
    }


    public class GPTempInfo
    {
        public string Code { get; set; }

        public string Name { get; set; }
        public DateTime mailSend { get; set; }
        public decimal Price { get; set; }
        public decimal EarnMony { get; set; }
    }

}
