using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Models.DBModels
{
    public class Message : BaseModel, IBaseModel
    {
        public string Text { get; set; }
          
    }
}
