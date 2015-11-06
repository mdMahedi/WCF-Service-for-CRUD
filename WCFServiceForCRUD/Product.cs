using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServiceForCRUD
{
    [DataContract(Namespace = "")]
    public class Product
    {
        [DataMember(Order = 0)]
        public int productId { get; set; }
        [DataMember(Order = 1)]
        public string productName { get; set; }
        [DataMember(Order = 2)]
        public decimal productPrice { get; set; }
        [DataMember(Order = 3)]
        public int productQuantity { get; set; }
    }
}