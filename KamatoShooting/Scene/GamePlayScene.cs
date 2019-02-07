using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using KamatoShooting.Actor;
using KamatoShooting.Def;
using KamatoShooting.Device;
using KamatoShooting.Util;
using Microsoft.Xna.Framework.Input;

namespace KamatoShooting.Scene
{
	class GamePlayScene : IScene
	{
		private CharacterManager characterManager;

		private bool isEnd;

		private Sound sound;
    private Renderer renderer;
    private Player player;
    private PatternOnce pattern;


		public GamePlayScene()
		{
			isEnd = false;
      GameDevice gameDevice = GameDevice.Instance();
			sound = gameDevice.GetSound();
      renderer = gameDevice.GetRenderer();
      characterManager = CharacterManager.GetInstance();
		}

		public void AddScore(int num)
		{
		}

		public void Draw( )
		{
			renderer.Begin();
      
			characterManager.Draw();
			//if (timer.IsTime())
			//{
			//	renderer.DrawTexture("ending", new Vector2(150, 150));
			//}
			renderer.End();
		}

		public void Initialize()
		{
      isEnd = false;
      float scrollSpeed = 1;
      characterManager.Add(new BackGround(scrollSpeed, 0));
      characterManager.Add(new BackGround(scrollSpeed, -1));
      player = new Player(new Vector2(460, 400));
      characterManager.Add(player);
      SetPattern();
    }

    public bool IsEnd()
		{
			return isEnd;
		}

		public Scene Next()
		{
			Scene nextScene = Scene.Ending;

			return nextScene;
		}

		public void Shutdown()
		{
		}

		public void Update(GameTime gameTime)
		{   // この下に更新ロジックを記述
			sound.PlayBGM("gameplaybgm");
			characterManager.Update(gameTime);
      pattern.Update(gameTime);




      if (Input.IsKeyDown(Keys.Z))
      {
        player.Shot();
      }
		}

    private void SetPattern()
    {
      pattern = new PatternOnce();
      pattern.AddPatern(new CountDownTimer(3), () => { });
      pattern.AddPatern(new CountDownTimer(3), () => { Enumerable.Range(0, 5).ToList().ForEach(e => { SpawnEnemy(new Vector2(Screen.Width / 2 + (150 * (-5 / 2 + e) - 32), -64 + (float)Math.Sin(MathHelper.ToRadians(180 / 4 * e)) * 64)); }); });
      pattern.AddPatern(new CountDownTimer(3), () => { Enumerable.Range(0, 5).ToList().ForEach(e => { SpawnEnemy(new Vector2(Screen.Width / 2 + (150 * (-5 / 2 + e) - 32), -64 + (float)Math.Sin(MathHelper.ToRadians(180 / 4 * e)) * 64)); }); });
      pattern.AddPatern(new CountDownTimer(3), () => { Enumerable.Range(0, 5).ToList().ForEach(e => { SpawnEnemy(new Vector2(Screen.Width / 2 + (150 * (-5 / 2 + e) - 32), -64 + (float)Math.Sin(MathHelper.ToRadians(180 / 4 * e)) * 64)); }); });
    }

    private void SpawnEnemy(Vector2 position)
    {
      characterManager.Add(new Enemy(position));
    }
	}
}
