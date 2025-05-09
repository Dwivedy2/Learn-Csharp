using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Constants.Enums;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeSkills> EmployeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                    new TodoItem { Id = Guid.NewGuid(), Title = "Configure EF seed data", IsCompleted = false, DateCreated = DateTime.Now },
                    new TodoItem { Id = Guid.NewGuid(), Title = "Make your first GET request", IsCompleted = false, DateCreated = DateTime.Now },
                    new TodoItem { Id = Guid.NewGuid(), Title = "Test your first GET request", IsCompleted = false, DateCreated = DateTime.Now }
                );

            modelBuilder.Entity<Employee>().HasData(
                    new Employee { Id = 1, Age = 25, Email = "aman.ojha@test.com", Name = "Aman Ojha", Role = Roles.Developer },
                    new Employee { Id = 2, Age = 24, Email = "ravina.ghidode@test.com", Name = "Ravina Ghidode", Role = Roles.Developer },
                    new Employee { Id = 3, Age = 25, Email = "gagan.sharma@test.com", Name = "Gagan Sharma", Role = Roles.Devops },
                    new Employee { Id = 4, Age = 27, Email = "mayank.joshi@test.com", Name = "Mayank Joshi", Role = Roles.Devops },
                    new Employee { Id = 5, Age = 29, Email = "satyam.chouksey@test.com", Name = "Satyam Chouksey", Role = Roles.QA },
                    new Employee { Id = 6, Age = 25, Email = "niharika.gupta@test.com", Name = "Niharika Gupta", Role = Roles.QA },
                    new Employee { Id = 7, Age = 25, Email = "praduman.dwivedy@test.com", Name = "Prduman Dwivedy", Role = Roles.Manager }
                );

            modelBuilder.Entity<Skill>(b =>
            {
                b.HasData(
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = ".NET" },
                        new Skill { Id = 3, Name = "Java" },
                        new Skill { Id = 4, Name = "React" },
                        new Skill { Id = 5, Name = "Angular" },
                        new Skill { Id = 6, Name = "Tosca" },
                        new Skill { Id = 7, Name = "Selenium" },
                        new Skill { Id = 8, Name = "Azure" },
                        new Skill { Id = 9, Name = "Linux" },
                        new Skill { Id = 10, Name = "SonarQube" }
                    );
            });

            modelBuilder.Entity<Project>(b =>
            {
                b.HasData(
                        new Project { Id = 1, Name = "REX-Replatform" },
                        new Project { Id = 2, Name = "Omnia" },
                        new Project { Id = 3, Name = "Levvia" },
                        new Project { Id = 4, Name = "DocTime" }
                    );
            });

            modelBuilder.Entity<EmployeeSkills>(b =>
            {
                b.HasKey(es => es.Id);
                b.HasData(
                    // Aman Ojha (Developer) - C#, .NET
                    new EmployeeSkills { Id = 1, SkillId = 1, EmployeeId = 1 },
                    new EmployeeSkills { Id = 2, SkillId = 2, EmployeeId = 1 },

                    // Ravina Ghidode (Developer) - C#, React
                    new EmployeeSkills { Id = 3, SkillId = 1, EmployeeId = 2 },
                    new EmployeeSkills { Id = 4, SkillId = 4, EmployeeId = 2 },

                    // Gagan Sharma (DevOps) - Linux, Azure
                    new EmployeeSkills { Id = 5, SkillId = 9, EmployeeId = 3 },
                    new EmployeeSkills { Id = 6, SkillId = 8, EmployeeId = 3 },

                    // Mayank Joshi (DevOps) - Linux, SonarQube
                    new EmployeeSkills { Id = 7, SkillId = 9, EmployeeId = 4 },
                    new EmployeeSkills { Id = 8, SkillId = 10, EmployeeId = 4 },

                    // Satyam Chouksey (QA) - Tosca, Selenium
                    new EmployeeSkills { Id = 9, SkillId = 6, EmployeeId = 5 },
                    new EmployeeSkills { Id = 10, SkillId = 7, EmployeeId = 5 },

                    // Niharika Gupta (QA) - Selenium
                    new EmployeeSkills { Id = 11, SkillId = 7, EmployeeId = 6 },

                    // Prduman Dwivedy (Manager) - .NET, Azure
                    new EmployeeSkills { Id = 12, SkillId = 2, EmployeeId = 7 },
                    new EmployeeSkills { Id = 13, SkillId = 8, EmployeeId = 7 }
                );
            });


            modelBuilder.Entity<EmployeeSkills>()
                .HasOne(es => es.Employee)
                .WithMany(es => es.EmployeeSkills)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<EmployeeSkills>()
                .HasOne(es => es.Skill)
                .WithMany(es => es.EmployeeSkills)
                .HasForeignKey(es => es.SkillId);

            modelBuilder.Entity<EmployeeProjects>(b =>
            {
                b.HasKey(ep => ep.Id);
                b.HasData(
                    // Aman Ojha (Developer) - REX-Replatform
                    new EmployeeProjects { Id = 1, EmployeeId = 1, ProjectId = 1 },

                    // Ravina Ghidode (Developer) - Omnia
                    new EmployeeProjects { Id = 2, EmployeeId = 2, ProjectId = 2 },

                    // Gagan Sharma (DevOps) - REX-Replatform
                    new EmployeeProjects { Id = 3, EmployeeId = 3, ProjectId = 1 },

                    // Mayank Joshi (DevOps) - Omnia
                    new EmployeeProjects { Id = 4, EmployeeId = 4, ProjectId = 2 },

                    // Satyam Chouksey (QA) - Levvia
                    new EmployeeProjects { Id = 5, EmployeeId = 5, ProjectId = 3 },

                    // Niharika Gupta (QA) - DocTime
                    new EmployeeProjects { Id = 6, EmployeeId = 6, ProjectId = 4 },

                    // Prduman Dwivedy (Manager) - manages all projects
                    new EmployeeProjects { Id = 7, EmployeeId = 7, ProjectId = 1 },
                    new EmployeeProjects { Id = 8, EmployeeId = 7, ProjectId = 2 },
                    new EmployeeProjects { Id = 9, EmployeeId = 7, ProjectId = 3 },
                    new EmployeeProjects { Id = 10, EmployeeId = 7, ProjectId = 4 }
                );
            });

            modelBuilder.Entity<EmployeeProjects>()
                .HasOne(ep => ep.Employee)
                .WithMany(ep => ep.EmployeeProjects)
                .HasForeignKey(es => es.EmployeeId);

            modelBuilder.Entity<EmployeeProjects>()
                .HasOne(es => es.Project)
                .WithMany(es => es.EmployeeProjects)
                .HasForeignKey(es => es.ProjectId);
        }
    }
}
