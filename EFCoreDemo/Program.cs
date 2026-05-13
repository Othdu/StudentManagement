using EFCoreDemo;
using Microsoft.EntityFrameworkCore;

//using (var db = new AppDbContext())
//{
//    var electronics = new Category
//    {
//        Name = "Electronics",
//        Products = new List<product>
//        {
//            new product{Name ="Laptop", Quantity=10,price=3400},
//            new product{Name="phone", Quantity=12,price=141},



//        }
//    };

//    var food = new Category
//    {
//        Name = "Food",
//        Products = new List<product>
//        {
//            new product{Name ="Rice 1Kg", Quantity=101,price=4.8},
//            new product{Name="Onions", Quantity=142,price=2.78},

//        }
//    };
//    db.Categories.AddRange(electronics, food);
//    db.SaveChanges();
//    Console.WriteLine("Data added.");


//}

using (var db = new AppDbContext())
{
    var Products = db.Products
        .Include(p => p.Category)
        .OrderBy(p => p.Category.Name)
        .ToList();

    Console.WriteLine("\n ===== Inventory ===== ");
    foreach(var p in Products)
        Console.WriteLine($"{p.Name} - only {p.Quantity}Left");

    Console.WriteLine("\n=== Low Stock (under 20) ===");
    var lowStock = db.Products
        .Include(p => p.Category)
        .Where(p => p.Quantity < 20)
        .ToList();

    Console.WriteLine("\n ==== Value per Category ====");
    var grouped = db.Products
        .Include(p => p.Category)
        .ToList()
        .GroupBy(p => p.Category.Name);

    foreach(var g  in grouped)
    {
        double total = g.Sum(p => p.price * p.Quantity);
        Console.WriteLine($"{g.Key}:${total:F2}");
    }    

}


Console.ReadLine();