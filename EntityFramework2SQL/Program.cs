using System;
using EntityFramework2SQLLibrary;
using System.Linq;

namespace EntityFramework2SQL {
    class Program {
        static void Main(string[] args) {

            using (var context = new PRSContext()) {

                //var request = new Request() {
                //    Id = 0,
                //    Description = "Another New Request",
                //    Justification = "I Don't Need One...",
                //    RejectReason = null,
                //    DeliveryMode = "Pickup",
                //    Status = "NEW",
                //    Total = 0,
                //    UserId = context.Users.SingleOrDefault(u => u.Username.Equals("testuser1")).Id
                //};
                //context.Request.Add(request);

                //read for request(with lines) print off desc and total, then print lines associated with it (price product quantity)


                //var product = new Products() {
                //    Id = 0,
                //    Name = "NewProd",
                //    PartNbr = "45hg",
                //    Price = 10,
                //    Unit = "each",
                //    PhotoPath = null,
                //    VendorId = 2

                //};
                //context.Products.Add(product);

                //var requestlinenew = new RequestLine() {
                //    Id = 0,
                //    RequestId = 6,
                //    ProductId = 10,
                //    Quantity = 2
                //};
                //context.RequestLine.Add(requestlinenew);
                var dbRequest = context.Request.Find(6);

                dbRequest.Total = dbRequest.RequestLine.Sum(l => l.Product.Price * l.Quantity);

                Console.WriteLine($"{dbRequest.Description} {dbRequest.Status} {dbRequest.Total.ToString("C")}");
                dbRequest.RequestLine.ToList().ForEach(r1 => {
                    Console.WriteLine($"{r1.Product.Name,-10} {r1.Quantity,5} {r1.Product.Price.ToString("C"),10}, {(r1.Product.Price * r1.Quantity).ToString("C"),11}");
                });

                var GrandTotal = context.Request.Sum(r => r.Total);
                    Console.WriteLine(GrandTotal);
                

                

               // context.Request.Remove(dbRequest);
                

               context.SaveChanges();

                var vendor = context.Vendors.Find(1);

            Console.WriteLine($"{vendor.Code} {vendor.Name}");


                //var users = context.Users.ToList();
                var users = from u in context.Users.ToList()
                            where u.Username.Contains("A") || u.Username.Contains("0")
                            select u;

            foreach(var user in  users) {
                Console.WriteLine($"{user.Username} {user.Firstname} {user.Lastname}");
            }


            }
        }
    }
}
