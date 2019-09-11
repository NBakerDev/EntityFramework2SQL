using System;
using EntityFramework2SQLLibrary;
using System.Linq;

namespace EntityFramework2SQL {
    class Program {
        static void Main(string[] args) {

            using (var context = new PRSContext()) {

            var vendor = context.Vendors.Contains("a");

            Console.WriteLine($"{vendor.Code} {vendor.Name}");


            var users = context.Users.ToList();

            foreach(var user in users) {
                Console.WriteLine($"{user.Username} {user.Firstname} {user.Lastname}");
            }


            }
        }
    }
}
