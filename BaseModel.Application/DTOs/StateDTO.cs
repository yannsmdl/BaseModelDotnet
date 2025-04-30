using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseModel.Application.DTOs
{
    public class StateDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MinLength(3)]
        [DisplayName("Name")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "Initials is Required")]
        [MinLength(2)]
        [MaxLength(2)]
        [DisplayName("Initials")]
        public string Initials { get;  set; }
    }
}
