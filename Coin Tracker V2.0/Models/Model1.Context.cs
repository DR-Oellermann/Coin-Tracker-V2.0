//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Coin_Tracker_V2._0.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SilverTrackerEntities : DbContext
    {
        public SilverTrackerEntities()
            : base("name=SilverTrackerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblCoin> tblCoins { get; set; }
        public virtual DbSet<tblCoinComposition> tblCoinCompositions { get; set; }
        public virtual DbSet<tblCoinType> tblCoinTypes { get; set; }
    }
}
