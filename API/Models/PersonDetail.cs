using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class PersonDetail
    {
        [Key]
        public int Id { get; set; }
        public string PersonCity { get; set; }
        public DateTime BirthDay { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}