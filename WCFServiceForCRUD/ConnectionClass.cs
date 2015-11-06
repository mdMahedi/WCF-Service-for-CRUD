using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WCFServiceForCRUD
{
    public class ConnectionClass
    {
        public static SqlConnection ProductDbConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PracticeDBConn"].ConnectionString;
            SqlConnection conn=new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        public List<Product> GetAllProduct()
        {
            string quary = "select * from ProductDB.dbo.Product";
            SqlDataAdapter adapter = new SqlDataAdapter(quary, ProductDbConnection());
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<Product> products=new List<Product>();
            foreach (DataRow i in dt.Rows)
            {
                Product pr=new Product();
                pr.productId = Convert.ToInt32(i["productId"]);
                pr.productName = (i["productName"]).ToString();
                pr.productPrice = Convert.ToDecimal(i["productPrice"]);
                pr.productQuantity = Convert.ToInt32(i["productQuantity"]);
                products.Add(pr);
            }
            return products;
        }
        //public DataTable GetProduct(int id)
        //{
        //    string quary = "select * from ProductDB.dbo.Product where productId='" + id + "'";
        //    SqlDataAdapter adapter = new SqlDataAdapter(quary, ProductDbConnection());
        //    DataTable dt=new DataTable();
        //    adapter.Fill(dt);
        //    return dt;
        //}

        public List<Product> SearchProduct(int id)
        {
            string quary = "select * from ProductDB.dbo.Product where productId='" + id + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(quary, ProductDbConnection());
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<Product> products = new List<Product>();
            foreach (DataRow i in dt.Rows)
            {
                Product pr = new Product();
                pr.productId = Convert.ToInt32(i["productId"]);
                pr.productName = (i["productName"]).ToString();
                pr.productPrice = Convert.ToDecimal(i["productPrice"]);
                pr.productQuantity = Convert.ToInt32(i["productQuantity"]);
                products.Add(pr);
            }
            return products;
        }

        public bool InsertProduct(int id, string name, decimal price, int quantity)
        {
            string quary = "Insert Into ProductDB.dbo.Product values ('" + id + "','" + name + "','" + price + "','" +
                           quantity + "')";
            SqlCommand command=new SqlCommand(quary, ProductDbConnection());
            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateProduct(int id, string name, decimal price, int quantity)
        {
            string quary = "Update ProductDB.dbo.Product set [productName]='"+name+"', [productPrice]='"+price+"',[productQuantity]='"+quantity+"' Where [productId]='"+id+"'";
            SqlCommand command = new SqlCommand(quary, ProductDbConnection());
            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            string quary = "Delete from ProductDB.dbo.Product Where [productId]='" + id + "'";
            SqlCommand command=new SqlCommand(quary,ProductDbConnection());
            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}