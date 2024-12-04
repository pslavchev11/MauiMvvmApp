using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Others;
using Welcome.Others;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logFilePath = "C:\\Users\\User\\OneDrive - Technical University of Sofia\\desktop\\PS_49b_Plamen_Slavchev\\PS_49b_Plamen_Slavchev\\logs.txt";
            var logger = new FileLogger(logFilePath);

            try
            {
                UserData userData = new UserData();

                User studentUser = new User()
                {
                    Name = "Student",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT,
                    FacultyNumber = "555111",
                    Email = "student@gmail.com"
                };

                User studentUser2 = new User()
                {
                    Name = "Student2",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT,
                    FacultyNumber = "444111",
                    Email = "student2@gmail.com"
                };

                User teacherUser = new User()
                {
                    Name = "Teacher",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR,
                    FacultyNumber = "",
                    Email = "teacher@gmail.com"
                };

                User adminUser = new User()
                {
                    Name = "Admin",
                    Password = "12345",
                    Role = UserRolesEnum.ADMIN,
                    FacultyNumber = "",
                    Email = "admin@gmail.com"
                };

                userData.AddUser(studentUser);
                userData.AddUser(studentUser2);
                userData.AddUser(teacherUser);
                userData.AddUser(adminUser);

                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();

                if (userData.ValidateCredentials(username, password, out string errMessage))
                {
                    User validUser = userData.GetUser(username, password);

                    Console.WriteLine("Logged in successfuly!");
                    Console.WriteLine(UserHelper.ToString(validUser));
                    logger.Log(LogLevel.Information, 1, $"User {validUser.Name} logged in successfully!", null, (state, e) => state);
                }
                else
                {
                    Console.WriteLine("Login error - " + errMessage);
                    logger.Log(LogLevel.Error, 2, errMessage, null, (state, e) => state);
                }
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Log);
                log(e.Message);

                logger.Log(LogLevel.Error, 3, e.Message, e, (state, e) => state);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }

            static void Log(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
