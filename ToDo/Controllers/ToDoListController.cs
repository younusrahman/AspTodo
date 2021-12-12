using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ToDoDBContext _db;

        public string searchtext { get; set; }

        public ToDoListController(ToDoDBContext? DB)
        {
            _db = DB;
        }



        public IActionResult Test(dynamic search)
        {
           
            return View();
        }
        
        public IActionResult Index()
        {
            IEnumerable<ToDoTasks> objToDoList = _db.ToDoTasks;
            return View(objToDoList);
        }     
        
        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoTasks obj)
        {
            if (ModelState.IsValid)
            {
            _db.ToDoTasks.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Task added successfully";
            return RedirectToAction("Index");
            }
            return View(obj);

            
        }


        public IActionResult Edit(int ? id)
        {
            if (id == null || id == 0) { return NotFound(); };

            var GetTaskfromDB = _db.ToDoTasks.Find(id);

            if (GetTaskfromDB == null) { return NotFound(); };
            return View(GetTaskfromDB);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToDoTasks obj)
        {
            if (ModelState.IsValid)
            {
                _db.ToDoTasks.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Task updated successfully";
                return RedirectToAction("Index");
            }


            return View(obj);


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); };

            var GetTaskfromDB = _db.ToDoTasks.Find(id);

            if (GetTaskfromDB == null) { return NotFound(); };
            _db.ToDoTasks.Remove(GetTaskfromDB);
            _db.SaveChanges();
            TempData["success"] = "Task removed successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Done(int? id)
        {
             if (id == null || id == 0) { return NotFound(); };
            var GetTaskfromDB = _db.ToDoTasks.Find(id);

            if (GetTaskfromDB == null) { return NotFound(); };
            GetTaskfromDB.ComplitedDate = DateTime.Now;
            _db.ToDoTasks.Update(GetTaskfromDB);
            _db.SaveChanges();
            TempData["success"] = "Task done successfully";
            return RedirectToAction("Index");

        } 
        
        public IActionResult Undone(int? id)
        {
             if (id == null || id == 0) { return NotFound(); };
            var GetTaskfromDB = _db.ToDoTasks.Find(id);

            if (GetTaskfromDB == null) { return NotFound(); };
            GetTaskfromDB.ComplitedDate = default(DateTime);
            _db.ToDoTasks.Update(GetTaskfromDB);
            _db.SaveChanges();
            TempData["success"] = "Task undone successfully";
            return RedirectToAction("Index");

        }


    }
}
