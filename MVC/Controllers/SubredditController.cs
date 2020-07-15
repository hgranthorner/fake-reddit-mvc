using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class SubredditController : Controller
    {
        private readonly AppDbContext _context;
        private const string SubredditId = "SubredditId";

        public SubredditController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            try
            {
                HttpContext.Session.SetInt32(SubredditId, id);
                var vm = new SubredditViewModel
                {
                    Posts = _context.Posts.Where(p => p.Subreddit.Id == id).ToList(),
                    Subreddit = _context.Subreddits.Find(id),
                    SelectedId = id
                };
                return View(vm);
            }
            catch (ArgumentNullException e)
            {
                return RedirectToPage("Home");
            }
        }

        public IActionResult AddPost(SubredditViewModel model)
        {
            var id = HttpContext.Session.GetInt32(SubredditId);

            if (!id.HasValue) return RedirectToPage("Home");

            if (!ModelState.IsValid) return RedirectToAction("Index", new {id});
            model.NewPost.SubredditId = id.GetValueOrDefault();
            _context.Add(model.NewPost);
            _context.SaveChanges();

            return RedirectToAction("Index", new {id});
        }
    }
}