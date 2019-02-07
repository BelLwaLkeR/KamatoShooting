using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using KamatoShooting.Device;
using KamatoShooting.Util;

namespace KamatoShooting.Scene
{
	class GoodEnding : IScene
	{
		private bool isEndFlag;
		private IScene backGroundScene;
		private Sound sound;
		private Timer timer;
    private Renderer renderer;

		public GoodEnding(IScene backGroundScene)
		{
			isEndFlag = false;
			this.backGroundScene = backGroundScene;
      GameDevice gameDevice = GameDevice.Instance();
			sound = gameDevice.GetSound();
      renderer = gameDevice.GetRenderer();
      
			timer = new CountDownTimer(1f);
		}

		public void Draw( )
		{
			backGroundScene.Draw();

			renderer.Begin();
			renderer.DrawTexture("ending", new Vector2(150, 150));
			renderer.DrawTexture("good", new Vector2(300, 200));
			renderer.End();
		}



		public void Initialize()
		{
			isEndFlag = false;
		}

		public bool IsEnd()
		{
			return isEndFlag;
		}

		public Scene Next()
		{
			return Scene.Title;
		}

		public void Shutdown()
		{
			sound.StopBGM();
		}

		public void Update(GameTime gameTime)
		{
			sound.PlayBGM("congratulation");
			if (Input.GetKeyTrigger(Keys.Space))
			{
				isEndFlag = true;
				sound.PlaySE("endingse");
			}

			var random = GameDevice.Instance().GetRandom();

			var angleDeg = random.Next(-100, -80);			//度数法
			var angleRad = MathHelper.ToRadians(angleDeg);	//弧度法

			var velocity = new Vector2((float)Math.Cos(angleRad), (float)Math.Sin(angleRad));
			velocity *= 20;
		}
	}
}
