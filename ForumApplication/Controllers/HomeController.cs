using AutoMapper;
using ForumApplication.Models.ViewModels;
using ForumApplication.Service;
using ForumApplication.Service.Auth;
using ForumApplication.Service.DTO;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForumApplication.Controllers
{
    public class HomeController : Controller
    {
        CustomAuthentication _authentication = new CustomAuthentication(System.Web.HttpContext.Current);
        // GET: Home

        public ActionResult Index(int? page)
        {
            TopicService service = new TopicService();

            ViewBag.isRegistered = _authentication.CurrentUser != null;

            IEnumerable<TopicDTO> topicDtos = service.GetAllTopics();
            List<TableTopicView> topicsView = Mapper.Map<List<TableTopicView>>(topicDtos);

            return View("Index", topicsView.ToPagedList(page ?? 1, 5));
        }

        public ActionResult CreateTopic()
        {
            if (_authentication.CurrentUser == null)
            {
                return HttpNotFound();
            }
            return View("CreateTopic");
        }

        [HttpPost]
        public ActionResult CreateTopic(CreateTopicView topicView)
        {
            TopicDTO topicDto = Mapper.Map<TopicDTO>(topicView);
            topicDto.UserId = _authentication.CurrentUser.Id;

            TopicService service = new TopicService();

            service.CreateTopic(topicDto);
            return RedirectToAction("Index");
        }
    }
}