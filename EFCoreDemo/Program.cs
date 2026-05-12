using EFCoreDemo;
using Microsoft.EntityFrameworkCore;

using (var db = new AppDbContext())
{
    Console.WriteLine("=== Eager Loading ===");
    var students = db.Students
        .Include(s => s.Courses)
        .Where(s => s.Courses.Any())
        .ToList();

    foreach(var s in students)
    {
        Console.WriteLine($"{s.Name}");
        foreach(var c in s.Courses)
            Console.WriteLine($" -> {c.CourseName}");
    }

    Console.WriteLine("\n === without include ===");
    var student =db.Students.FirstOrDefault();
    Console.WriteLine($"{student.Name} Courses: {student.Courses?.Count??0}");
}
Console.ReadLine();