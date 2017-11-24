using System;
using Common.Models;
using HelloWars.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWars.Models.Tests
{
    [TestClass]
    public class ModelsTests
    {
        [TestMethod]
        public void ScoreListKeepsScore()
        {
            ScoreList scorelist = new ScoreList();
            Competitor competitor1 = new Competitor() { Name = "Comp1", Id = Guid.NewGuid() };
            Competitor competitor2 = new Competitor() { Name = "Comp2", Id = Guid.NewGuid() };

            scorelist.AddScore(competitor1, 10, competitor1);

            Assert.AreEqual(1, scorelist.ShowGameScoresForPlayer(competitor1).Count);
        }

        [TestMethod]
        public void CanCreateCompetitor()
        {
            Competitor competitor = new Competitor() { Name = "Comp1", Id = Guid.NewGuid() };
            Assert.IsNotNull(competitor);
        }
    }
}
