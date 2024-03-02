using SchoolEntity.Data;
using SchoolEntity.Models;

namespace SchoolEntity.Repositories
{
    public class TeacherRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Teacher> GetTeachersByStudentName(string studentName)
        {

            var teachers = (from t in _context.Teachers
                            join p in _context.Pupils on t.Id equals p.Id
                            where p.FirstName == studentName
                            select t).ToList();

            return teachers;
        }
    }
}
