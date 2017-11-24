using System.Collections.Generic;
using HelloWars.Common.Interfaces;

namespace HelloWars.ArenaServer
{
    public class Repository : IRepository
    {
        private List<ICompetitor> _competitors = new List<ICompetitor>();

        public List<ICompetitor> Competitors
        {
            get { return _competitors; }
            set { _competitors = value; }
        }

    }

    public interface IRepository
    {
        List<ICompetitor> Competitors { get; set; }
    }
}