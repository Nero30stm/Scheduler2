using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShedulerWebApp.Models;

namespace ShedulerWebApp.Controllers
{
    [Route("tasks")]
    public class TaskController : Controller
    {
        private readonly DataBaseContext _context;

        public TaskController(DataBaseContext context)
        {
            _context = context;
        }

        [Route("GetTasks", Name = "GetTasks")]
        public IActionResult GetTasks()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        [Route("EditTasks", Name = "EditTasks")]
        public IActionResult EditTasks(Task task)
        {
            // _context.Tasks.Add(new Task { Header = "task3", Description = "111"});
            // _context.SaveChanges();
            //var tasks = _context.Tasks.ToList();
            return View();
        }

        [Route("AddTask", Name = "AddTask")]
        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [Route("AddTask", Name = "AddTask")]
        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Redirect("GetTasks");
        }


        [HttpPost("Delete/{id}", Name = "Delete")]
        public ActionResult Delete(int id)
        {
            Task task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return Redirect("../GetTasks");
        }

        [Route("EditTask", Name = "EditTask")]
        [HttpGet]
        public IActionResult EditTask()
        {
            return View();
        }

        [Route("EditTask", Name = "EditTask")]
        [HttpPost]
        public IActionResult EditTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Redirect("GetTasks");
        }
    }
}