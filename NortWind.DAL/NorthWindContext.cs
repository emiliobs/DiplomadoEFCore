namespace NortWind.DAL
{
    using Microsoft.Extensions.Logging;
    using NorthWind.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NorthWindContext:DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NorthwindDb;Integrated Security=True");
                //.EnableSensitiveDataLogging(true)
                //.UseLoggerFactory(new LoggerFactory().AddConsole((category,level) => level == LogLevel.Information && 
                //                                                                     category == DbLoggerCategory.Database.Command.Name, true));


            base.OnConfiguring(optionsBuilder);
        }                                               
    }
}
