using System;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common.Models
{
    public class Competitor : ICompetitor
    {
        private string _name;
        private string _avatarUrl;
        private string _description;
        public Guid Id { get; set; }
        public string Url { get; set; }

        public bool IsVerified { get; private set; }

        public string AvatarUrl
        {
            get { return _avatarUrl; }
            set { _avatarUrl = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

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
