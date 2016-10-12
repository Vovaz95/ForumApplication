using AutoMapper;
using ForumApplication.Service.Auth.Interfaces;
using ForumApplication.Service.DTO;
using ForumApplication.Store.Entities;
using ForumApplication.Store.Interfaces;
using ForumApplication.Store.Repositories;
using System.Configuration;
using System.Web;

namespace ForumApplication.Service.Auth
{
    public class CustomAuthentication : IAuthentication
    {
        public HttpContext HttpContext { get; set; }

        private const string CookieName = "__AUTH_COOKIE";
        private UserDTO _currentUser;
        private IUnitOfWork _db;

        public CustomAuthentication(HttpContext context)
        {
            HttpContext = context;
            _db = new EfUnitOfWork(ConfigurationManager.ConnectionStrings["ForumDBEntities"].ConnectionString);
        }

        public bool Login(string login, string password, bool isPersistant)
        {
            var hash = PasswordEncoder.Encode(password);
            User retUser = ((UserRepository)_db.Users).Login(login, hash);
            if (retUser != null)
            {
                CreateCookie(login, isPersistant);
                return true;
            }

            return false;
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        public void CreateCookie(string login, bool isPersistent = false)
        {
            var userCookie = new HttpCookie(CookieName, login);
            userCookie.Expires.AddDays(365);
            HttpContext.Response.Cookies.Set(userCookie);
        }

        public UserDTO CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    HttpCookie authCookie = HttpContext.Request.Cookies.Get(CookieName);
                    if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                    {
                        User user = ((UserRepository)_db.Users).FindUserByName(authCookie.Value);
                        _currentUser = Mapper.Map<UserDTO>(user);
                    }
                    else
                    {
                        _currentUser = null;
                    }

                }
                return _currentUser;
            }
        }
    }
}