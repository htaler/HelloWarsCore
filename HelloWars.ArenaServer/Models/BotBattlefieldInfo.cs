using System;
using System.Collections.Generic;
using HelloWars.Common.Converters;
using HelloWars.Common.Enums;
using HelloWars.Common.Models;
using Newtonsoft.Json;

namespace HelloWars.ArenaServer.Models
{
    public class BotBattlefieldInfo
    {
        public int RoundNumber { get; set; }
        public int TurnNumber { get; set; }
        public Guid BotId { get; set; }
        public BoardTile[,] Board { get; set; }

        [JsonConverter(typeof(PointFormatConverter))]
        public Point BotLocation { get; set; }
        public int MissileAvailableIn { get; set; }

        [JsonConverter(typeof(PointFormatConverter))]
        public List<Point> OpponentLocations { get; set; }
        public List<Bomb> Bombs { get; set; }
        public List<Missile> Missiles { get; set; }
        public TankBlasterConfig GameConfig { get; set; }
    }
}