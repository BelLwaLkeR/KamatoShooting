using Microsoft.Xna.Framework;
using KamatoShooting.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Scene
{
	class SceneManager
	{
		private Dictionary<Scene, IScene> scenes =
			new Dictionary<Scene, IScene>();

		private IScene currentScene = null;

		public SceneManager()
		{
		}

		public void Add(Scene name, IScene scene)
		{
			if (scenes.ContainsKey(name))
			{
				return;
			}
			scenes.Add(name, scene);
      if (scenes.Count == 1)
      {
        Change(name);
      }
		}

		public void Change(Scene name)
		{
			if (currentScene != null)
			{
				currentScene.Shutdown();
			}

			currentScene = scenes[name];
			currentScene.Initialize();
		}

		public void Update(GameTime gameTime)
		{
			if (currentScene == null)
			{
				return;
			}

			currentScene.Update(gameTime);
			if (currentScene.IsEnd())
			{
				Change(currentScene.Next());
			}
		}
		public void Draw( )
		{
			if (currentScene == null) { return; }
			currentScene.Draw();
		}

	}
}
