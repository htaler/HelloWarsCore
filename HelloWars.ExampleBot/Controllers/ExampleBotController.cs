using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWars.Common.Models;
using HelloWars.Common.Enums;

namespace HelloWars.ExampleBot.Controllers
{
    [Route("[controller]")]
    public class ExampleBotController : Controller
    {
        public ExampleBotController()
        {
            Name = "ExampleBot";
        }
        string Name { get; }
        string AvatarUrl
        {
            get
            {
                return Url.Content("~/Content/BotImg.png");
            }
        }

        [HttpGet]
        public BotInfo Info()
        {
            var bot = new BotInfo
            {
                Name = Name,
                AvatarUrl = AvatarUrl,
                GameType = "TankBlaster",
                Description = "Hi, I'm an example bot in .NET Core"
            };

            return bot;
        }
        // TODO: Add models for arena info
        // TODO: Add general interface
        [HttpPost]
        public BotMove PerformNextMove()
        {
            return new BotMove() { Action = BotAction.FireMissile, Direction = MoveDirection.Down, FireDirection = MoveDirection.Down };
        }
       
    }
}
