using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Data;

namespace TestApp.Controllers
{
    public class CatogaryController : Controller
    {
        //Setting the Database to fetch
        private readonly ApplicationDBContext _db;

        public CatogaryController(ApplicationDBContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<TestApp.Models.CatogaryModel> objList = _db.Catogaries; //Fetching Table in List
            
            return View(objList); //Returning list to View
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(TestApp.Models.CatogaryModel obj) //Fetching from View using Razor
        {
            if (ModelState.IsValid) //Server side Validation
            {
                _db.Catogaries.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
           
        }


        //GET
        public IActionResult Edit(int? id)  //int is nullable "?"
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Catogaries.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(TestApp.Models.CatogaryModel obj) //Fetching from View using Razor
        {
            if (ModelState.IsValid) //Server side Validation
            {
                _db.Catogaries.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        [HttpGet]
        public IActionResult Delete(int? id)  //int is nullable "?"
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Catogaries.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int? Id,int order) 
        {
            var obj = _db.Catogaries.Find(Id);
            if (Id == null)
            {
                return NotFound();
            }
            else { 
            
                _db.Catogaries.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

        }
    }
}
