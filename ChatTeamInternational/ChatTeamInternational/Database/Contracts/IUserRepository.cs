using ChatTeamInternational.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Database.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetUserListBySymb(string symbols);
        bool IsUserExist(string name);
        User GetByName(string name);
        User GetById(int id);
       
    }
}
