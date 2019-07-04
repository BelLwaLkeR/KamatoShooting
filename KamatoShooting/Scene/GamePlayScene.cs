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
    private GameLogic gameLogic;

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






    private void SetPattern()
    {

    }

    public void Update(GameTime gameTime)
		{
      OtherUpdate(gameTime);
      // この下に更新ロジックを記述




    }
  }


}
