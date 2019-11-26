using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TshirtAPI.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Tshirtcolor { get; set; }
        public string Tshirtsize { get; set; }
        public DateTime Datetime { get; set; }
        public string Shippingadress { get; set; }
    }
}
