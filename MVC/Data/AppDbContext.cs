using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC.Data
{
    public class AppDbContext : DbContext
    {
        public const string ConnectionString = "Data Source=fake_reddit.db";

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Subreddit> Subreddits { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(ConnectionString);
    }

    public class Subreddit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
        public virtual ICollection<Comment> Children { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int SubredditId { get; set; }

        public virtual Subreddit Subreddit { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}