﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TBApp.Data.Entities;

namespace TBApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private User GuestUser { get; set; }
        private Board OpenBoard { get; set; }
        private Board InProgressBoard{ get; set; }
        private Board DoneBoard { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Entities.Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder
                .Entity<User>()
                .HasData(this.GuestUser);

            SeedBoards();
            builder
                .Entity<Board>()
                .HasData(this.OpenBoard, this.InProgressBoard, this.DoneBoard);

            builder
                .Entity<Entities.Task>()
                .HasData(
                new Entities.Task
                {
                    Id = 1,
                    Title = "Prepare for ASP.NET Fundamentals exam",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = this.GuestUser.Id,
                    BoardId = this.OpenBoard.Id
                },
                new Entities.Task
                {
                    Id = 2,
                    Title = "Improve EF Core skills",
                    Description = "Learn using EF Core and MS SQL SMS",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = this.GuestUser.Id,
                    BoardId = this.DoneBoard.Id
                },
                new Entities.Task
                {
                    Id = 3,
                    Title = "Improve ASP.NET skills",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-10),
                    OwnerId = this.GuestUser.Id,
                    BoardId = this.InProgressBoard.Id
                },
                new Entities.Task
                {
                    Id = 4,
                    Title = "Prepare for C# Fundamentals exam",
                    Description = "Prepare for solving old Mid and Final exams",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = this.GuestUser.Id,
                    BoardId = this.DoneBoard.Id
                }
                );

            base.OnModelCreating(builder);
        }

        private void SeedBoards()
        {
            this.OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            this.InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            this.DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };

        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            this.GuestUser = new User()
            {
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Guest",
                LastName = "User"
            };
            this.GuestUser.PasswordHash = hasher.HashPassword(this.GuestUser, "guest");

        }
    }
}