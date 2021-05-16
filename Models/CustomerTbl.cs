using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingCart.Models
{
    public partial class CustomerTbl
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public int? Discount { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string TaxNo { get; set; }
        public string City { get; set; }
    }
}
