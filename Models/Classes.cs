    using Microsoft.EntityFrameworkCore;
    using RaviSirTaskJune20.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using System.Web;


    namespace RaviSirTaskJune20.Models
    {
        public class Classes
        {
            [Key]
            public int ClassId { get; set; }

            [Display(Name = "Class Name")]
            [Required]
        [UniqueClassName(ErrorMessage = "Class name must be unique.")]
        // [MaxLength(100)]
        public string Name { get; set; }
            public virtual ICollection<Sections>? Sections { get; set; }


            public virtual ICollection<Subjects>? Subjects { get; set; }

        }

    public class UniqueClassNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            if (dbContext == null)
            {
                throw new InvalidOperationException("AppDbContext could not be resolved.");
            }

            var classInstance = (Classes)validationContext.ObjectInstance;
            var className = (string)value;
            var existingClass = dbContext.Classes.FirstOrDefault(c => c.Name == className);

            if (existingClass != null && existingClass.ClassId != classInstance.ClassId)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }



}
