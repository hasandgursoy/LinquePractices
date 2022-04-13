// See https://aka.ms/new-console-template for more information
using LinquePractices.DbOperations;
using LinquePractices.Entities;

Console.WriteLine("Hello, World!");


DataGenerator.Initialize();
LinqueDbContext _context = new LinqueDbContext();
var students = _context.Students.ToList<Student>();

