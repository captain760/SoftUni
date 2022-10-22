using Microsoft.AspNetCore.Mvc;
using TBApp.Data;
using TBApp.Models;

namespace TBApp.Controllers
{
    public class BoardsController:Controller
    {
        private readonly ApplicationDbContext data;
        public BoardsController(ApplicationDbContext context)
        {
            this.data = context;
        }
        public IActionResult All()
        {
            var boards = this.data.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new Models.Task.TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })

                })
                .ToList();
            return View(boards);
        }
    }
}
