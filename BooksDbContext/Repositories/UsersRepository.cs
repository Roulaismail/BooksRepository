using BooksDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDbContext.Repositories
{
    public class UsersRepository
    {
        BooksDbContext db;
        public UsersRepository()
        {
            db = new BooksDbContext();
        }
        public bool Login(User user)
        {
            int countUsers = db.Users.Count(p => p.UserName == user
                            .UserName && p.PassWord == user.PassWord);
            return countUsers > 0;
        }
        
        public bool isUserExist(User user)
        {
            int numberUsers = db.Users.Count(p => p.UserName == user.UserName);
            return numberUsers > 0;
        }

        public bool AddUser(User user)
        {
            try
            {
                if (!isUserExist(user))
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void addUsers(List<User> users)
        {
            foreach (User item in users)
            {
                AddUser(item);
            }
        }
        
    }
}
