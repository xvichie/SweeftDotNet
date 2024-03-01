using Microsoft.EntityFrameworkCore;
using SchoolEntity.Data;
using SchoolEntity.Repositories;

namespace School
{
    class Program
    {
        public static void Main(string[] args)
        {
                TeacherRepository teacherRepository = new TeacherRepository();

                var teachers = teacherRepository.GetTeachersByStudentName("Giorgi");

                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"Teacher: {teacher.FirstName} {teacher.LastName}");
                }
        }
    }
}
