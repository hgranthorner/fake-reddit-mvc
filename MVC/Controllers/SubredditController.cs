using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class SubredditController : Controller
    {
        private readonly AppDbContext _context;

        public SubredditController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            return View(CreateVM(id));
        }

        public IActionResult AddPost(SubredditViewModel model)
        {
            model.Subreddit = _context.Subreddits.Find(2);
            if (ModelState.IsValid)
            {
                _context.Add(model.NewPost);
                _context.SaveChanges();
            }

            return View("Index", CreateVM(2));
        }

        private SubredditViewModel CreateVM(int id) =>
            new SubredditViewModel
            {
                Posts = _context.Posts.Where(p => p.Subreddit.Id == id).ToList(),
                Subreddit = _context.Subreddits.Find(id)
            };
    }
}