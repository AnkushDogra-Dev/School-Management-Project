
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaviSirTaskJune20.Models
{
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]

        [UniqueClassName(ErrorMessage = "Subject name must be unique.")]
        [Display(Name = "Subject Name")]
        public string? SubjectName { get; set; }



        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public virtual Classes? Class { get; set; }
    }






}
