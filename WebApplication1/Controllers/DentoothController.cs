using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class DentoothController : Controller
    {
        private readonly ApplicationDBContext _db;

        public DentoothController(ApplicationDBContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            //return Content("Dental");


            //Dentooth D1 = new Dentooth();
            IEnumerable<Dentooth> allD = _db.Dentals;
            

            return View(allD);
        }
        public IActionResult Details()
        {
           // return Content("list Dental");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Dentooth obj)
        {
            _db.Dentals.Add(obj);
            _db.SaveChanges();
            // return Content("list Dental");
            return RedirectToAction("Index");
        }
        public IActionResult API()
        {
            // return Content("list Dental");
            string strurl = String.Format("https://jsonplaceholder.typicode.com/posts");
            var result = "";
            WebRequest requestobjPost = WebRequest.Create(strurl);
            requestobjPost.Method = "POST";
            requestobjPost.ContentType = "application/json";

            String postData = "{\"title\":\"testData\",\"body\":\"testBody\",\"UserId\":\"50\"}";
            using (var streamWriter = new StreamWriter(requestobjPost.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)requestobjPost.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) 
                {
                   result = streamReader.ReadToEnd();
                }
            }
                return Content(result);
        }
        public IActionResult Edit(int id)
        {
            if(id==null || id==0)
            { return NotFound(); }
            var obj = _db.Dentals.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dentooth obj)
        {
            _db.Dentals.Update(obj);
            _db.SaveChanges();
            // return Content("list Dental");
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            { return NotFound(); }
            var obj = _db.Dentals.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Dentals.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
