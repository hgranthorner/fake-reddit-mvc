using System.Collections.Generic;
using MVC.Data;

namespace MVC.Models
{
    public class SubredditViewModel
    {
        public Subreddit Subreddit { get; set; }
        public List<Post> Posts { get; set; }
        public Post NewPost { get; set; }
        public int SelectedId { get; set; }
    }
}