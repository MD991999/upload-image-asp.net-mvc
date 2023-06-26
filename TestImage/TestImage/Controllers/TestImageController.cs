using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestImage.Models;

namespace TestImage.Controllers
{
    public class TestImageController : Controller
    {
        // GET: TestImage
        public ActionResult Index()
        {
            using(Model1 Model1 = new Model1())
            {

                return View(Model1.Tblimages.ToList());

            }
        }
        [HttpGet]
        public ActionResult Create() {
            return View();

        }
        [HttpPost]
        public ActionResult Create(Tblimage Tblimage) {
            if (Tblimage.ImageFile != null) {
                string fileName = Path.GetFileNameWithoutExtension(Tblimage.ImageFile.FileName);
                string extension = Path.GetExtension(Tblimage.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                Tblimage.Image = "../Image/" + fileName;//here Image represent the folder that we have created .we save the uploaded images into this folder in server side.

                fileName = Path.Combine(Server.MapPath("../Image/"), fileName);
                Tblimage.ImageFile.SaveAs(fileName);//this method is used to save te uploaded image into the folder that we have created(Image) in the server side.
                using (Model1 Model1 = new Model1())
                {
                    Model1.Tblimages.Add(Tblimage);
                    Model1.SaveChanges();//this method is callled to save the changes that has happened in the database
                }
                ModelState.Clear();//this is to clear the error and previous data from the view part
            }
            return RedirectToAction("Index");

        }
    }
}