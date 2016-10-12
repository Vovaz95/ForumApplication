using AutoMapper;
using ForumApplication.Service.DTO;
using ForumApplication.Store.Entities;
using ForumApplication.Store.Repositories;
using System.Collections.Generic;
using System.Configuration;

namespace ForumApplication.Service
{
    public class TopicService
    {
        private EfUnitOfWork _db = new EfUnitOfWork(ConfigurationManager.ConnectionStrings["ForumDBEntities"].ConnectionString);

        public IEnumerable<TopicDTO> GetAllTopics()
        {
            IEnumerable<Topic> topics = _db.Topics.GetAll();

            List<TopicDTO> topicDtos = Mapper.Map<List<TopicDTO>>(topics);

            return topicDtos;
        }

        public IEnumerable<MessageDTO> GetMessagesByTopicId(int topicId)
        {
            IEnumerable<Message> messages = ((TopicRepository)_db.Topics).GetMessages(topicId);

            List<MessageDTO> messageDtos = Mapper.Map<List<MessageDTO>>(messages);

            return messageDtos;
        }

        public void CreateTopic(TopicDTO topicDto)
        {
            Topic topic = Mapper.Map<Topic>(topicDto);

            _db.Topics.Create(topic);
            _db.Save();
        }

        public TopicDTO Get(int? id)
        {
            var topic = _db.Topics.Get(id);

            return Mapper.Map<TopicDTO>(topic);
        }
    }
}