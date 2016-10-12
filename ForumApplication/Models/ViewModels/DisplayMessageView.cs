using System;

namespace ForumApplication.Models.ViewModels
{
    public class DisplayMessageView
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Datetime { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public string NickName { get; set; }
        public byte[] Avatar { get; set; }
    }
}