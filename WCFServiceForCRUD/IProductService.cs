﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceForCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> SelectAllProducts();
        [OperationContract]
        List<Product> SearchProducts(int id);
        [OperationContract]
        bool AddProducts(Product pd);
        [OperationContract]
        bool EditProducts(Product pd);
        [OperationContract]
        bool DeleteProducts(Product pd);
        //void DoWork();
    }
}
