using System.Collections.Generic;
using MVC.Data;

namespace MVC.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment NewComment { get; set; }
    }
}