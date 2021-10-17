using System;
namespace TemaDATC
{
    public class StudentsRepo
    {
        public static List<Student> Students = new List<Student>()
        {
            new Student(){ ID = 1, LastName= "Loghin", FirstName = "Andrei", StudyYear = 4, Faculty = "AC" },
            new Student(){ ID = 2, LastName= "Thiel",  FirstName = "Peter", StudyYear = 2, Faculty = "MPT" },
            new Student(){ ID = 3, LastName= "Daniels",  FirstName = "Jack", StudyYear = 1, Faculty = "UVT"},
            new Student(){ ID = 3, LastName= "Jasmine",  FirstName = "Kristine", StudyYear = 3, Faculty = "EE"}
        };
    }
}