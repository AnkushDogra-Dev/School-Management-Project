
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    namespace RaviSirTaskJune20.Models
    {
        public class Students
        {
            [Key]
            public int StudentId { get; set; }
        [Required]

        //[UniqueClassName(ErrorMessage = "Student name must be unique.")]
        [Display(Name = "Student Name")]

        public string? StudentName { get; set; }



            [ForeignKey("Class")]
            public int? ClassId { get; set; }
            public virtual Classes? Class { get; set; }


        [Required]
            [ForeignKey("Section")]





        
            public int  SectionId { get; set; }



        public virtual Sections? Section { get; set; }
       // public virtual Sections Section { get; set; }
        }
    }
