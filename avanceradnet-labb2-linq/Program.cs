using avanceradnet_labb2_linq.Models;
using Microsoft.EntityFrameworkCore;

namespace avanceradnet_labb2_linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            labb2linqDbContext context = new labb2linqDbContext();

            //Math teachers
            var mathTeachers = context.Teachers.
                Where(x => x.SubjectId == 2);

            Console.Write($"\n\tMath Teachers:");
            foreach (var teacher in mathTeachers)
            {
                Console.Write($"\n\t{teacher.TeacherName}");
            }
            Console.Write("\n\n\n");


            //visar elever och deras lärare
            var studentsWithTheirTeachers = context.Students.
                Join(context.Teachers,
                student => student.TeacherId,
                teacher => teacher.Id,
                (stud, teach) => new
                {
                    studentName = stud.StudentName,
                    teacherName = teach.TeacherName
                });
            foreach (var item in studentsWithTheirTeachers)
            {
                Console.Write($"\n\tElev: {item.studentName}, Lärare: {item.teacherName}");
            }
            Console.Write("\n\n\n");



            //kolla om courses innehåller programmering 1
            var containsProg1 = context.Subjects.
                Select(x => x.SubjectName).
                Contains("Programmering 1");
            Console.Write($"\n\tDoes subjects contain Programming 1: {containsProg1}");
            Console.Write("\n\n\n");



            //Editerar Programmering 2 till OOP
            var containsProg2 = context.Subjects.
                Where(x => x.SubjectName == "Programmering 2");
            foreach (var item in containsProg2)
            {
                Console.Write($"\n\t{item.SubjectName}");
                item.SubjectName = "OOP";
                Console.Write($"\n\t{item.SubjectName}");
            }
            Console.Write("\n\n\n");



            //ändra lärare från anas till reidar
            (from student in context.Students
             where student.TeacherId == 1 
             select student).
             ToList().
             ForEach(x => x.TeacherId = 2);
            context.SaveChanges();

            Console.ReadKey();
        }
    }
}