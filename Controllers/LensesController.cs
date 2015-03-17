using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Narcosis101.DAL;
using Narcosis101.Models;


namespace Narcosis101.Controllers
{
    public class LensesController : Controller
    {
        // private ItemContext db = new ItemContext();
        private ILensRepository lenseRepository;
        private IReviewReository reviewReository;
        private static int ThisID = 0;

        public LensesController()
        {
            this.lenseRepository = new LenseRepository(new ItemContext());
        }
        public LensesController(ILensRepository lenseRepository)
        {
            this.lenseRepository = lenseRepository;
        }


        // GET: Lensees
        public ViewResult Index()
        {
            return View(lenseRepository.GetLenss());
        }

        // GET: Lensees/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lens = lenseRepository.GetLensByID(id); ;
            if (lens == null)
            {
                return HttpNotFound();
            }
            

            try
            {

                var AllReviews = reviewReository.GetReviews();

                foreach (var thisLensesReview in AllReviews)
                    if (thisLensesReview.ItemID == lens.ID)
                        //reviewReository.InsertReview(thisLensesReview);
                        lens.reviews.Add(thisLensesReview);

            }
            catch (Exception ex)
            {

            }



            return View(lens);
        }





        //Add Comments********************************************************************************
        // GET
        public ActionResult AddReview(int id)
        {

            if (id == null)     // if no id was passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lens = lenseRepository.GetLensByID(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            ThisID = lens.ID;
            ViewBag.LensMake = lens.Make;
            ViewBag.Model = lens.Model;
            ViewBag.Picture = lens.Picture;
            return View();
        }



        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview([Bind(Include = "Name,ReviewText, ItemID")] Review Review)
        {
            try
            { 
            if (ModelState.IsValid)
            {
                Lense lense = lenseRepository.GetLensByID(ThisID);
                Review.ItemID = ThisID;

                reviewReository.InsertReview(Review);
                reviewReository.Save();
                return RedirectToAction("Index");
            }
            }
            catch (Exception ex)
            {

            }

            return View(Review);
        }


        //-----------------------------------------------------------------------------------
        //------------------------------------------------------------------------
        //-----------------------------------------------------------

        // GET: Lensees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lensees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Class,Make,Model,ShutterSpeed,PowerReq,Dimensions,Weight,Finish,ExposureMeter,ExposureControl,Millimeters,Fnum,FilterSize,Picture")] Lense lens)
        {
            if (ModelState.IsValid)
            {
                lenseRepository.InsertLens(lens);
                lenseRepository.Save();
                return RedirectToAction("Index");
            }

            return View(lens);
        }

        // GET: Lensees/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lens = lenseRepository.GetLensByID(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            return View(lens);
        }

        // POST: Lensees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Class,Make,Model,ShutterSpeed,PowerReq,Dimensions,Weight,Finish,ExposureMeter,ExposureControl,Millimeters,Fnum,FilterSize,Picture")] Lense lens)
        {
            if (ModelState.IsValid)
            {
                lenseRepository.UpdateLens(lens);
                lenseRepository.Save();
                return RedirectToAction("Index");
            }
            return View(lens);
        }

        // GET: Lensees/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lense lens = lenseRepository.GetLensByID(id);
            if (lens == null)
            {
                return HttpNotFound();
            }
            return View(lens);
        }

        // POST: Lensees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lense lens = lenseRepository.GetLensByID(id);
            lenseRepository.DeleteLens(id);
            lenseRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                lenseRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
