using System.ComponentModel.DataAnnotations;

namespace ForumApplication.Models.ViewModels
{
    public class SignInView
    {
        [Required(ErrorMessage = "Login is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}