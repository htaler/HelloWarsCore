using System;
using System.Threading.Tasks;
using HelloWars.Common.Interfaces;

namespace Common.Models
{
    public class Competitor : ICompetitor
    {
        public Guid Id { get; set; }
        public string Url { get; set; }

        public bool IsVerified { get; set; }

        public string AvatarUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Competitor()
        {
        }

        public Competitor(ICompetitor competitor)
        {
            Id = competitor.Id;
            Url = competitor.Url;
            Description = competitor.Description;
            AvatarUrl = competitor.AvatarUrl;
            Name = competitor.Name;
        }

        public override string ToString()
        {
            return @"Name: $Name; Id: $Id";
        }

    }
}
