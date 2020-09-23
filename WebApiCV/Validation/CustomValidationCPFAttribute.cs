using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiCV.Validation
{
   
       
        public class CustomValidationCPFAttribute : ValidationAttribute
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


        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
        //    ModelMetadata metadata, ControllerContext context)
        //{
        //    yield return new ModelClientValidationRule
        //    {
        //        ErrorMessage = this.FormatErrorMessage(null),
        //        ValidationType = "customvalidationcpf"
        //    };
        //}


    }
    }

