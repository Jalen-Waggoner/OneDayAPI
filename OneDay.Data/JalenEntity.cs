using System.ComponentModel.DataAnnotations;
namespace OneDay.Data
{
    public class JalenEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Content { get; set; } = null!;
    }
}