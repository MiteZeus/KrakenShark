using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    public class Product
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public Product(int id, string name, decimal price, int stock)
        {
            ID = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Product()
        {
            ID = 0;
            Name = null;
            Price = 0;
            Stock = 0;
        }

        public List<Product> Show()
        {
            List<Product> product = new List<Product>();
            string connection = "Data Source = DESKTOP-85PFVUK; Database = Shop; Integrated Security = true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand("Select * from Product;", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                using (rdr)
                {
                    while (rdr.Read())
                    {
                        Product products = new Product();
                        products.id = rdr.GetInt32(0);
                        products.name = rdr.GetString(1);
                        products.price = rdr.GetDecimal(2);
                        products.stock = rdr.GetInt32(3);
                        product.Add(products);
                    }                
                }
                return product;
            }
        }
        public void AddProduct(Product product)
        {
            string connection = "Data Source = DESKTOP-85PFVUK; Database = Shop; Integrated Security = true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand("insert into Product(id, name, price, stock) values(@id, @name, @price, @stock)", con);
                cmd.Parameters.AddWithValue("@id", product.ID);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(int id)
        {
            string connection = "Data Source = DESKTOP-85PFVUK; Database = Shop; Integrated Security = true";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand("Delete from Product where id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }


        public override string ToString()
        {
            return id.ToString() + " " + name.ToString() + " " + price.ToString() + " " + stock.ToString();
        }
    }
}
