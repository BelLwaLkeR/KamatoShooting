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

    private List<List<Character>> characters;

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
      InitializeAddNewCharacters();
      InitializeCharacters();
		}

    private void InitializeAddNewCharacters()
    {
      if (addNewCharacters != null)
      {
        addNewCharacters.Clear();
      }
      else
      {
        addNewCharacters = new List<Character>();
      }
    }

    private void InitializeCharacters()
    {
      if (characters == null)
      {
        characters = new List<List<Character>>();
        int actorSideNum = Enum.GetValues(typeof(ActorSide)).Length;
        for (int i = 0; i < actorSideNum; i++)
        {
          characters.Add(new List<Character>());

        }
      }
      else
      {
        for (int i = 0; i < characters.Count; i++)
        {
          if (characters[i] != null) { characters[i].Clear(); }
          else { characters[i] = new List<Character>(); }
        }
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

			foreach (var player in GetCharactersRef(ActorSide.Player))
			{
        if (player.isDead) { continue; }
				foreach (var enemy in GetCharactersRef(ActorSide.Enemy))
				{
          if (enemy.isDead) { continue; }
					if (player.IsCollision(enemy))
					{
						player.Hit(enemy);
						enemy.Hit(player);
					}
				}
			}
		}

    public void ClearEnemys()
    {
      GetCharactersRef(ActorSide.Enemy).ForEach(e => e.Damage(10000));
    }

    public void RemoveDeadCharacters()
		{
      foreach (var cs in characters)
      {
        cs.Where(c => c.isDead).ToList().ForEach(c => c.Shutdown());
        cs.RemoveAll(c => c.isDead);
      }
		}

		public void Update(GameTime gameTime)
		{
			foreach (var p in GetCharactersRef(ActorSide.Player))
			{
				p.Update(gameTime);
			}

			foreach (var e in GetCharactersRef(ActorSide.Enemy))
			{
				e.Update(gameTime);
			}

      foreach (var n in GetCharactersRef(ActorSide.Natural))
      {
        n.Update(gameTime);
      }
			foreach (var newChara in addNewCharacters)
			{
        switch (newChara.actorSide) {
          case ActorSide.Player:
					GetCharactersRef(ActorSide.Player).Add(newChara);
            break;
          case ActorSide.Enemy:
            GetCharactersRef(ActorSide.Enemy).Add(newChara);
            break;
          default:
            GetCharactersRef(ActorSide.Natural).Add(newChara);
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
      foreach (var n in GetCharactersRef(ActorSide.Natural))
      {
        n.Draw();
      }
			foreach (var p in GetCharactersRef(ActorSide.Player))
			{
				p.Draw();
			}
			foreach (var e in GetCharactersRef(ActorSide.Enemy))
			{
				e.Draw();
			}
		}

    public Player GetPlayer()
    {
      if (GetCharactersRef(ActorSide.Player).Count == 0) { return null; }
      return (Player)GetCharactersRef(ActorSide.Player).Find(c => c is Player);

    }

    private List<Character> GetCharactersRef(ActorSide side)
    {
      return characters[(int)side];
    }

    public  List<Character> GetCharacters(ActorSide side)
    {
      List<Character> c = GetCharactersRef(side);
      return  c;
    }

	}
}
