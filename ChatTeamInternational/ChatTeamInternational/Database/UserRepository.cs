using ChatTeamInternational.Database.Contracts;
using ChatTeamInternational.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Database
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        DbSet<User> _table;

        public UserRepository(ChatContext context) : base(context)
        {
            _table = context.Set<User>();
        }

        
        public bool IsUserExist(string name)
        {
            var user = GetByName(name);
            return (user != null) ? true : false;
        }
        
        public User GetByName(string name)
        {
            User user = _table.SingleOrDefault(el => el.NickName == name);
            return user;
        }
        public IQueryable<User> GetUserListBySymb(string symbols)
        {
            var result = _table.Where(t => t.NickName.StartsWith(symbols));
            return result;
        }

        public User GetById(int id)
        {
            User user = _table.SingleOrDefault(el => el.Id == id);
            return user;
        }
    }
}
