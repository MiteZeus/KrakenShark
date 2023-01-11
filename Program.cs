using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            Product product1 = new Product(6, "grizki", 0.80m, 17);
            List<Product> products = product.Show();
            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }
            product.DeleteProduct(int.Parse(Console.ReadLine()));
            Console.WriteLine();
            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }
            //product.UpdateProduct();
        }
    }
}
