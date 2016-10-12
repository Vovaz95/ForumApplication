using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.Models.ViewModels
{
    public class SignUpView
    {
        [Required]
        [StringLength(50)]
        [Remote("CheckUserLogin", "Account", ErrorMessage = "Such login already exists")]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Nickname { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Must be between 8 and 25 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Must be between 8 and 25 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password confirmation doesn't match Password")]
        public string ConfirmPassword { get; set; }

        public HttpPostedFileBase Avatar { get; set; }
    }
}