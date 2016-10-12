using ForumApplication.Store.Entities;
using ForumApplication.Store.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ForumApplication.Store.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ForumDBEntities _db;

        public UserRepository(ForumDBEntities context)
        {
            _db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User Get(int? id)
        {
            return _db.Users.Find(id);
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
        }

        public void Update(User item)
        {
            var original = _db.Users.Find(item.Id);

            if (original != null)
            {
                _db.Entry(original).CurrentValues.SetValues(item);
            }
        }

        public void Delete(int id)
        {
            var original = _db.Users.Find(id);
            if (original != null)
            {
                _db.Users.Remove(original);
            }
        }

        public User Login(string login, string password)
        {
            return _db.Users.FirstOrDefault(p => string.Compare(p.Login, login, true) == 0 && string.Compare(p.Password, password, true) == 0);
        }

        public User FindUserByName(string login)
        {
            return _db.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}