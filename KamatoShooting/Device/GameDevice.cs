﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamatoShooting.Device
{
	sealed class GameDevice
	{
		private static GameDevice instance;

		private Renderer renderer;
		private Sound sound;
		private static Random random;
		private ContentManager content;
		private GraphicsDevice graphics;
		private GameTime gameTime;

		private GameDevice(ContentManager content, GraphicsDevice graphics)
		{
			this.content = content;
			this.graphics = graphics;
			renderer = new Renderer(content, graphics);
			sound = new Sound(content);
			random = new Random();
		}

		public static GameDevice Instance(ContentManager content, GraphicsDevice graphics)
		{
			if (instance == null)
			{
				instance = new GameDevice(content, graphics);
			}
			return instance;
		}

		public static GameDevice Instance()
		{
			Debug.Assert(instance != null, "Game1クラスのInitializeメソッド内で引数付きInstanceメソッドをよんでください。");
			return instance;
		}

		public void Update(GameTime gameTime)
		{
			Input.Update();
			this.gameTime = gameTime; 
		}

		public GameTime GetGameTime()
		{
			return gameTime;
		}

		public Renderer GetRenderer()
		{
			return renderer;
		}

		public Sound GetSound()
		{
			return sound;
		}

		public Random GetRandom()
		{
			return random;
		}

		public ContentManager GetContentManager()
		{
			return content;
		}

		public GraphicsDevice GetGraphicsDevice()
		{
			return graphics;
		}
	}
}
