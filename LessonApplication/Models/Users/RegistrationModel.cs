using System.ComponentModel.DataAnnotations;


namespace pacmanGame.Models.Users
{
    public class RegistrationModel
    {
        //public string Name { get; set; }
        //public string Login { get; set; }
        //public string Password { get; set; }
        [Required]
        [Display(Name = "Полное имя")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
