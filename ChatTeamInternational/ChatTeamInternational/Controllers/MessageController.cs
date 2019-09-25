using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatTeamInternational.Models.DBModels;
using ChatTeamInternational.Models.VModels;
using ChatTeamInternational.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatTeamInternational.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
       
       MessageService _messageService;

        public MessageController( MessageService userService)
        {
            _messageService = userService;
        }

        
        [HttpPost]
        [Route("Login")]
        //[ValidateAntiForgeryToken]
        public IActionResult CheckMessage([FromBody]MessageVM model)
        {
            var isValid = _messageService.IsMessageExist(model);
            if (isValid)
                return Json(model);
            else return Json(null);
        }

        [HttpPost]
        [Route("AddMessageToStore")]
        //[ValidateAntiForgeryToken]
        public IActionResult AddMessageToStore([FromBody]MessageVM model)
        {
            User user = new User { NickName = "Nick", Password = "1111" }; 
            _messageService.SaveMessage(model);
            return Json(true);
        }

        [HttpPost]
        [Route("EditMessage")]
        //[ValidateAntiForgeryToken]
        public IActionResult EditMessage([FromBody]MessageVM model)
        {
            _messageService.SaveMessage(model);
            return Json(true);
        }


    }
}
