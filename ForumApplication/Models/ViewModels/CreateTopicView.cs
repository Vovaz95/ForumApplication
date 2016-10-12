using System.ComponentModel.DataAnnotations;

namespace ForumApplication.Models.ViewModels
{
    public class CreateTopicView
    {
        [Required]
        [Display(Name = "Topic Name")]
        [StringLength(50, ErrorMessage = "Topic name length must be less than 50 characters")]
        public string TopicName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}