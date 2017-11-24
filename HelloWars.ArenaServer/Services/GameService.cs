using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HelloWars.ArenaServer.Interfaces;
using HelloWars.Common.Interfaces;
using HelloWars.Common.Models;
using HelloWars.Common.Utilities;
using Elimination.TournamentLadder;
using Game.TankBlaster.Models;
using Newtonsoft.Json;

namespace HelloWars.ArenaServer.Services
{
    public class GameService : IGameService
    {
        private readonly ICompetitorService _competitorService;
        private readonly IRepository _repository;
        private readonly IElimination _elimination;
        private readonly IGame _game;
        private List<RoundPartialHistory> _gameHistory;
        private readonly ScoreList _scoreList;
        public ArenaConfiguration ArenaConfiguration { get; set; }

        public GameService(ICompetitorService competitorService, IRepository repository)
        {
            _competitorService = competitorService;
            _repository = repository;
            ArenaConfiguration = GetArenaConfiguration();
            _elimination = new TournamenLadder(repository.Competitors);
            _game = new TankBlaster();
            _gameHistory = new List<RoundPartialHistory>();
            _scoreList = new ScoreList();
        }

        private ArenaConfiguration GetArenaConfiguration()
        {
            string configurationJson;
            using (var stream = new FileStream(@"ArenaConfiguration.config.json", FileMode.Open))
            using (var reader = new StreamReader(stream))
            {
                configurationJson = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<ArenaConfiguration>(configurationJson);
        }

        public bool IsGameInProgress { get; set; }

        public bool IsGamePaused { get; set; }

        public async void PlayDuelAsync()
        {
            if (!AllCompetitorsConnected())
            {
                
            }
            IsGameInProgress = true;
            //if (IsGamePaused)
            //{
            //    IsGamePaused = false;
            //    await ResumeGameAsync();
            //}
            //else
            //{
            await PlayNextGameAsync();
            //}
            //IsGameInProgress = false;

            //if (ShouldRestartGame)
            //{
            //    RestartGame();
            //}
        }

        private bool AllCompetitorsConnected()
        {
            //TODO: previus hello_wars() version doesn't wait for all players. At least one. 
            //TODO: parallel verification?

            foreach (var competitor in _repository.Competitors)
            {
                try
                {
                    _competitorService.Verify(ArenaConfiguration.GameConfiguration.Type, competitor);


                    //TODO: message
                    //OutputText += string.Format("Bot \"{0}\" connected!\n", bot.Name);
                    //_elimination.Bots.First(f => f.Id == bot.Id).Name = bot.Name;
                }
                catch (Exception e)
                {
                    //bot.Name = "Not connected";
                    //OutputText += string.Format("ERROR: Url: {0} - couldn't verify bot!\nError message:\n{1}\n", bot.Url, e.Message);
                }
            }
                
            if (_repository.Competitors.All(competitor => competitor.IsVerified))
            {
                return true;
                //OutputText += "All players connected!\n";
            }
            else
            {
                return false;
                //OutputText += "WARNING: Not all players were succesfully verified.\nTry reconnecting or play tournament without them\n";
            }
        }

        public object Lock { get; set; }

        private async Task PlayNextGameAsync()
        {
            var nextCompetitors = _elimination.GetNextCompetitors();
            if (nextCompetitors != null)
            {
                _game.SetupNewGame(nextCompetitors);

                _gameHistory = new List<RoundPartialHistory>();

                //TODO: messages
                //OutputText += "Game starting: " + Elimination.GetGameDescription() + "\n";

                await PlayGameAsync();
            }
        }

        private async Task PlayGameAsync()
        {
            RoundResult result;

            do
            {
                result = await _game.PerformNextRoundAsync();

                //TODO: messages
                //OutputText += result.OutputText;

                foreach (var roundPartialHistory in result.History)
                    _gameHistory.Add(roundPartialHistory);
            } while (!result.IsFinished && IsGameInProgress && !IsGamePaused);

            if (result.IsFinished && IsGameInProgress)
                MakeEndGameConfiguration(result);
        }

        private void MakeEndGameConfiguration(RoundResult result)
        {
            _elimination.SetLastDuelResult(result.FinalResult);
            _scoreList.SaveScore(result.FinalResult);
            //TODO: messages
            //OutputText += GetEndGameMessage(result.FinalResult);
        }

        private string GetEndGameMessage(Dictionary<ICompetitor, double> finalResult)
        {
            if (finalResult.Any(res => res.Value == 1.0))
            {
                return finalResult.Single(x => x.Value == 1.0).Key.Name + "\nWINS";
            }

            return "DRAW";
        }
    }
}