using AutoMapper;
using ChatTeamInternational.Database.Contracts;
using ChatTeamInternational.Models.DBModels;
using ChatTeamInternational.Models.VModels;
using ChatTeamInternational.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Services
{
    public class UserService : IUserService
    {
        private readonly RequestDelegate _next;
        private IUserRepository _repository;
        readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            
        }
        public bool CheckUser(UserVM user)
        {
            return _repository.IsUserExist(user.NickName); 
        }

        public IQueryable<User> GetMatchedUsers(string symb)
        {
            return _repository.GetUserListBySymb(symb);

        }


        public User GetUser(string name)
        {
            return _repository.GetByName(name);
        }
        public bool IsUserExist(UserVM user)
        {
            return true/*_repository.IsUserExist(user.NickName)*/;
        }

        public User MapModels(UserVM user)
        {
            User userModel = new User() { NickName = user.NickName, Password = user.Password };
            return userModel;
        }

        public void RegisterUser(UserVM user)
        {
            var userToAdd = MapModels(user);
            _repository.Create(userToAdd);
            _repository.Save();
        }


    }
}
