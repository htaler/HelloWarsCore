using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWars.ExampleBot.Controllers;
using HelloWars.Common.Models;
using HelloWars.Common.Enums;

namespace HelloWars.ExampleBot.Tests
{
    [TestClass]
    public class ExampleBotUnitTests
    {
        [TestMethod]
        public void CanRetrieveBotInfo()
        {
            ExampleBotController controller = new ExampleBotController();
            var botInfo = controller.Info();
            Assert.AreEqual("ExampleBot", botInfo.Name);
        }
    }
}
