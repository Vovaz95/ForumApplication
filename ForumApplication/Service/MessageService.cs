using AutoMapper;
using ForumApplication.Service.DTO;
using ForumApplication.Store.Entities;
using ForumApplication.Store.Repositories;
using System.Configuration;

namespace ForumApplication.Service
{
    public class MessageService
    {
        private EfUnitOfWork _db = new EfUnitOfWork(ConfigurationManager.ConnectionStrings["ForumDBEntities"].ConnectionString);

        public void CreateMessage(MessageDTO messageDto)
        {
            var message = Mapper.Map<Message>(messageDto);

            _db.Messages.Create(message);
            _db.Save();
        }

        public void UpdateMessage(MessageDTO messageDto)
        {
            var message = Mapper.Map<Message>(messageDto);

            _db.Messages.Update(message);
            _db.Save();
        }

        public MessageDTO Get(int id)
        {
            var message = _db.Messages.Get(id);

            return Mapper.Map<MessageDTO>(message);
        }
    }
}