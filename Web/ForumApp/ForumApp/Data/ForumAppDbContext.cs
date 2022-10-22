using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
        {
            this.Database.Migrate();
        }
        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }

        public DbSet<Post> Posts { get; init; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Post>()
            //    .HasMany(p => p.PostAnswers)
            //    .WithOne(r => r.Post)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>();

            SeedPosts();
            builder.Entity<Post>()
                .HasData(this.FirstPost,
                this.SecondPost,
                this.ThirdPost);

            base.OnModelCreating(builder);
        }

        private void SeedPosts()
        {
            this.FirstPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My first post will be about performing CRUD operations on MVC",
                IsDeleted = false
            };
            this.SecondPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "This is my second post. It will be about performing CRUD operations on MVC",
                IsDeleted = false
            };
            this.ThirdPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Ooooh, my third post will be about performing CRUD operations on MVC",
                IsDeleted = false
            };
        }
    }
}
