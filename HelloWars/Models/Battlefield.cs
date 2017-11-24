﻿using System;
using System.Collections.Generic;
using System.Linq;
using HelloWars.Common.Enums;
using HelloWars.Common.Extensions;
using HelloWars.Common.Models;

namespace Game.TankBlaster.Models
{
    public class Battlefield
    {
        private readonly Random _rand = new Random(DateTime.Now.Millisecond);

        public Battlefield(int boardWidth, int boardHeight)
        {
            Bots = new List<TankBlasterBot>();
            Bombs = new List<Bomb>();
            Explosions = new List<Explosion>();
            Missiles = new List<Missile>();
            Board = new BoardTile[boardWidth, boardHeight];
        }

        public BoardTile[,] Board { get; set; }
        public List<TankBlasterBot> Bots { get; set; }
        public List<Bomb> Bombs { get; set; }
        public List<Missile> Missiles { get; set; }
        public List<Explosion> Explosions { get; set; }

        public List<TankBlasterBot> AliveBots
        {
            get { return Bots.Where(bot => !bot.IsDead).ToList(); }
        }

        public event EventHandler ArenaChanged;

        public void OnArenaChanged()
        {
            if (ArenaChanged != null)
            {
                ArenaChanged(this, EventArgs.Empty);
            }
        }

        public void Reset()
        {
            Bots.Clear();
            Bombs.Clear();
            Missiles.Clear();
            Explosions.Clear();
            Board = new BoardTile[Board.GetLength(0), Board.GetLength(1)];
            OnArenaChanged();
        }

        public Battlefield ExportState()
        {
            var arena = new Battlefield(Board.GetLength(0), Board.GetLength(1));

            Board.ForEveryElement((x, y, val) =>
            {
                arena.Board[x, y] = val;
            });

            arena.Bots = Bots.Select(bot => new TankBlasterBot(bot)).ToList();
            arena.Bombs = Bombs.Select(bomb => new Bomb{Location = bomb.Location, RoundsUntilExplodes = bomb.RoundsUntilExplodes, ExplosionRadius = bomb.ExplosionRadius}).ToList();
            arena.Missiles = Missiles.Select(missile => new Missile(missile)).ToList();

            return arena;
        }

        public void ImportState(Battlefield arena)
        {
            var arenaCopy = arena.ExportState();
            Board = arenaCopy.Board;
            Bots = arenaCopy.Bots;
            Bombs = arenaCopy.Bombs;
            Missiles = arenaCopy.Missiles;
        }

        public void GenerateRandomBoard()
        {
            for (var i = 0; i < Board.GetLength(0); i++)
            {
                for (var j = 0; j < Board.GetLength(1); j++)
                {
                    var tileType = _rand.Next(4) != 0 ? BoardTile.Empty : (BoardTile)(_rand.Next(3) + 1);
                    Board[i, j] = tileType;
                }
            }
        }
    }
}