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
    public class CamerasController : Controller
    {
       // private ItemContext db = new ItemContext();
        private ICameraRepository cameraRepository;
        private IReviewReository reviewReository;
        private static int ThisID = 0;

      public CamerasController()
      {
         this.cameraRepository = new CameraRepository(new ItemContext());
      }
        public CamerasController(ICameraRepository cameraRepository)
      {
         this.cameraRepository = cameraRepository;
      }

        
        // GET: Cameras
        public ViewResult Index()
        {
            return View(cameraRepository.GetCameras());
        }

        // GET: Cameras/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = cameraRepository.GetCameraByID(id);;
            if (camera == null)
            {
                return HttpNotFound();
            }


            try
            {

                var AllReviews = reviewReository.GetReviews();

                foreach (var thisCamerasReview in AllReviews)
                    if (thisCamerasReview.ItemID == camera.ID)
                        //reviewReository.InsertReview(thisCamerasReview);
                        camera.reviews.Add(thisCamerasReview);

            }
            catch (Exception ex)
            {
                
            }



            return View(camera);
        }
        




        //Add Comments********************************************************************************
        // GET
        public ActionResult AddReview(int id)
        {

            if (id == null)     // if no id was passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = cameraRepository.GetCameraByID(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            ThisID = camera.ID;
            ViewBag.CameraMake = camera.Make;
            ViewBag.Model = camera.Model;
            ViewBag.Picture = camera.Picture;
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
                Camera camera = cameraRepository.GetCameraByID(ThisID);
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



        // GET: Cameras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cameras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Class,Make,Model,ShutterSpeed,PowerReq,Dimensions,Weight,Finish,Lens,ExposureMeter,ExposureControl,Picture")] Camera camera)
        {
            if (ModelState.IsValid)
            {
                cameraRepository.InsertCamera(camera);
               cameraRepository.Save();
                return RedirectToAction("Index");
            }

            return View(camera);
        }

        // GET: Cameras/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = cameraRepository.GetCameraByID(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // POST: Cameras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Class,Make,Model,ShutterSpeed,PowerReq,Dimensions,Weight,Finish,Lens,ExposureMeter,ExposureControl,Picture")] Camera camera)
        {
            if (ModelState.IsValid)
            {
                cameraRepository.UpdateCamera(camera);
               cameraRepository.Save();
                return RedirectToAction("Index");
            }
            return View(camera);
        }

        // GET: Cameras/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camera camera = cameraRepository.GetCameraByID(id);
            if (camera == null)
            {
                return HttpNotFound();
            }
            return View(camera);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camera camera = cameraRepository.GetCameraByID(id);
            cameraRepository.DeleteCamera(id);
            cameraRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cameraRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
