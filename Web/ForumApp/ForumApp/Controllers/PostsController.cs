using ForumApp.Data;
using ForumApp.Data.Entities;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumAppDbContext data;
        public PostsController(ForumAppDbContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            var posts = this.data.Posts
                .Where(p=>p.IsDeleted==false)
                .Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content
            })
            .ToList();
            return View(posts);
        }

        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };
            this.data.Posts.Add(post);
            this.data.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var post = this.data.Posts.Find(Id);

            return View(new PostFormModel()
            {
                Title= post.Title,
                Content = post.Content
            });
        }
        [HttpPost]
        public IActionResult Edit(int Id, PostFormModel model)
        {
            var post = this.data.Posts.Find(Id);
            post.Title = model.Title;
            post.Content = model.Content;

            this.data.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var post = this.data.Posts.Find(Id);
            post.IsDeleted = true;

            this.data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
