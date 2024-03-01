using System.ComponentModel.DataAnnotations;

namespace SchoolEntity.Models
{
    public interface IEntity<TKey>
    {
        [Required]
        public TKey Id { get; set; }
    }
}
