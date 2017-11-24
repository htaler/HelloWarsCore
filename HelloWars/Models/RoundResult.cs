using System.Collections.Generic;
using HelloWars.Common.Interfaces;

namespace HelloWars.Common.Models
{
    public class RoundResult
    {
        public bool IsFinished { get; set; }
        public Dictionary<ICompetitor, int> FinalResult { get; set; }
        public List<RoundPartialHistory> History { get; set; }
        public string OutputText { get; set; }
    }
}
