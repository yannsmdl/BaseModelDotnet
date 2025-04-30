using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseModel.Application.DTOs
{
    public class TenantDTO
    {
        public Guid Id { get;  set; }
        [Required(ErrorMessage = "Name is Required")]
        [MinLength(3)]
        [DisplayName("Name")]
        public string Name { get;  set; }
        [Required(ErrorMessage = "ConnectionString is Required")]
        [MinLength(3)]
        [DisplayName("ConnectionString")]
        public string ConnectionString { get;  set; }
        [Required(ErrorMessage = "TenantUrl is Required")]
        [MinLength(3)]
        [DisplayName("TenantUrl")]
        public string TenantUrl { get;  set; }
    }
}
