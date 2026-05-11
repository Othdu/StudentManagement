using EFCoreDemo;
using Microsoft.EntityFrameworkCore;

using (var db = new AppDbContext())
{
    //filter
    var highGrade = db.Students
        .Where(s => s.Grade > 90)
        .ToList();

    Console.WriteLine("Grade >  90:");
    foreach(var s in highGrade)
        Console.WriteLine($"{s.Name}-{s.Grade}");

    //sort
    var ordered = db.Students
        .OrderByDescending(s => s.Grade)
        .ToList();

    Console.WriteLine("\nAll student sorted:");
    foreach(var s in ordered)
    Console.WriteLine($"{s.Name}-{s.Grade}");

    //aggregate
    int total =db.Students.Count();
    double avg = db.Students.Average(s => s.Grade);
    Console.WriteLine($"\nTotal:{total} | Average grade  : {avg:F1}");

}
Console.ReadLine();