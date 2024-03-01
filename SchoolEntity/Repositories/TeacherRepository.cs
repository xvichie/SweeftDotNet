using Microsoft.EntityFrameworkCore;
using SchoolEntity.Data;
using SchoolEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntity.Repositories
{
    public class TeacherRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public Teacher[] GetTeachersByStudentName(string studentName)
        {

            var teachers = (from t in _context.Teachers
                            join p in _context.Pupils on t.Id equals p.Id
                            where p.FirstName == studentName
                            select t).ToArray();

            return teachers;
        }
    }
}
