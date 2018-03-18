using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MatchedBetMate.DTO.Enum;

namespace MatchedBetMate.DTO.CustomAttributes
{
    public class SportEnumAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsSportEnum = (Sport) value;
        }
    }
}
