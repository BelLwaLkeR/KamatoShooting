using Microsoft.Xna.Framework;
using KamatoShooting.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Actor
{
	class CharacterManager
	{
    private static CharacterManager instance;

		private List<Character> playerSide;
		private List<Character> enemySide;
    private List<Character> naturalSide;

		private List<Character> addNewCharacters;


		private CharacterManager()
		{
			Initialize();
		}

    public static CharacterManager GetInstance()
    {
      if (instance == null) { instance = new CharacterManager(); }
      return instance;
    }

		public void Initialize()
		{
			if (playerSide != null)
			{
				playerSide.Clear();
			}
			else
			{
				playerSide = new List<Character>();
			}

      if (enemySide != null)
      {
        enemySide.Clear();
      }
      else
      {
        enemySide = new List<Character>();
      }
      if (naturalSide != null)
      {
        naturalSide.Clear();
      }
      else
      {
        naturalSide = new List<Character>();
      }

      if (addNewCharacters != null)
			{
				addNewCharacters.Clear();
			}
			else
			{
				addNewCharacters = new List<Character>();
			}
		}

		public Character Add(Character character)
		{
			if (character == null)
			{
				return null;
			}
			addNewCharacters.Add(character);
      return character;
		}

		private void HitToCharacters()
		{
			foreach (var player in playerSide)
			{
				foreach (var enemy in enemySide)
				{
					if (player.IsLost() || enemy.IsLost())
					{
						continue;
					}
					if (player.IsCollision(enemy))
					{
						player.Hit(enemy);
						enemy.Hit(player);
					}
				}
			}
		}

		public void RemoveDeadCharacters()
		{
			playerSide.RemoveAll(p => p.IsLost());
			enemySide.RemoveAll(e => e.IsLost());
		}

		public void Update(GameTime gameTime)
		{
			foreach (var p in playerSide)
			{
				p.Update(gameTime);
			}

			foreach (var e in enemySide)
			{
				e.Update(gameTime);
			}

      foreach (var n in naturalSide)
      {
        n.Update(gameTime);
      }
			foreach (var newChara in addNewCharacters)
			{
        switch (newChara.actorSide) {
          case ActorSide.Player:
					playerSide.Add(newChara);
            break;
          case ActorSide.Enemy:
            enemySide.Add(newChara);
            break;
          default:
            naturalSide.Add(newChara);
            break;
        }
        newChara.Initialize();
			}

			addNewCharacters.Clear();
			HitToCharacters();
			RemoveDeadCharacters();
		}

		public void Draw( )
		{
      foreach (var n in naturalSide)
      {
        n.Draw();
      }
			foreach (var p in playerSide)
			{
				p.Draw();
			}
			foreach (var e in enemySide)
			{
				e.Draw();
			}
		}

    public Player GetPlayer()
    {
      if (playerSide.Count == 0) { return null; }
      return (Player)playerSide[0];
    }

	}
}
