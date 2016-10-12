using ForumApplication.Store.Entities;
using System;

namespace ForumApplication.Store.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Topic> Topics { get; }
        IRepository<Message> Messages { get; }
        void Save();
    }
}
