using David.SecondBook.OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace David.SecondBook.OnlineStore.Test.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("started.");

            EFDbContext rep;
            using (rep = new EFDbContext())
            {
                rep.ProductsList.RemoveRange(rep.ProductsList);

                for (int i = 0; i < 8; i++)
                {
                    var p = new Product()
                    {
                        Name = "Book " + i,
                        Price = 100m + i,
                        Description = "Book description " + i,
                    };

                    rep.ProductsList.Add(p);

                }

                rep.SaveChanges();


                foreach (var item in rep.ProductsList)
                {
                    Console.WriteLine(item.Name);
                }
            }

            Console.WriteLine("closing...");

            Console.ReadKey();
        }
    }
}
