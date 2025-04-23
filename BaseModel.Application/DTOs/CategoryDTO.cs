using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseModel.Application.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MinLength(3)]
        [DisplayName("Name")]
        public string Name { get;  set; }
    }
}
