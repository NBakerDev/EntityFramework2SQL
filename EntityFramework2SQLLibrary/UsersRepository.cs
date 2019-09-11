using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace EntityFramework2SQLLibrary {
   public class UsersRepository {

        private static PRSContext context = new PRSContext();

        public static List<Users> GetAll() {
            return context.Users.ToList();
        }

        public static Users GetByPk(int id) {
            if (id > 0) {
                return context.Users.Find(id);
            }
            else throw new Exception("Must Be Greater Than 0!");
        }

        public static bool Insert(Users user) {
            if (user == null) { throw new Exception("Can't Be NULL"); }
            user.Id = 0;
            context.Users.Add(user);

            return context.SaveChanges() == 1;
        }

        public static bool Update(Users user) {
            if (user == null) { throw new Exception("Can't Be NULL"); }
            var upduser = context.Users.Find(user.Id);
            if (user == null) { throw new Exception("No user with that Id"); }
            upduser.Username = user.Username;
            upduser.Password = user.Password;
            upduser.Phone = user.Phone;
            upduser.Firstname = user.Firstname;
            upduser.Email = user.Email;
            upduser.IsAdmin = user.IsAdmin;
            upduser.IsReviewer = user.IsReviewer;
            return context.SaveChanges() == 1;
        }

        public static bool Delete(Users user) {
            if (user == null) { throw new Exception("Can't Be NULL"); }
            var dbuser = context.Users.Find(user.Id);
            if (dbuser == null) { throw new Exception("No User with Id"); }
            context.Users.Remove(dbuser);
            return context.SaveChanges() == 1;
        }

        public static bool Delete(int id) {
            var user = context.Users.Find(id);
            if(user == null) { return false; }
            var rc = Delete(user);
            return rc;
        }

        //Do it for Vendors
    }
}
