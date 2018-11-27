namespace NorthWind.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
       
        //relationship
        public List<Product> Products { get; set; }
    }
}
