using LinquePractices.Entities;

namespace  LinquePractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(){
            using(var context = new LinqueDbContext()){
                
                // Veri varsa çık 
                if (context.Students.Any())
                {
                    return;
                }
                // Veri yoksa 
                context.Students.AddRange(

                    new Student{
                        Name = "Yılmaz",
                        Surname = "Soydan",
                        ClassID = 1
                    },
                    new Student{
                        Name = "Merve",
                        Surname = "Sonar",
                        ClassID = 1
                    },
                    new Student{
                        Name = "Umut",
                        Surname = "Yalçın",
                        ClassID = 2
                    },
                    new Student{
                        Name = "Sinem",
                        Surname = "Ulucan",
                        ClassID = 2
                    }

                );
                context.SaveChanges();
            }
        }
    }
}