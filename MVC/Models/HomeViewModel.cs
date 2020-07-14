using System.Collections.Generic;
using MVC.Data;

namespace MVC.Models
{
    public class HomeViewModel
    {
        public List<Subreddit> Subreddits { get; set; }
        public Subreddit NewSubreddit { get; set; }
    }
}