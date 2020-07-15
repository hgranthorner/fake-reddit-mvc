using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class PostController : Controller
    {
        private const string PostId = "PostId";
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            HttpContext.Session.SetInt32(PostId, id);
            var vm = new PostViewModel
            {
                Post = _context.Posts.Find(id),
                Comments = _context.Comments.Where(c => c.Post.Id == id).ToList()
            };
            return View(vm);
        }

        public IActionResult AddComment(PostViewModel model)
        {
            var id = HttpContext.Session.GetInt32(PostId);
            if (!id.HasValue) return RedirectToPage("Home");

            model.NewComment.PostId = id.GetValueOrDefault();

            _context.Add(model.NewComment);
            _context.SaveChanges();

            return RedirectToAction("Index", new {id});
        }
    }
}