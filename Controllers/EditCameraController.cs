using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Narcosis101.Models;
using Narcosis101.DAL;

namespace Narcosis101.Controllers
{
    public class EditCameraController : Controller
    {
        // GET: EditCamera
        public ActionResult Index()
        {
           ItemContext db = new ItemContext();
            //var authors = db.Authors.Include("Books");
            var cameras = from c in db.Cameras.Include("Items")
                          where c.Class == "c"
                          select c;

            // Just copying from the entity models to the view model
            var vmList = new List<CameraViewModel>();
            foreach(Camera c in cameras)
            {
   
                foreach(Item i in c.Items)
                {
                    vmList.Add(new CameraViewModel() {
                                Lens = c.Lens,
                                Item = new ItemViewModel() { }
                                });
                }
            }

            return View(vmList);
           }
        }
}