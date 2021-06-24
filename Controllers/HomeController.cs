using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testCrud.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testCrud.Controllers
{
    public class HomeController : Controller
    {
        AnnouncementContext db;
        public HomeController(AnnouncementContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Announcements.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            Announcement anno = db.Announcements.Find(id);
            if (anno == null)
                return RedirectToAction("Index");
            List<int> arr = new List<int>();
            int count = 0;
            for (int i = 0; i < 100; i++)
            {
                if (db.Announcements.Find(i) == null || i == id)
                    continue;
                var words1 = anno.Title.ToLower().Split(' ', '!', '.', ',', '-');
                var words2 = db.Announcements.Find(i).Title.ToLower().Split(' ', '!', '.', ',', '-');
                if (words1.Intersect(words2).Any())
                {
                    var text1 = anno.Description.ToLower().Split(' ', '!', '.', ',', '-');
                    var text2 = db.Announcements.Find(i).Description.ToLower().Split(' ', '!', '.', ',', '-');
                    if (text1.Intersect(text2).Any())
                    {
                        arr.Add(i);
                        count++;
                    }
                }
                if (count > 2)
                    break;
            }
            ViewBag.Array = arr;
            return View(anno);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Announcement anno)
        {
            db.Announcements.Add(anno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Announcement anno = db.Announcements.Find(id);
            if (anno == null)
            {
                return RedirectToAction("Index");
            }
            db.Announcements.Remove(anno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Announcement anno = db.Announcements.Find(id);
            if (anno == null)
            {
                return RedirectToAction("Index");
            }
            return View(anno);
        }
        [HttpPost]
        public ActionResult Edit(Announcement anno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anno);
        }
    }
}
