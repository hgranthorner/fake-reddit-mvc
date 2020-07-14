using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private DataViewModel _dataViewModel = new DataViewModel
        {
            Datas = new List<MyData>
            {
                new MyData {Name = "Agnes", Number = 1},
                new MyData {Name = "Grant", Number = 2},
                new MyData {Name = "Matt", Number = 3},
                new MyData {Name = "Sarina", Number = 4},
                new MyData {Name = "Alyssa", Number = 5},
            },
            NewMyData = new MyData()
        };

        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(CreateVM());
        }

        public IActionResult Privacy()
        {
            return View(_dataViewModel);
        }

        public IActionResult AddData(DataViewModel model)
        {
            Console.WriteLine($"Model: {model.NewMyData.Name} - {model.NewMyData.Number}");
            if (ModelState.IsValid)
            {
                _dataViewModel.Datas.Add(model.NewMyData);
            }

            return View("Privacy", _dataViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult AddSubreddit(HomeViewModel model)
        {
            Console.WriteLine($"Name: {model.NewSubreddit.Name}");
            if (ModelState.IsValid)
            {
                _context.Add(model.NewSubreddit);
                _context.SaveChanges();
            }

            return View("Index", CreateVM());
        }

        private HomeViewModel CreateVM() => new HomeViewModel
            {Subreddits = _context.Subreddits.ToList(), NewSubreddit = new Subreddit()};
    }
}