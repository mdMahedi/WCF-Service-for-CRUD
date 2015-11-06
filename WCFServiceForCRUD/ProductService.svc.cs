using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceForCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        //public void DoWork()
        //{
        //}
        ConnectionClass connection=new ConnectionClass();
        public List<Product> SelectAllProducts()
        {
            return connection.GetAllProduct();
        }

        public List<Product> SearchProducts(int id)
        {
            return connection.SearchProduct(id).ToList();
        }

        public bool AddProducts(Product pd)
        {
            if (connection.InsertProduct(pd.productId, pd.productName, pd.productPrice, pd.productQuantity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditProducts(Product pd)
        {
            if (connection.UpdateProduct(pd.productId, pd.productName, pd.productPrice, pd.productQuantity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProducts(Product pd)
        {
            if (connection.DeleteProduct(pd.productId))
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
