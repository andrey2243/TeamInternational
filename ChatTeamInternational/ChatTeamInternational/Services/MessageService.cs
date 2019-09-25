using AutoMapper;
using ChatTeamInternational.Database;
using ChatTeamInternational.Database.Contracts;
using ChatTeamInternational.Models.DBModels;
using ChatTeamInternational.Models.VModels;
using ChatTeamInternational.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Services
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _repository;
        readonly IMapper _mapper;
        public MessageService(IMessageRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;

        }

        //private readonly RequestDelegate _next;
        //private IUserRepository _repository;
        //readonly IMapper _mapper;
        //public UserService(IUserRepository repository, IMapper mapper)
        //{
        //    this._repository = repository;
        //    this._mapper = mapper;

        //}

        public Message GetMessage(string text)
        {
            return _repository.GetMessageByText(text);
        }
        public bool IsMessageExist(MessageVM message)
        {
            return _repository.IsMessageExist(message.Text);
        }

        public Message MapModels(MessageVM message)
        {
            Message messageModel = new Message() { Text = message.Text };
            return messageModel;
        }

        public void SaveMessage(MessageVM message)
        {
            var messageToAdd = MapModels(message);
            _repository.Create(messageToAdd);
            _repository.Save();
        }


    }
    
}
