using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Model;
using System.Security.Cryptography.X509Certificates;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<LogEntity>().Property(e => e.Id).ValueGeneratedOnAdd();

            // Create a user
            var user = new DatabaseUser()
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = Welcome.Others.UserRolesEnum.ADMIN,
                FacultyNumber = "",
                Email = "johndoe@gmail.com",
                ExpiresDate = DateTime.Now.AddYears(10)
            };

            var user1 = new DatabaseUser()
            {
                Id = 2,
                Name = "Aniston Joe",
                Password = "12345",
                Role = Welcome.Others.UserRolesEnum.STUDENT,
                FacultyNumber = "3333",
                Email = "johndoe@gmail.com",
                ExpiresDate = DateTime.Now.AddYears(5)
            };

            var user2 = new DatabaseUser()
            {
                Id = 3,
                Name = "Ivan Mirolov",
                Password = "123456",
                Role = Welcome.Others.UserRolesEnum.PROFESSOR,
                FacultyNumber = "",
                Email = "ivanmirolov@gmail.com",
                ExpiresDate = DateTime.Now.AddYears(15)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);
            modelBuilder.Entity<DatabaseUser>().HasData(user1);
            modelBuilder.Entity<DatabaseUser>().HasData(user2);

            var log = new LogEntity()
            {
                Id = 1,
                Time = DateTime.Now,
                MessageType = "Test",
                Message = "Testing"
            };

            modelBuilder.Entity<LogEntity>().HasData(log);
        }

        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<LogEntity> Logs { get; set; }
    }
}
