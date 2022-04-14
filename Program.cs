// See https://aka.ms/new-console-template for more information
using LinquePractices.DbOperations;
using LinquePractices.Entities;

Console.WriteLine("Hello, World!");


DataGenerator.Initialize();
LinqueDbContext _context = new LinqueDbContext();
var students = _context.Students.ToList<Student>();

// Find() primary key olarak tanımlanan alana göre arama yapar.
Console.WriteLine("**** Find ****");
var student = _context.Students.Where(student => student.StudentID == 1).FirstOrDefault();
student = _context.Students.Find(2);
System.Console.WriteLine(student?.Name);


// FirstOrDefault()
System.Console.WriteLine("**** FirstOrDefault ****");
student = _context.Students.Where(x => x.Surname== "Yaçın").FirstOrDefault();
System.Console.WriteLine(student?.Surname);

// ikinci yöntem

student = _context.Students.FirstOrDefault(x => x.Surname =="Yalçın");
System.Console.WriteLine(student?.Name);

// SingleOrDefault() bir adet veri varsa o sorun yok birden fazlaysa hata alırız.
System.Console.WriteLine("**** SingleOrDefault ****");
student = _context.Students.SingleOrDefault(x => x.Name == "Merve");
System.Console.WriteLine(student?.Name);

// ToList()
System.Console.WriteLine("**** ToList ****");
var studentList = _context.Students.Where(x => x.ClassID ==2).ToList();
System.Console.WriteLine(studentList.Count);
foreach (var item in studentList)
{
    System.Console.WriteLine(item.Name);
}


// OrderBy() sıralama yapmak için kullanıyoruz
System.Console.WriteLine("**** OrderBy ****");
var studentz = _context.Students.OrderBy(x => x.StudentID).ToList();

foreach (var item in studentz)
{
    System.Console.WriteLine(item.StudentID+" - "+item.Name+" "+item.Surname);

}

// OrderByDescending() tersden sıralama yapmak için kullanıyoruz
System.Console.WriteLine("**** OrderByDescendingLing ****");
 studentz = _context.Students.OrderByDescending(x => x.StudentID).ToList();

foreach (var item in studentz)
{
    System.Console.WriteLine(item.StudentID+" - "+item.Name+" "+item.Surname);
    
}

// Anonymous Object Result ()
// LINQ her zaman geriye entity objesi dönmek zorunda değildir.
// Query sonucunu kendi yarattığınız bir obje formatında döndürebilirsiniz.
System.Console.WriteLine("**** Anonymous Object Result ****");

var anonymousObject = _context.Students.Where(x => x.ClassID ==2).Select(x => new {
Id = x.StudentID,
FullName = x.Name +" "+x.Surname
});

foreach (var obj in anonymousObject)
{   
    System.Console.WriteLine(obj.Id+" - "+obj.FullName);
}