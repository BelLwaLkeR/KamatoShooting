using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using KamatoShooting.Device;

namespace KamatoShooting.Scene
{
	class Ending : IScene
	{
		private bool isEndFlag;
		private IScene backGroundScene;
		private Sound sound;
    private Renderer renderer;
		public Ending(IScene scene)
		{
			isEndFlag = false;
			backGroundScene = scene;
      GameDevice gameDevice = GameDevice.Instance();
			sound = gameDevice.GetSound();
      renderer = gameDevice.GetRenderer();
		}

		public void Draw()
		{
			backGroundScene.Draw();

			renderer.Begin();
			renderer.DrawTexture("ending", new Vector2(150, 150));
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
		}

		public void Update(GameTime gameTime)
		{
			sound.PlayBGM("endingbgm");
			if (Input.GetKeyTrigger(Keys.Space))
			{
				isEndFlag = true;
				sound.PlaySE("endingse");
			}
		}
	}
}
