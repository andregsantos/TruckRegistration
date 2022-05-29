using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TruckRegistration.Data.Entity
{
    public class Truck : IValidatableObject
    {
        public int? Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int YearOfModel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Year != DateTime.Now.Year)
            {
                yield return new ValidationResult(
                    "The year must be the same as the current year.");
            }

            if (!(YearOfModel == DateTime.Now.Year || YearOfModel == DateTime.Now.Year + 1))
            {
                yield return new ValidationResult(
                    "The model year must be the current or subsequent year.");
            }
        }
    }
}
