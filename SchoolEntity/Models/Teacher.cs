using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntity.Models
{
    public class Teacher : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string Subject { get; set; } = string.Empty;

        public ICollection<Pupil> Pupils { get; set; }
    }
}
