using ForumApplication.Store.Entities;
using ForumApplication.Store.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ForumApplication.Store.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private ForumDBEntities _db;

        public MessageRepository(ForumDBEntities context)
        {
            _db = context;
        }

        public IEnumerable<Message> GetAll()
        {
            return _db.Messages.ToList();
        }

        public Message Get(int? id)
        {
            return _db.Messages.Find(id);
        }

        public void Create(Message item)
        {
            _db.Messages.Add(item);
        }

        public void Update(Message item)
        {
            var original = _db.Messages.Find(item.Id);

            if (original != null)
            {
                _db.Entry(original).CurrentValues.SetValues(item);
            }
        }

        public void Delete(int id)
        {
            var original = _db.Messages.Find(id);
            if (original != null)
            {
                _db.Messages.Remove(original);
            }
        }
    }
}