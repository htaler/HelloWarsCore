using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Game.TankBlaster.Models;
using Game.TankBlaster.Services;
using HelloWars.Common.Interfaces;
using Newtonsoft.Json;

namespace HelloWars.Common.Models
{
    public class TankBlaster : IGame
    {

        private Battlefield _field;
        private BotService _botService;
        private int _delayTime;
        private TankBlasterConfig _gameConfig;
        private LocationService _locationService;
        private int _roundNumber;
        private ExplosionService _explosionService;

        public TankBlaster()
        {
            var configurationXml = GetConfiguration();
            ApplyConfiguration(configurationXml);
        }

        private string GetConfiguration()
        {
            string configurationJson;
            //TODO: throwing exception
            using (var stream = new FileStream(@"TankBlaster.config.json", FileMode.Open))
            using (var reader = new StreamReader(stream))
            {
                configurationJson = reader.ReadToEnd();
            }
            return configurationJson;
        }

        public async Task<RoundResult> PerformNextRoundAsync()
        {
            _roundNumber++;

            await _explosionService.HandleExplodablesAsync(_delayTime);

            if (!_botService.AreMultipleBotsLeft)
            {
                return new RoundResult
                {
                    FinalResult = _botService.GetBotResults(),
                    IsFinished = true,
                    History = new List<RoundPartialHistory>()
                };
            }

            return await _botService.PlayBotMovesAsync(_delayTime, _roundNumber);
        }

        public void SetupNewGame(IEnumerable<ICompetitor> competitors)
        {
            do
            {
                Reset();

                _field.GenerateRandomBoard();

                _botService.SetUpBots(competitors);

                _field.OnArenaChanged();

            } while (!_locationService.CanBotsMeet());
        }

        public void Reset()
        {
            _field.Reset();
            _roundNumber = 0;
        }

        public void SetPreview(object boardState)
        {
            _field.ImportState((Battlefield)boardState);
            _field.OnArenaChanged();
        }

        public string GetGameRules()
        {
            throw new System.NotImplementedException();
        }

        public void ApplyConfiguration(string configuration)
        {
            _gameConfig = JsonConvert.DeserializeObject<TankBlasterConfig>(configuration);
            _field = new Battlefield(_gameConfig.MapWidth, _gameConfig.MapHeight);
            _locationService = new LocationService(_field);
            _explosionService = new ExplosionService(_field, _gameConfig, _locationService);
            _botService = new BotService(_field, _gameConfig, _locationService);
        }

        public void ChangeDelayTime(int delayTime)
        {
            _delayTime = delayTime;
        }
    }
}
