using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApiCV.Validations;

namespace WebApiCV.Model
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Column("Nome")]
        [MaxLength(120, ErrorMessage = "O campo nome deve conter até 120 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Email")]
        [Column("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} caracteres de comprimento.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Senha", ErrorMessage = "Senha e confirmação não são as mesmas.")]
        public string ComFirmaSenha { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        [CustomValidationCPF(ErrorMessage = "CPF Invalido")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Data De Nascimeto")]
        [Column("DataDeNascimeto")]
        [DataType(DataType.Date)]
        public string DataDeNacimente { get; set; }
    }
   
}
