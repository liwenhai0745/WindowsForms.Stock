//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsForms.Stock
{
    using System;
    using System.Collections.Generic;
    
    public partial class stock
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public Nullable<decimal> buyPrice { get; set; }
        public Nullable<decimal> salePrice { get; set; }
        public Nullable<int> count { get; set; }
        public string type { get; set; }
        public Nullable<System.DateTime> buyDate { get; set; }
        public string expectedSource { get; set; }
        public string area { get; set; }
        public Nullable<decimal> planEarnMoney { get; set; }
        public Nullable<decimal> lowBuyPrice { get; set; }
        public Nullable<decimal> PrevEarnMoney { get; set; }
        public string Tip { get; set; }
        public string MAInfos { get; set; }
        public Nullable<bool> isShort { get; set; }
    }
}
