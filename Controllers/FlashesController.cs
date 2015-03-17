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
    public class FlashesController : Controller
    {
        // private ItemContext db = new ItemContext();
        private IFlashRepository flashRepository;
        private IReviewReository reviewReository;
        private static int ThisID = 0;

        public FlashesController()
        {
            this.flashRepository = new FlashRepository(new ItemContext());
        }
        public FlashesController(IFlashRepository flashRepository)
        {
            this.flashRepository = flashRepository;
        }


        // GET: Flashs
        public ViewResult Index()
        {
            return View(flashRepository.GetFlash());
        }

        // GET: Flashs/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flash flash = flashRepository.GetFlashByID(id); ;
            if (flash == null)
            {
                return HttpNotFound();
            }
            


            try
            {

                var AllReviews = reviewReository.GetReviews();

                foreach (var thisFlashesReview in AllReviews)
                    if (thisFlashesReview.ItemID == flash.ID)
                        //reviewReository.InsertReview(thisFlashsReview);
                        flash.reviews.Add(thisFlashesReview);

            }
            catch (Exception ex)
            {

            }



            return View(flash);
        }





        //Add Comments********************************************************************************
        // GET
        public ActionResult AddReview(int id)
        {

            if (id == null)     // if no id was passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flash flash = flashRepository.GetFlashByID(id);
            if (flash == null)
            {
                return HttpNotFound();
            }
            ThisID = flash.ID;
            ViewBag.FlashMake = flash.Make;
            ViewBag.Model = flash.Model;
            ViewBag.Picture = flash.Picture;
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
                Flash flash = flashRepository.GetFlashByID(ThisID);
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

        // GET: Flashs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flashs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Class,Make,Model,ShutterSpeed,PowerReq,Dimensions,Weight,Finish,Brightness,Picture")] Flash flash)
        {
            if (ModelState.IsValid)
            {
                flashRepository.InsertFlash(flash);
                flashRepository.Save();
                return RedirectToAction("Index");
            }

            return View(flash);
        }

        // GET: Flashs/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flash flash = flashRepository.GetFlashByID(id);
            if (flash == null)
            {
                return HttpNotFound();
            }
            return View(flash);
        }

        // POST: Flashs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Class,Make,Model,ShutterSpeed,PowerReq,Dimensions,Weight,Finish,Brightness,Picture")] Flash flash)
        {
            if (ModelState.IsValid)
            {
                flashRepository.UpdateFlash(flash);
                flashRepository.Save();
                return RedirectToAction("Index");
            }
            return View(flash);
        }

        // GET: Flashs/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flash flash = flashRepository.GetFlashByID(id);
            if (flash == null)
            {
                return HttpNotFound();
            }
            return View(flash);
        }

        // POST: Flashs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flash flash = flashRepository.GetFlashByID(id);
            flashRepository.DeleteFlash(id);
            flashRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                flashRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
