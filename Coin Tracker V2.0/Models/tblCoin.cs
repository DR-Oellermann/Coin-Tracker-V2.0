//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Coin_Tracker_V2._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCoin
    {
        public int Coin_ID { get; set; }
        [JsonIgnore]
        public int Type_ID { get; set; }
        [JsonIgnore]
        public int Composition_ID { get; set; }
        public string Coin_Name { get; set; }
        public string Coin_Description { get; set; }
        public System.DateTime Purchase_Date { get; set; }
        public double Purchase_Amount { get; set; }
        public Nullable<double> Face_Value { get; set; }
        public string Image_Path { get; set; }
        public double Coin_Weight { get; set; }
        public virtual tblCoinComposition tblCoinComposition { get; set; }
        public virtual tblCoinType tblCoinType { get; set; }
    }
}
