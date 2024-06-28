
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaviSirTaskJune20.Models
{
    public class Teachers
    {
        [Key]
        public int TeacherId { get; set; }


        [Required]


        [Display(Name = "Subject Name")]

        public string? TeacherName { get; set; }
        [ForeignKey("Section")]
        public int SectionId { get; set; }


        [ForeignKey("Class")]
        public int? ClassId { get; set; }
        public virtual Classes? Class { get; set; }

        public virtual Sections? Section { get; set; }


    }
}
