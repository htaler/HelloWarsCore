using System;
using System.Collections.Generic;
using System.Text;
using HelloWars.Common.Enums;
namespace HelloWars.Common.Models
{
    public class BotMove
    {
        public MoveDirection? Direction { get; set; }
        public BotAction Action { get; set; }
        public MoveDirection FireDirection { get; set; }
    }
}
