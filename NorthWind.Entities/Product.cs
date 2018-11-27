namespace NorthWind.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int  UnitInStock { get; set; }
        public int CategoryId { get; set; }

        //relatioshiop
        public Category  Category { get; set; }




    }
}
