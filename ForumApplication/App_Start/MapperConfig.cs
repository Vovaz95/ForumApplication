using AutoMapper;
using ForumApplication.Models.ViewModels;
using ForumApplication.Service;
using ForumApplication.Service.DTO;
using ForumApplication.Store.Entities;
using System;
using System.Linq;

namespace ForumApplication
{
    public class MapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MessageDTO, Message>();

                cfg.CreateMap<Message, MessageDTO>()
                .ForMember(dto => dto.Avatar, opt => opt.MapFrom(m => m.User.Avatar))
                .ForMember(dto => dto.NickName, opt => opt.MapFrom(m => m.User.Nickname));

                cfg.CreateMap<Topic, TopicDTO>()
                .ForMember(dto => dto.Avatar, opt => opt.MapFrom(m => m.User.Avatar))
                .ForMember(dto => dto.NickName, opt => opt.MapFrom(m => m.User.Nickname))
                .ForMember(dto => dto.Messages, opt => opt.MapFrom(m => m.Messages.ToList()));

                cfg.CreateMap<TopicDTO, Topic>();

                cfg.CreateMap<UserDTO, User>();

                cfg.CreateMap<User, UserDTO>();

                cfg.CreateMap<SignUpView, UserDTO>()
                    .ForMember(dto => dto.Password, opt => opt.MapFrom(vm => PasswordEncoder.Encode(vm.Password)))
                    .ForMember(dto => dto.Avatar, opt => opt.MapFrom(vm => ImageHandler.GetImageByteArray(vm.Avatar)));

                cfg.CreateMap<UserDTO, UserView>();

                cfg.CreateMap<TopicDTO, TableTopicView>()
                    .ForMember(vm => vm.Author, opt => opt.MapFrom(dto => dto.NickName))
                    .ForMember(vm => vm.MessagesCount, opt => opt.MapFrom(dto => dto.Messages.Count));

                cfg.CreateMap<CreateTopicView, TopicDTO>()
                    .ForMember(dto => dto.Datetime, opt => opt.UseValue(DateTime.Now))
                    .ForMember(dto => dto.UserId, opt => opt.Ignore())
                    .ForMember(dto => dto.Name, opt => opt.MapFrom(vm => vm.TopicName))
                    .ForMember(dto => dto.Messages, opt => opt.Ignore());

                cfg.CreateMap<TopicDTO, CurrentTopicView>()
                    .ForMember(vm => vm.CurrentUserId, opt => opt.Ignore())
                    .ForMember(vm => vm.Messages, opt => opt.Ignore());

                cfg.CreateMap<MessageDTO, DisplayMessageView>();
            });
        }
    }
}