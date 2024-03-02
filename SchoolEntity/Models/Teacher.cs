namespace SchoolEntity.Models
{
    public class Teacher : IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public ICollection<Pupil>? Pupils { get; set; }
    }
}
