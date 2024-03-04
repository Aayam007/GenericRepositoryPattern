using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entity
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(256)")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "varchar(128)")]
        public string Phone { get; set; } = string.Empty;

        [Column(TypeName = "varchar(128)")]
        public string Email { get; set; } = string.Empty;
    }

}
