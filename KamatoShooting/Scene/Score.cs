using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using KamatoShooting.Device;

namespace KamatoShooting.Scene
{
	class Score
	{
		private int score;
		private int poolScore;
		
		public Score()
		{
			Initialize();
		}

		public void Initialize()
		{
			score = 0;
			poolScore = 0;
		}

		public void Add()
		{
			poolScore = poolScore + 1;
		}

		public void Add(int num)
		{
			poolScore = poolScore + num;
		}

		public void Update(GameTime gameTime)
		{
			if (poolScore > 0)
			{
				score = score + 1;
				poolScore = poolScore - 1;
			}
			else if (poolScore < 0)
			{
				score -= 1;
				poolScore += 1;
			}
		}

		public void Draw(Renderer renderer)
		{
			renderer.DrawTexture("score", new Vector2(50, 10));
			renderer.DrawNumber("number", new Vector2(250,13),score);
		}

		public void Shutdown()
		{
			score = score + poolScore;
			if (score < 0)
			{
				score = 0;
			}
			poolScore = 0;
		}

		public int GetScore()
		{
			int currentScore = score + poolScore;
			if (currentScore < 0)
			{
				currentScore = 0;
			}
			return currentScore;
		}
	}
}
