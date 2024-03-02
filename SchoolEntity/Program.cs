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

            if (teachers.Count() == 0) Console.WriteLine("No Such teacher with student named giorgi has Been found");
            else
            {
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"Teacher: {teacher.FirstName} {teacher.LastName}");
                }
            }
        }
    }
}
