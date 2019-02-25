using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsForms.Stock.GPService
{

    public class StockInfo
    {
        public Data data { get; set; }
        public int error_code { get; set; }
        public string error_description { get; set; }
    }

    public class Data
    {
        public Market market { get; set; }
        public Quote quote { get; set; }
        //public Others others { get; set; }
        public object[] tags { get; set; }
    }

    public class Market
    {
        public int status_id { get; set; }
        public string region { get; set; }
        public string status { get; set; }
        public string time_zone { get; set; }
    }

    public class Quote
    {
        public string symbol { get; set; }
        public string code { get; set; }
        //public float high52w { get; set; }
        //public float avg_price { get; set; }
        public int type { get; set; }
        public float percent { get; set; }
        //public float tick_size { get; set; }
        //public long float_shares { get; set; }
        public float limit_down { get; set; }
        // public float amplitude { get; set; }
        public decimal current { get; set; }
        public decimal high { get; set; }
        //public float current_year_percent { get; set; }
        //public float float_market_capital { get; set; }
        //public long issue_date { get; set; }
        public decimal low { get; set; }
        //public string sub_type { get; set; }
        public float market_capital { get; set; }
        //public object dividend { get; set; }
        //public float dividend_yield { get; set; }
        public string currency { get; set; }
        //public int lot_size { get; set; }
        //public object lock_set { get; set; }
        //public float navps { get; set; }
        //public float profit { get; set; }
        //public long timestamp { get; set; }
        //public float pe_lyr { get; set; }
        //public float amount { get; set; }
        //public float chg { get; set; }
        //public float eps { get; set; }
        public float last_close { get; set; }
        //public float profit_four { get; set; }
        //public int volume { get; set; }
        //public float volume_ratio { get; set; }
        //public float pb { get; set; }
        //public float profit_forecast { get; set; }
        public float limit_up { get; set; }
        //public float turnover_rate { get; set; }
        //public float low52w { get; set; }
        public string name { get; set; }
        //public float pe_ttm { get; set; }
        public string exchange { get; set; }
        //public float pe_forecast { get; set; }
        public long time { get; set; }
        //public long total_shares { get; set; }
        public float open { get; set; }
        public int status { get; set; }
    }

    //public class Others
    //{
    //    public float pankou_ratio { get; set; }
    //}




    public class MaRootobject
    {
        public MaData data { get; set; }
        public int error_code { get; set; }
        public string error_description { get; set; }
    }

    public class MaData
    {
        public string symbol { get; set; }
        public string[] column { get; set; }
        public float[][] item { get; set; }
    }


}
