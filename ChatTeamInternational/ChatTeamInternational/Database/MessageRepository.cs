using ChatTeamInternational.Database.Contracts;
using ChatTeamInternational.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Database
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
       
        DbSet<Message> _table;

        public MessageRepository(ChatContext context) : base(context)
        {
            _table = context.Set<Message>();
        }

        public override void Update(Message item)
        {
            var sItem = _table.Where(t => t.Id == item.Id);
        }

        public bool IsMessageExist(string text)
        {
            var message = GetMessageByText(text);
            return (message != null) ? true : false;
        }

        public Message GetByText(string text)
        {
            Message message = _table.SingleOrDefault(el => el.Text == text);
            return message;
        }
        
        public Message GetMessageByText(string text)
        {
            Message message = _table.SingleOrDefault(el => el.Text == text);
            return message;
        }
    }
}
