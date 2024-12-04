using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Database;
using DataLayer.Model;

namespace DataLayer.Services
{
    public class DataService
    {
        public static List<DatabaseUser> findAllUsers()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Users.ToList();
            }
        }

        public static List<LogEntity> findAllLogs()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Logs.ToList();
            }
        }
    }
}
