using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MultipleFileUpload.Models;

namespace MultipleFileUpload.Controllers
{
    public class VisaController : Controller
    {
        private DbForm db = new DbForm();

        //
        // GET: /Support/

        public ActionResult Index()
        {
            return View(db.VisaApplications.ToList());
        }

        //
        // GET: /Support/Create

        public ActionResult Create()
        {
            return View();
        }

      

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create( VisaApplication visaApplication)
        {
            if (ModelState.IsValid)
            {
                List<Mfiles> Mlist = new List<Mfiles>();


                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        Mfiles fileDetail = new Mfiles()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        Mlist.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);
                    }

                }
                    //foreach (HttpPostedFileBase file in files)
                    //{

                    //    if (file != null && file.ContentLength > 0)
                    //    {
                    //        var fileName = Path.GetFileName(file.FileName);
                    //        Mfiles mfile = new Mfiles()
                    //        {
                    //            FileName = fileName,
                    //            Extension = Path.GetExtension(fileName),
                    //            Id = Guid.NewGuid()
                    //        };
                    //        Mlist.Add(mfile);

                    //        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), mfile.Id + mfile.Extension);
                    //        file.SaveAs(path);
                    //    }
                    //}
                    visaApplication.Status = 0;
                visaApplication.date = DateTime.Now;
                visaApplication.Mfiles = Mlist;
                db.VisaApplications.Add(visaApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visaApplication);
        }

        //
        // GET: /Support/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisaApplication support = db.VisaApplications.Include(s => s.Mfiles).SingleOrDefault(x => x.Id == id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }


        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/App_Data/Upload/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }



        //
        // POST: /Support/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VisaApplication visaApplication)
        {
            if (ModelState.IsValid)
            {

                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        Mfiles fileDetail = new Mfiles()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            SupportId = visaApplication.Id
                        };
                        var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileDetail).State = EntityState.Added;
                    }
                }

                db.Entry(visaApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visaApplication);
        }



        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                Mfiles fileDetail = db.Mfiles.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.Mfiles.Remove(fileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }





        //
        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                VisaApplication visaApp = db.VisaApplications.Find(id);
                if (visaApp == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in visaApp.Mfiles){
                    String path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.VisaApplications.Remove(visaApp);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult check()
        {
            return View();
        }
        [HttpPost]
     
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    
                    
                    foreach (HttpPostedFileBase file in files)
                    {
                        DbForm db = new DbForm();
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            Mfiles mfile = new Mfiles()
                            {
                                FileName = fileName,
                                Extension = Path.GetExtension(fileName),
                                Id = Guid.NewGuid()
                            };
                            
                            db.Mfiles.Add(mfile);
                            var path = Path.Combine(Server.MapPath("~/Images/"), mfile.Id + mfile.Extension);
                            file.SaveAs(path);
                        }
                    }
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  




                    // Checking for Internet Explorer  
                    //if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    //{
                    //    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    //    fname = testfiles[testfiles.Length - 1];
                    //}





                    // Get the complete folder path and store the file inside it.  

                
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
    }
}