using System;

namespace ForumApplication.Service.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Datetime { get; set; }
        public string NickName { get; set; }
        public byte[] Avatar { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
    }
}