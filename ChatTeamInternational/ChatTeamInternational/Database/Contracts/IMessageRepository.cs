using ChatTeamInternational.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Database.Contracts
{
    public interface IMessageRepository : IRepository<Message>
    {
        //IQueryable<Message> GetMessageListByUser(string nickName);
        bool IsMessageExist(string text);      
        Message GetMessageByText(string text);
        
    }
}
