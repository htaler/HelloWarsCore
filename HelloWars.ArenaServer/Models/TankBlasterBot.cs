﻿using System;
using HelloWars.Common.Enums;
using HelloWars.Common.Interfaces;
using HelloWars.Common.Models;

namespace HelloWars.ArenaServer.Models
{
    public class TankBlasterBot : BotClientBase<BotBattlefieldInfo, BotMove>
    {
        public TankBlasterBot(ICompetitor competitor) : base(competitor)
        {
            LastMissileFiredRound = Int32.MinValue;
        }

        public TankBlasterBot(TankBlasterBot bot) : base(bot)
        {
            Image = bot.Image;
            Location = bot.Location;
            LastDirection = bot.LastDirection;
            IsDead = bot.IsDead;
            LastMissileFiredRound = bot.LastMissileFiredRound;
        }

        public string Image { get; set; }
        public Point Location { get; set; }
        public bool IsDead { get; set; }
        public int LastMissileFiredRound { get; set; }
        public MoveDirection LastDirection { get; set; }
    }
}