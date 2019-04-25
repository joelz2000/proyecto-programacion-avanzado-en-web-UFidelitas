using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre: ")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Primer apellido: ")]
        [DataType(DataType.Text)]
        public string FirstLastName { get; set; }

        [Display(Name = "Segundo apellido: ")]
        [DataType(DataType.Text)]
        public string SecondLastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo: ")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento: ")]
        public string BirthDay { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numero de telefono: ")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Pais: ")]
        public int PaisID { get; set; }

        [Required]
        [Display(Name = "Provincia: ")]
        public int ProvinciaID { get; set; }

        [Required]
        [Display(Name = "Canton: ")]
        public int CantonID { get; set; }

        [Required]
        [Display(Name = "Distrito: ")]
        public int DistritoID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña: ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña: ")]
        [Compare("Password", ErrorMessage = "La contraseña y su confirmación no concuerdan.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
