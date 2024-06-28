
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaviSirTaskJune20.Models
{
    public class Sections
    {
        [Key]
        public int SectionId { get; set; }
        [Required]
        [Display(Name = "Section Name")]
        public string? SectionName { get; set; }

        [ForeignKey("Class")]
        
        public int? ClassId { get; set; }
        
        public virtual Classes? Class { get; set; }
        public virtual ICollection<Teachers>? Teachers { get; set; }
       public virtual ICollection<Students>? Students { get; set; }

    }
}
