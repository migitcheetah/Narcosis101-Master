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
    public class ReviewController : Controller
    {
        //private DerbyContext db = new DerbyContext();
        private IReviewReository reviewRepository;

        public ReviewController()
        {
            this.reviewRepository = new ReviewRepository(new ItemContext());
        }

        public ReviewController(IReviewReository reviewRep)
        {
            this.reviewRepository = reviewRep;
        }

        //************************************************************************************
        //Index
        //************************************************************************************
        // GET: Review
        public ActionResult Index()
        {
            //return View(db.Reviews.ToList());
            return View(reviewRepository.GetReviews());
        }


        //************************************************************************************
        //Detail
        //************************************************************************************
        // GET: Review/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Review review = db.Reviews.Find(id);
            Review review = reviewRepository.GetReviewByID((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }


        //************************************************************************************
        //Create
        //************************************************************************************
        // GET: Review/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,Name,ReviewText,CarIDNum")] Review review)
        {
            //review.CarIdNum = id;

            if (ModelState.IsValid)
            {
                //db.Reviews.Add(review);
                //db.SaveChanges();
                reviewRepository.InsertReview(review);
                reviewRepository.Save();

                return RedirectToAction("Index");
            }

            return View(review);
        }


        //************************************************************************************
        //Edit
        //************************************************************************************
        // GET: Review/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Review review = db.Reviews.Find(id);
            Review review = reviewRepository.GetReviewByID((int)id);

            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Review/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,Name,ReviewText,CarIdNum")] Review review)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(review).State = EntityState.Modified;
                //db.SaveChanges();
                reviewRepository.UpdateReview(review);
                reviewRepository.Save();

                return RedirectToAction("Index");
            }
            return View(review);
        }


        //************************************************************************************
        //Delete
        //************************************************************************************
        // GET: Review/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Review review = db.Reviews.Find(id);
            Review review = reviewRepository.GetReviewByID((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Review review = db.Reviews.Find(id);
            //db.Reviews.Remove(review);
            //db.SaveChanges();
            Review review = reviewRepository.GetReviewByID((int)id);
            reviewRepository.DeleteReview((int)id);
            reviewRepository.Save();
            return RedirectToAction("Index");
        }


        //************************************************************************************
        //Dispose
        //************************************************************************************
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                reviewRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
