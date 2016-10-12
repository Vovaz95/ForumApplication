using AutoMapper;
using ForumApplication.Service.DTO;
using ForumApplication.Store.Entities;
using ForumApplication.Store.Repositories;
using System.Configuration;

namespace ForumApplication.Service
{
    public class UserService
    {
        private EfUnitOfWork _db = new EfUnitOfWork(ConfigurationManager.ConnectionStrings["ForumDBEntities"].ConnectionString);

        public void SignUp(UserDTO userDto)
        {
            var user = Mapper.Map<User>(userDto);

            _db.Users.Create(user);
            _db.Save();
        }

        public UserDTO Get(int id)
        {
            User user = _db.Users.Get(id);
            var userDto = Mapper.Map<UserDTO>(user);

            return userDto;
        }

        public bool CheckUserLoginForExist(string login)
        {
            User user = ((UserRepository)_db.Users).FindUserByName(login);
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}