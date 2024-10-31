using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Lib.Models;
using Alfateam.Messenger.Models.DTO.Abstractions.Chats;
using Microsoft.AspNetCore.Mvc;
using static TdLib.TdApi;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerAuthController : AbsMessengerController
    {
        public MessengerAuthController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("Auth")]
        public async Task<AuthResult> Auth()
        {
            return await Messenger.Auth.Auth();
        }

        [HttpGet, Route("ConfirmAuth")]
        public async Task<AuthResult> ConfirmAuth(string code)
        {
            return await Messenger.Auth.ConfirmAuth(code);
        }

        [HttpGet, Route("GetOurUserId")]
        public async Task<string> GetOurUserId()
        {
            return await Messenger.Auth.GetOurUserId();
        }
    }
}
