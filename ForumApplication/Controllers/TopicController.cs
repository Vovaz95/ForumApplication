using AutoMapper;
using ForumApplication.Models.ViewModels;
using ForumApplication.Service;
using ForumApplication.Service.Auth;
using ForumApplication.Service.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ForumApplication.Controllers
{
    public class TopicController : Controller
    {
        CustomAuthentication _authentication = new CustomAuthentication(System.Web.HttpContext.Current);
        // GET: Topic
        public ActionResult Index(int? id, int? page)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TopicService topicService = new TopicService();
            var topicDto = topicService.Get(id);

            if (topicDto == null)
            {
                return HttpNotFound();
            }

            var topicMessages = Mapper.Map<List<MessageDTO>, List<DisplayMessageView>>(topicDto.Messages);

            var topicView = Mapper.Map<CurrentTopicView>(topicDto);
            topicView.CurrentUserId = _authentication.CurrentUser?.Id;
            topicView.Messages = topicMessages.OrderBy(x => x.Datetime).ToPagedList(page ?? 1, 5);

            return View("Index", topicView);
        }

        [HttpPost]
        public ActionResult CreateMessage(int pageCount, int? topicId, string message)
        {
            MessageService messageService = new MessageService();

            var messageDto = new MessageDTO
            {
                Text = message,
                Datetime = DateTime.Now,
                TopicId = topicId.GetValueOrDefault(),
                UserId = _authentication.CurrentUser.Id
            };

            messageService.CreateMessage(messageDto);

            return RedirectToAction("Index", new { id = topicId, page = pageCount });
        }

        [HttpPost]
        public ActionResult EditMessage(int editMessageId, string editMessageText, int editPageNumber, int editTopicId)
        {
            MessageService messageService = new MessageService();

            var messageDto = messageService.Get(editMessageId);
            messageDto.Text = editMessageText;
            messageService.UpdateMessage(messageDto);

            return RedirectToAction("Index", new { id = editTopicId, page = editPageNumber });
        }

    }
}