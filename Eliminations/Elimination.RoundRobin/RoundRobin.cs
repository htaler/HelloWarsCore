using System.Collections.Generic;
using HelloWars.Common.Interfaces;

namespace Elimination.RoundRobin
{
    public class RoundRobin : IElimination
    {
        public List<ICompetitor> Bots { get; set; }
        public IList<ICompetitor> GetNextCompetitors()
        {
            throw new System.NotImplementedException();
        }

        public void SetLastDuelResult(IDictionary<ICompetitor, int> result)
        {
            throw new System.NotImplementedException();
        }

        public string GetGameDescription()
        {
            throw new System.NotImplementedException();
        }
    }
}