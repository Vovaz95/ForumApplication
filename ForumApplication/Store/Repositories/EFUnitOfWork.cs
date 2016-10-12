using ForumApplication.Store.Entities;
using ForumApplication.Store.Interfaces;
using System;

namespace ForumApplication.Store.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private ForumDBEntities _db;
        private UserRepository _userRepository;
        private TopicRepository _topicRepository;
        private MessageRepository _messageRepository;

        private bool _disposed = false;

        public EfUnitOfWork(string connectionString)
        {
            _db = new ForumDBEntities(connectionString);
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }
                return _userRepository;
            }
        }

        public IRepository<Topic> Topics
        {
            get
            {
                if (_topicRepository == null)
                {
                    _topicRepository = new TopicRepository(_db);
                }
                return _topicRepository;
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(_db);
                }
                return _messageRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }



        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}