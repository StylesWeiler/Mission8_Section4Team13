using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission8_Section4Team13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Section4Team13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TaskContext myContext { get; set; }

        public HomeController(ILogger<HomeController> logger, TaskContext somename)
        {
            _logger = logger;
            myContext = somename;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.Categories = myContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddEdit(TaskResponse ar)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(ar);
                myContext.SaveChanges();
                return View("Index", ar);
            }
            else //if it's invalid
            {
                ViewBag.Categories = myContext.Categories.ToList();
                return View(ar);
            }
        }

        [HttpGet]
        public IActionResult Edit(int FilmID)
        {
            ViewBag.Categories = myContext.Categories.ToList();

            var task = myContext.Responses.Single(x => x.taskId == FilmID);

            return View("AddEdit", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse blah)
        {
            myContext.Update(blah);
            myContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int FilmID)
        {
            var task = myContext.Responses.Single(x => x.taskId == FilmID);

            return View(task);
        }


        [HttpPost]
        public IActionResult Delete(TaskResponse ar)
        {
            myContext.Responses.Remove(ar);
            myContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        public IActionResult Quadrants()
        {
            var myTasks = myContext.Responses.
                Include(x => x.category).ToList();
            return View(myTasks);
        }

    }
}
