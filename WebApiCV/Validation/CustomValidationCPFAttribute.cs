using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApiCV.Validation
{
   
       
        public class CustomValidationCPFAttribute : ValidationAttribute, IClientValidatable
        {
            public override object TypeId => base.TypeId;

            public override bool RequiresValidationContext => base.RequiresValidationContext;

            public CustomValidationCPFAttribute() { }

           
            public override bool IsValid(object value)
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                    return true;

                bool valido = ValidacaoCpf.ValidaCPF(value.ToString());
                return valido;
            }

            
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
                ModelMetadata metadata, ControllerContext context)
            {
                yield return new ModelClientValidationRule
                {
                    ErrorMessage = this.FormatErrorMessage(null),
                    ValidationType = "customvalidationcpf"
                };
            }

            public override string ToString()
            {
                return base.ToString();
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool IsDefaultAttribute()
            {
                return base.IsDefaultAttribute();
            }

            public override bool Match(object obj)
            {
                return base.Match(obj);
            }

            public override string FormatErrorMessage(string name)
            {
                return base.FormatErrorMessage(name);
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                return base.IsValid(value, validationContext);
            }
        }
    }

