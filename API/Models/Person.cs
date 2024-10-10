using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }       

        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        [ForeignKey("Salary")]
        public int SalaryId { get; set; }
        public Salary Salary { get; set; }
        public virtual PersonDetail PersonDetail { get; set; }


    }
}
