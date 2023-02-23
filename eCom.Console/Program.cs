using eCom.Infrastructure.Cognitive;
using eCom.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;

namespace eCom.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //InventoryDbContext db = new InventoryDbContext();

            while (true)
            {
                var command = System.Console.ReadLine();
                

                if ( !string.IsNullOrEmpty(command) )
                {
                    if (command.Trim().ToLower() == "exit")
                        break;

                    System.Console.WriteLine("Enter keywords to search products or type Exit to  close");

                    command = command.Trim().ToLower();

                    var res = Search.FindProducts(new PagingInfo(), command);

                    var drs = res.GetResults();

                    foreach (var dr in drs)
                    {
                        System.Console.WriteLine(dr.Document);
                        System.Console.WriteLine();
                    }

                    System.Console.WriteLine(res.TotalCount.ToString() + " total products found");


                }


            }



        }
    }
}