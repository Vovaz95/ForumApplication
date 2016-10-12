namespace ForumApplication.Models.ViewModels
{
    public class TableTopicView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Datetime { get; set; }
        public string Author { get; set; }
        public int MessagesCount { get; set; }
    }
}