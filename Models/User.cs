using System.ComponentModel.DataAnnotations;

namespace BackendStageTwo.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; } 
    }
}
