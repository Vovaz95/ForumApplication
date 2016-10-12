using System.Collections.Generic;

namespace ForumApplication.Service.DTO
{
    public class TopicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Datetime { get; set; }
        public string NickName { get; set; }
        public byte[] Avatar { get; set; }
        public int UserId { get; set; }

        public List<MessageDTO> Messages;
    }
}