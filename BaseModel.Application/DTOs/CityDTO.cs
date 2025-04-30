using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseModel.Application.DTOs
{
    public class CityDTO
    {
        public Guid Id { get; set; }
        public Guid StateId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [DisplayName("Name")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "Initials is Required")]
        [DisplayName("Initials")]
        public string IbgeId { get;  set; }
    }
}
