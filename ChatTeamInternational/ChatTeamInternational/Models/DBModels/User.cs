using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Models.DBModels
{
    public class User : BaseModel, IBaseModel
    {

        public string NickName { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();     
        public string Password { get; set; }
       


        //public User()
        //{
        //    UserName = NickName;
        //    UserChats = new List<UserChat>();
        //}
    }
}
