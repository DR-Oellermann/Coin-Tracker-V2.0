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
    }
}
