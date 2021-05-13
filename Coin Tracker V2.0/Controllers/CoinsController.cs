using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Coin_Tracker_V2._0.Models;

namespace Coin_Tracker_V2._0.Controllers
{
    public class CoinsController : Controller
    {
        private SilverTrackerEntities db = new SilverTrackerEntities();

        // GET: Coins
        public ActionResult Index()
        {
            return View();
        }

        // GET: Coins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCoin tblCoin = db.tblCoins.Find(id);
            if (tblCoin == null)
            {
                return HttpNotFound();
            }
            return View(tblCoin);
        }

        // GET: Coins/Create
        public ActionResult Create()
        {
            ViewBag.Composition_ID = new SelectList(db.tblCoinCompositions, "Composition_ID", "Composition_Description");
            ViewBag.Type_ID = new SelectList(db.tblCoinTypes, "Type_ID", "Type_Description");
            return View();
        }

        // POST: Coins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Coin_ID,Type_ID,Composition_ID,Coin_Name,Coin_Description,Purchase_Date,Purchase_Amount,Face_Value,Image_Path,Coin_Weight")] tblCoin tblCoin, HttpPostedFileBase image)
        {
            if (image != null)
            {
                try
                {
                    //replaces any whitespace in the name with underscore
                    string coinName = tblCoin.Coin_Name.Replace(" ", "_");
                    //set the image name
                    string imgName = Convert.ToString(tblCoin.Coin_ID) + "_" + coinName +
                                     "_" + System.IO.Path.GetFileName(image.FileName);
                    //save the image to the images folder
                    image.SaveAs(Server.MapPath("~/images/" + imgName));
                    //set db image path name
                    tblCoin.Image_Path = imgName;

                    if (ModelState.IsValid)
                    {
                        db.tblCoins.Add(tblCoin);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }


            ViewBag.Composition_ID = new SelectList(db.tblCoinCompositions, "Composition_ID", "Composition_Description", tblCoin.Composition_ID);
            ViewBag.Type_ID = new SelectList(db.tblCoinTypes, "Type_ID", "Type_Description", tblCoin.Type_ID);
            return View(tblCoin);
        }

        // GET: Coins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCoin tblCoin = db.tblCoins.Find(id);
            if (tblCoin == null)
            {
                return HttpNotFound();
            }
            ViewBag.Composition_ID = new SelectList(db.tblCoinCompositions, "Composition_ID", "Composition_Description", tblCoin.Composition_ID);
            ViewBag.Type_ID = new SelectList(db.tblCoinTypes, "Type_ID", "Type_Description", tblCoin.Type_ID);
            return View(tblCoin);
        }

        // POST: Coins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Coin_ID,Type_ID,Composition_ID,Coin_Name,Coin_Description,Purchase_Date,Purchase_Amount,Face_Value,Image_Path,Coin_Weight")] tblCoin tblCoin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCoin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Composition_ID = new SelectList(db.tblCoinCompositions, "Composition_ID", "Composition_Description", tblCoin.Composition_ID);
            ViewBag.Type_ID = new SelectList(db.tblCoinTypes, "Type_ID", "Type_Description", tblCoin.Type_ID);
            return View(tblCoin);
        }

        // GET: Coins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCoin tblCoin = db.tblCoins.Find(id);
            if (tblCoin == null)
            {
                return HttpNotFound();
            }
            return View(tblCoin);
        }

        // POST: Coins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCoin tblCoin = db.tblCoins.Find(id);
            db.tblCoins.Remove(tblCoin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //not working currently
        //public void DeletePicture(int id)
        //{
        //    tblCoin tblCoin = db.tblCoins.Find(id);
        //    string imgName = tblCoin.Image_Path;


        //    try
        //    {
        //        var filePath = Server.MapPath("~/images/" + imgName);
        //        System.IO.File.Delete(filePath);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine("--------------------------------------");
        //        Debug.WriteLine(e);
        //        Debug.WriteLine(e.Message);
        //    }
        //}
    }
}
