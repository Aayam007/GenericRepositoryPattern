using System.ComponentModel.DataAnnotations;

namespace Entities.DTO.Request.Person
{
    public class PersonDto
    {
        [Required(AllowEmptyStrings = false)]
        public  string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public  string Phone { get; set; }

        [Required(AllowEmptyStrings = false)]
        public  string Email { get; set; }
    }
}


