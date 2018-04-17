using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GameRetailer.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }

        //[HiddenInput(DisplayValue = false)]
        //public string ReturnUrl { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Nome")]
        public string FName
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Apelido")]
        public string LName
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Tipo de Utilizador")]
        public string UserType
        {
            get;
            set;
        }
    }
}
