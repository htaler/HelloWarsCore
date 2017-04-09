using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Models;
using Common.Utilities;

namespace ModelsTests
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
