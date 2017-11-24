using HelloWars.Common.Interfaces;
using HelloWars.Common.Models;

namespace Elimination.TournamentLadder.Classes
{
    public class BotStage
    {
        public int Id;
        public int PairWithId;
        public int NextStageTargetId;
        public Point BotHeadPoint;
        public Point BotTailPoint;
        public ICompetitor BotClient;
        public bool StilInGame;
        public int CurrentStage;

        public BotStage()
        {
            StilInGame = true;
        }
    }
}