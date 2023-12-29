using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBContext _context = new MVCCRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Branches.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch Model) 
        {
            _context.Branches.Add(Model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        { 
            var data = _context.Branches.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Branch Model) 
        {
            var data = _context.Branches.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null) 
            {
                data.Id = Model.Id;
                data.Name = Model.Name;
                data.Description = Model.Description;
                data.City_id = Model.City_id;
            }
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id) 
        {
            var data = _context.Branches.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id) 
        {
            var data = _context.Branches.Where(x => x.Id == id).FirstOrDefault();
            _context.Branches.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Deleted Successfully";
            return RedirectToAction("index");


        }
    }
}