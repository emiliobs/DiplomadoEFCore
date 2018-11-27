using NorthWind.Entities;

namespace NF.COnsoleApp.NewBD
{
    using NortWind.DAL;

    using System;
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new NorthWindContext())
            {
                Console.Write("Ingrese el Nombre del usuario: ");
                var categoryName = Console.ReadLine();

                var NewCategory = new Category()
                {
                    CategoryName = categoryName,

                };

                db.Add(NewCategory);

                var rowAffected = db.SaveChanges();

                Console.WriteLine($"Número de regidtro afectaso: {rowAffected}");
                Console.WriteLine($"Categories: ");

                foreach (var category in db.Categories)
                {
                    Console.WriteLine($"Category Id: {category.CategoryId}, Categories: {category.CategoryName}");             
                }

            }

            Console.ReadKey();
        }
    }
}
