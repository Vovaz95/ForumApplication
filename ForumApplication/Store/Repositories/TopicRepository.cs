using ForumApplication.Store.Entities;
using ForumApplication.Store.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ForumApplication.Store.Repositories
{
    public class TopicRepository : IRepository<Topic>
    {
        private ForumDBEntities _db;

        public TopicRepository(ForumDBEntities context)
        {
            _db = context;
        }

        public IEnumerable<Topic> GetAll()
        {
            return _db.Topics.ToList();
        }

        public Topic Get(int? id)
        {
            return _db.Topics.Find(id);
        }

        public IEnumerable<Message> GetMessages(int id)
        {
            return _db.Topics.Find(id).Messages;
        }

        public void Create(Topic item)
        {
            _db.Topics.Add(item);
        }

        public void Update(Topic item)
        {
            var original = _db.Topics.Find(item.Id);

            if (original != null)
            {
                _db.Entry(original).CurrentValues.SetValues(item);
            }
        }

        public void Delete(int id)
        {
            var original = _db.Topics.Find(id);
            if (original != null)
            {
                _db.Topics.Remove(original);
            }
        }
    }
}