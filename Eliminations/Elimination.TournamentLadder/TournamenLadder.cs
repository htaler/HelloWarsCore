using System;
using System.Collections.Generic;
using System.Linq;
using Elimination.TournamentLadder.Classes;
using HelloWars.Common.Interfaces;
using HelloWars.Common.Models;

namespace Elimination.TournamentLadder
{
    public class TournamenLadder : IElimination
    {
        private readonly int _numberOfStages;
        private readonly int _startingNumberOfBots;
        public List<List<BotStage>> StageLists;

        public TournamenLadder(List<ICompetitor> bots)
        {
            Bots = bots;
            _numberOfStages = (int) Math.Ceiling(Math.Log(Bots.Count, 2)) + 1;
            _startingNumberOfBots = (int) Math.Pow(2, _numberOfStages - 1);
            InitialTournamenLadder();
            AddBotsToTournamentList();
        }

        public List<ICompetitor> Bots { get; }

        public IList<ICompetitor> GetNextCompetitors()
        {
            var result = new List<ICompetitor>();

            foreach (var stageList in StageLists)
            foreach (var bot in stageList)
                if (stageList.Count > 1)
                    if (bot.StilInGame)
                    {
                        var connectedBot = stageList.First(f => f.PairWithId == bot.Id);

                        if (connectedBot.StilInGame)
                        {
                            if (bot.BotClient == null || !bot.BotClient.IsVerified)
                            {
                                UpdateTournamentLadder(bot, 0);
                                UpdateTournamentLadder(connectedBot, 1);
                                return GetNextCompetitors();
                            }
                            if (connectedBot.BotClient == null || !connectedBot.BotClient.IsVerified)
                            {
                                UpdateTournamentLadder(bot, 1);
                                UpdateTournamentLadder(connectedBot, 0);
                                return GetNextCompetitors();
                            }

                            result.Add(bot.BotClient);
                            result.Add(connectedBot.BotClient);
                            return result;
                        }
                    }

            return null;
        }

        public void SetLastDuelResult(IDictionary<ICompetitor, int> result)
        {
            if (result != null && result.Any(pair => pair.Value > 0))
            {
                foreach (var singleResult in result)
                {
                    var botControl = ReturnBotStage(singleResult.Key);

                    if (botControl != null)
                    {
                        UpdateTournamentLadder(botControl, singleResult.Value);
                    }
                }
            }
        }

        private BotStage ReturnBotStage(ICompetitor competitor)
        {
            BotStage botStage = null;

            foreach (var stageList in StageLists)
            {
                var tempBotStage = stageList.FirstOrDefault(f => f.BotClient != null && f.BotClient.Id == competitor.Id);
                if (tempBotStage != null) { botStage = tempBotStage; }
            }

            return botStage;
        }

        public string GetGameDescription()
        {
            var competitors = GetNextCompetitors();
            return string.Format("Duel: {0} vs {1} {2}", competitors[0].Name, competitors[1].Name, DateTime.Now);
        }

        private void AddBotsToTournamentList()
        {
            var numberOfEmptyShells = _startingNumberOfBots - Bots.Count;
            var botsEnumerable = Bots.GetEnumerator();
            for (var i = 0; i < StageLists[0].Count; i++)
            {
                if (numberOfEmptyShells > 0 && i % 2 != 0)
                {
                    numberOfEmptyShells--;
                    continue;
                }
                botsEnumerable.MoveNext();
                StageLists[0][i].BotClient = botsEnumerable.Current;
            }
        }

        private void UpdateTournamentLadder(BotStage bot, int score)
        {
            if (score == 1)
                if (StageLists[bot.CurrentStage].Count > 1)
                    bot.CurrentStage++;
            if (score == 0)
                bot.StilInGame = false;
        }

        private void InitialTournamenLadder()
        {
            StageLists = new List<List<BotStage>>();

            var numberOfBots = _startingNumberOfBots;
            var stageNumber = 1;

            while (numberOfBots > 0)
            {
                var list = CreateStageList(stageNumber, numberOfBots);
                StageLists.Add(list);

                stageNumber++;
                numberOfBots = numberOfBots / 2;
            }

            foreach (var stageList in StageLists)
                if (stageList.Count > 1)
                    SetDuels(stageList);
        }

        private void SetDuels(List<BotStage> list)
        {
            for (var i = 0; i < list.Count; i = i + 2)
            {
                list[i].PairWithId = list[i + 1].Id;
                list[i + 1].PairWithId = list[i].Id;
            }
        }

        private List<BotStage> CreateStageList(int stageNumber, int numberOfBots)
        {
            var result = new List<BotStage>();

            if (stageNumber == 1)
                for (var i = 0; i < numberOfBots; i++)
                {
                    var botShell = AddEmptyBotToStage(stageNumber, i, numberOfBots);
                    botShell.Id = i;
                    botShell.NextStageTargetId = i / 2;
                    result.Add(botShell);
                }
            else if (stageNumber == _numberOfStages)
                for (var i = 0; i < numberOfBots; i++)
                {
                    var botShell = AddEmptyBotToStage(stageNumber, i, numberOfBots);
                    botShell.Id = i;
                    result.Add(botShell);
                }
            else
                for (var i = 0; i < numberOfBots; i++)
                {
                    var botShell = AddEmptyBotToStage(stageNumber, i, numberOfBots);
                    botShell.Id = i;
                    botShell.NextStageTargetId = i / 2;
                    result.Add(botShell);
                }

            return result;
        }

        private BotStage AddEmptyBotToStage(int stageNumber, int orderInRow, int numberOfBots)
        {
            var botView = new BotStage
            {
                BotHeadPoint = new Point
                {
                    X = (stageNumber - 1) * (160 + 50) + 160,
                    Y = _startingNumberOfBots / numberOfBots * 60 * orderInRow + ((int) Math.Pow(2, stageNumber - 1) - 1) * 60 / 2 + 60 / 2
                },
                BotTailPoint = new Point
                {
                    X = (stageNumber - 1) * (160 + 50),
                    Y = _startingNumberOfBots / numberOfBots * 60 * orderInRow + ((int) Math.Pow(2, stageNumber - 1) - 1) * 60 / 2 + 60 / 2
                }
            };

            return botView;
        }
    }
}