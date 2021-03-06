using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Coin_Tracker_V2._0.Models;
using Microsoft.Ajax.Utilities;
using System.IO;

namespace Coin_Tracker_V2._0.Controllers.api
{
    public class apiCoinsController : ApiController
    {
        private SilverTrackerEntities db = new SilverTrackerEntities();

        // GET: api/apiCoins
        public IHttpActionResult GettblCoins()
        {
            var result = db.tblCoins.ToList();
            return Ok(result);
        }

        // GET: api/apiCoins/5
        [ResponseType(typeof(tblCoin))]
        public IHttpActionResult GettblCoin(int id)
        {
            tblCoin tblCoin = db.tblCoins.Find(id);
            if (tblCoin == null)
            {
                return NotFound();
            }

            return Ok(tblCoin);
        }

        // PUT: api/apiCoins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblCoin(int id, tblCoin tblCoin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCoin.Coin_ID)
            {
                return BadRequest();
            }

            db.Entry(tblCoin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCoinExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/apiCoins
        [ResponseType(typeof(tblCoin))]
        public IHttpActionResult PosttblCoin(tblCoin tblCoin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCoins.Add(tblCoin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblCoin.Coin_ID }, tblCoin);
        }

        // DELETE: api/apiCoins/5
        [ResponseType(typeof(tblCoin))]
        public IHttpActionResult DeletetblCoin(int id)
        {
            tblCoin tblCoin = db.tblCoins.Find(id);

            //CoinsController coinsController = new CoinsController();

            //coinsController.DeletePicture(id);


            if (tblCoin == null)
            {
                return NotFound();
            }
            //not working maybe make method and call method
            //try
            //{
            //    string imageName = tblCoin.Image_Path;
            //    string filepath = "~//images/" + imageName;
            //    File.Delete(filepath);
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //    Debug.WriteLine(e);
            //}

            db.tblCoins.Remove(tblCoin);
            db.SaveChanges();

            return Ok(tblCoin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCoinExists(int id)
        {
            return db.tblCoins.Count(e => e.Coin_ID == id) > 0;
        }


    }
}