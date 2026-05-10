using EFCoreDemo;
using Microsoft.EntityFrameworkCore;

using (var db = new AppDbContext())
{
    var student = db.Students.Include(s => s.Courses).ToList();
    foreach(var s in student)
    {
        Console.WriteLine($"{s.Name}-{s.Grade}");
        foreach (var c in s.Courses)
            Console.WriteLine($" -> {c.CourseName}");
    }
    Console.ReadLine();
}
    