using ForumApplication.Service.DTO;
using System.Web;

namespace ForumApplication.Service.Auth.Interfaces
{
    interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        bool Login(string login, string password, bool isPersistant);

        void LogOut();

        UserDTO CurrentUser { get; }
    }
}
