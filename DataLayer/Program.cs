using System.Diagnostics;
using DataLayer.Database;
using DataLayer.Model;
using Welcome.Others;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();

                bool quit = false;
                while (!quit)
                {
                    string selection = displayMenu();
                    Console.WriteLine();

                    switch(selection)
                    {
                        case "1":
                            GetAllUsers(context);
                            break;
                        case "2":
                            AddNewUser(context);
                            break;
                        case "3":
                            DeleteUser(context);
                            break;
                        case "4":
                            GetAllLogEvents(context);
                            break;
                        case "5":
                            Console.WriteLine("Exiting...");
                            quit = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid selection.");
                            break;
                    }

                }
            }
        }

        static void GetAllUsers(DatabaseContext context)
        {
            var users = context.Users.ToList();
            Console.WriteLine("Listing of all users in db:");
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Role: {user.Role}, FacultyNumber: {user.FacultyNumber}, Email: {user.Email}, expires in: {user.ExpiresDate}");
            }
        }

        static void GetAllLogEvents(DatabaseContext context)
        {
            var logs = context.Logs.ToList();
            Console.WriteLine("Listing of all the events in db: ");
            foreach (var log in logs)
            {
                Console.WriteLine($"Id: {log.Id}, [{log.Time:yyyy-MM-dd HH:mm:ss}], Event Type: {log.MessageType}, Message: {log.Message}");
            }
        }

        static void AddNewUser(DatabaseContext context)
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            UserRolesEnum[] roleChoices = (UserRolesEnum[]) Enum.GetValues(typeof(UserRolesEnum));
            bool invalidRoleChoice = true;
            UserRolesEnum userRole = UserRolesEnum.ANONYMOUS;

            while (invalidRoleChoice)
            {
                Console.Write("Enter a role (");
                foreach (var role in roleChoices)
                {
                    Console.Write($"{role}, ");
                }
                Console.Write("):");

                string roleInput = Console.ReadLine();

                if (Enum.TryParse(roleInput, true, out userRole))
                {
                    invalidRoleChoice = false;
                    Console.WriteLine($"Role selection - {userRole}");
                }
                else
                {
                    Console.WriteLine("Invalid role choide.");
                }
            }

            Console.WriteLine("Enter faculty number: ");
            string facultyNumber = Console.ReadLine();

            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter months until account expiration:");
            string expiration = Console.ReadLine();

            if (int.TryParse(expiration, out int months))
            {
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = username,
                    Password = password,
                    Role = userRole,
                    FacultyNumber = facultyNumber,
                    Email = email,
                    ExpiresDate = DateTime.Now.AddMonths(months)
                });
            }
            else
            {
                Console.WriteLine("Invalid months input.");
            }

            LogEvent(context, "Added User", $"Addition of new user - {username}");

            context.SaveChanges();
            Console.WriteLine("New user added successfully!");
        }

        static void DeleteUser(DatabaseContext context)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            var userToDelete = context.Users.FirstOrDefault(user => user.Name == name);

            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);

                LogEvent(context, "Delete User", $"Deleted user with name - {name}");

                context.SaveChanges();
                Console.WriteLine("User deleted successfully!");
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        static void LogEvent(DatabaseContext context, string actionType, string message)
        {
            var logEntity = new LogEntity()
            {
                Time = DateTime.Now,
                MessageType = actionType,
                Message = message
            };

            context.Logs.Add(logEntity);
            context.SaveChanges();
        }

        static string displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Menu of commands:");
            Console.WriteLine("1 - Get list of all the users");
            Console.WriteLine("2 - Add new user");
            Console.WriteLine("3 - Delete user");
            Console.WriteLine("4 - Get list of all the event logs");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            return Console.ReadLine();
        }
    }
}
