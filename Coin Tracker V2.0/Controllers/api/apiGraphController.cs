using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Coin_Tracker_V2._0.Models;

namespace Coin_Tracker_V2._0.Controllers.api
{
    public class apiGraphController : ApiController
    {
        private SilverTrackerEntities db = new SilverTrackerEntities();
        public IHttpActionResult GetcoinType()
        {
            var coinType = db.tblCoins.GroupBy(x => x.tblCoinType)
                .Select(x => new {CoinType = x.Key.Type_Description, count = x.Count()}).ToList();

            return Ok(coinType);
        }

        public IHttpActionResult GetCollectionData()
        {
            double totalValue = 0;
            double totalWeight = 0;
            foreach (var item in db.tblCoins)
            {
                totalValue += item.Purchase_Amount;
                totalWeight += item.Coin_Weight;
            }

            int totalCoins = db.tblCoins.Count();

            var result = new {TotalCoins = totalCoins, TotalValue = totalValue, TotalWeight = totalWeight};

            return Ok(result);
        }
    }
}
