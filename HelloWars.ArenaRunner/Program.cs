using System;
using System.Net.Http;
using System.Text;
using Common.Models;
using Newtonsoft.Json;

namespace HelloWars.ArenaRunner
{
    public class Value
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to arena...");

            HttpClient httpClient = new HttpClient();

            Competitor competitor = new Competitor
            {
                Description = "TestDescription",
                Name = "TestName",
                Url = "Url"
            };
            var competitorJson = JsonConvert.SerializeObject(competitor);
            var stringContent = new StringContent(competitorJson, Encoding.UTF8, "application/json");
             var task = httpClient.PostAsync("http://localhost:8833/api/competitors", stringContent );

            var e = task.Exception;
            var t = task.Result;

            var gameTask = httpClient.GetAsync("http://localhost:8833/api/game/PlayDuel");
            var re = gameTask.Exception;
            var rg = gameTask.Result;

            Console.WriteLine("Adding contenders...");
        }
    }
}