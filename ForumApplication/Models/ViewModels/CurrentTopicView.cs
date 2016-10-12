using PagedList;

namespace ForumApplication.Models.ViewModels
{
    public class CurrentTopicView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Datetime { get; set; }
        public string Nickname { get; set; }
        public byte[] Avatar { get; set; }
        public int? CurrentUserId { get; set; }

        public IPagedList<DisplayMessageView> Messages;
    }
}