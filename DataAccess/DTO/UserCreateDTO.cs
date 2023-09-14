using System.ComponentModel.DataAnnotations;

namespace BackendStageTwo.DataAccess.DTO
{
    public class UserCreateDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
