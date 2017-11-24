﻿namespace Unwind.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IBM.WatsonDeveloperCloud.Conversation.v1;
    using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Unwind.Core.Models;
    using Unwind.Core.Services;

    public class ApiController : Controller
    {
        private readonly ApiContext _context;

        public ApiController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Service Ok");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ConversationItem item)
        {
            try
            {
                if (item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.NotValid.ToString());
                }

                var users = await _context.Users.ToArrayAsync();
                var user = users.FirstOrDefault(u => u.Id == item.Id);

                ConversationService _conversation = new ConversationService(Constants.WatsonUserName, Constants.WatsonPassword, Constants.WatsonVersionDate);
                MessageRequest messageRequest;
                MessageResponse result;

                if (user == null)
                {
                    // Clean new message
                    messageRequest = new MessageRequest()
                    {
                        Input = new InputData()
                        {
                            Text = item.Input
                        }
                    };

                    result = _conversation.Message(Constants.WatsonWorkSpaceId, messageRequest);

                    _context.Users.Add(new DbModels.User(){
                        Id = item.Id,
                        MessageContext = JsonConvert.SerializeObject(result.Context)
                    });
                } 
                else
                {
                    var previousResponce = JsonConvert.DeserializeObject<MessageResponse>(user.MessageContext);

                    messageRequest = new MessageRequest()
                    {
                        Input = new InputData()
                        {
                            Text = item.Input
                        },
                        Context = previousResponce
                    };

                    //  send a message to the conversation instance
                    result = _conversation.Message(Constants.WatsonWorkSpaceId, messageRequest);

                    user.MessageContext = JsonConvert.SerializeObject(result.Context);
                }

                await _context.SaveChangesAsync();

                return Ok(result.Output.Text.FirstOrDefault());
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateMessage.ToString());
            }
        }


        public enum ErrorCode
            {
                NotValid,
                CouldNotCreateMessage,
            }
    }
}