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
    
    public partial class tblCoinComposition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCoinComposition()
        {
            this.tblCoins = new HashSet<tblCoin>();
        }
    
        public int Composition_ID { get; set; }
        public string Composition_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<tblCoin> tblCoins { get; set; }
    }
}
