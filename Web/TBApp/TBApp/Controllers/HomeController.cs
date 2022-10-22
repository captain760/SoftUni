using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TBApp.Data;
using TBApp.Models;

namespace TBApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext data;
        public HomeController(ApplicationDbContext context)
        {
            this.data = context;
        }
        public IActionResult Index()
        {
            var taskBoards = this.data
                .Boards
                .Select(b => b.Name)
                .Distinct();

            var tasksCounts = new List<HomeBoardModel>();
            foreach (var boardGame in taskBoards)
            {
                var tasksInBoard = this.data.Tasks.Where(t => t.Board.Name == boardGame).Count();
                tasksCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardGame,
                    TasksCount = tasksInBoard
                });
            }

            var userTasksCount = -1;
            if (this.User.Identity.IsAuthenticated)
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTasksCount = this.data.Tasks.Where(t=>t.OwnerId == currentUserId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = this.data.Tasks.Count(),
                BoardsWithTasksCount = tasksCounts,
                UserTasksCount = userTasksCount
            };
            return View(homeModel);
        }

        
    }
}