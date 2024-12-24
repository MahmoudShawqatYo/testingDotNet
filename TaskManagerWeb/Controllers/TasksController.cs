using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManagerWeb.Models; // Keep this

namespace TaskManagerWeb.Controllers
{
    public class TasksController : Controller
    {
        private static List<TaskManagerWeb.Models.Task> tasks = new List<TaskManagerWeb.Models.Task>(); // Fully qualified name
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskManagerWeb.Models.Task task) // Fully qualified name
        {
            task.Id = nextId++;
            task.CreatedAt = DateTime.Now;
            tasks.Add(task);
            return RedirectToAction("Index");
        }

        public IActionResult Complete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }
    }
}
