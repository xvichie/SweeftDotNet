using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntity.Models
{
    public class Pupil : IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Grade { get; set; } = string.Empty;

        public ICollection<Teacher>? Teachers { get; set; }
    }
}
