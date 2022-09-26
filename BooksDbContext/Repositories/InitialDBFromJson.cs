using BooksDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BooksDbContext.Repositories
{
    public class InitialDBFromJson
    {
        BooksDbContext db;
        public InitialDBFromJson()
        {
            db = new BooksDbContext();
        }
        public void InitalDB()
        {
            string User_File = File.ReadAllText("Defult_Users.json");
            var Convert_FileToList = JsonSerializer.Deserialize<List<User>>(User_File);
            UsersRepository usersRepository = new UsersRepository();
            usersRepository.addUsers(Convert_FileToList);
        }
    }
}
