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
using KamatoShooting.Actor.Enemys;
using KamatoShooting.Actor.Bullets;
using KamatoShooting.BackGround;

namespace KamatoShooting.Scene
{
  class GamePlayScene : IScene
  {
    #region その他処理
    private CharacterManager characterManager;

    private bool isEnd;

    private Sound sound;
    private Renderer renderer;
    private Player player;
    private PatternOnce pattern;
    private TimerManager timerManager;

    public GamePlayScene()
    {
      isEnd = false;
      GameDevice gameDevice = GameDevice.Instance();
      sound = gameDevice.GetSound();
      renderer = gameDevice.GetRenderer();
      characterManager = CharacterManager.GetInstance();
      timerManager = TimerManager.GetInstance();
    }

    public void AddScore(int num)
    {
    }

    public void Draw()
    {
      renderer.Begin();

      characterManager.Draw();
      renderer.End();
    }

    private void OtherInitialize()
    {
      isEnd = false;
      float scrollSpeed = 1;
      characterManager.Add(new Ground(scrollSpeed, 0));
      characterManager.Add(new Ground(scrollSpeed, -1));
      for (int i = 0; i < 5; i++)
      {
        characterManager.Add(new Cloud());
      }

      player = new Player(new Vector2(460, 400));
      characterManager.Add(player);
    }

    public void Initialize()
		{
      OtherInitialize();
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

    private void OtherUpdate(GameTime gameTime)
    {
      sound.PlayBGM("gameplaybgm");
      characterManager.Update(gameTime);
      pattern.Update(gameTime);
      timerManager.Update(gameTime);
    }




    private void SetWait(float sec)
    {
      pattern.AddPattern(sec, () => { });
    }

    private void SetWave1()
    {
      for (int i = 0; i < 5; i++)
      {
        pattern.AddPattern(0.2f, () => { new WaveEnemy(new Vector2(100, -64)); });
      }
    }
    private void SetWave2()
    {
      pattern.AddPattern(8, () => { Enumerable.Range(0, 5).ToList().ForEach(e => { new Enemy(new Vector2(Screen.Width / 2 + (150 * (-5 / 2 + e) - 32), -64 + (float)Math.Sin(MathHelper.ToRadians(180 / 4 * e)) * 64)); }); });
      pattern.AddPattern(8, () => { Enumerable.Range(0, 5).ToList().ForEach(e => { new Enemy(new Vector2(Screen.Width / 2 + (150 * (-5 / 2 + e) - 32), -64 + (float)Math.Sin(MathHelper.ToRadians(180 / 4 * e)) * 64)); }); });
      pattern.AddPattern(8, () => { Enumerable.Range(0, 5).ToList().ForEach(e => { new Enemy(new Vector2(Screen.Width / 2 + (150 * (-5 / 2 + e) - 32), -64 + (float)Math.Sin(MathHelper.ToRadians(180 / 4 * e)) * 64)); }); });

    }

    #endregion

    private void SetPattern()
    {
      pattern = new PatternOnce();
      SetWait(5);
      SetWave1();
      SetWait(3);
      SetWave1();
      SetWait(10);
      SetWave2();
      pattern.AddPattern(1, SetPattern);
    }

    public void Update(GameTime gameTime)
		{
      OtherUpdate(gameTime);
      // この下に更新ロジックを記述

      float speed = 5;

      if (Input.IsKeyDown(Keys.Left))   { player.position.X -= speed; }
      if (Input.IsKeyDown(Keys.Right))  { player.position.X += speed; }
      if (Input.IsKeyDown(Keys.Up))     { player.position.Y -= speed; }
      if (Input.IsKeyDown(Keys.Down))   { player.position.Y += speed; }


    }
  }
}
