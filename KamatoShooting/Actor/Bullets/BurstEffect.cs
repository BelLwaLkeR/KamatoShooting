using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using KamatoShooting.Device;
using KamatoShooting.Scene;
using KamatoShooting.Util;

namespace KamatoShooting.Actor
{
	class BurstEffect : Character
	{
		private Timer timer;
		private int counter;
		private readonly int pictureNum = 7;

		public BurstEffect(Vector2 position) : base("pipo-btleffect",position,0, ActorSide.Natural)
		{
		}


		public override void Hit(Character other)
		{
		}

		public override void Initialize()
		{
			counter = 0;
			timer = new CountDownTimer(0.05f);

      GameDevice.Instance().GetSound().PlaySE("gameplayse");
    }

		public override void Shutdown()
		{
		}

		public override void Update(GameTime gameTime)
		{
			timer.Update(gameTime);
			if (timer.IsTime())
			{
				counter += 1;
				timer.Initialize();
				if (counter > pictureNum)
				{
          Die();
				}
			}
			
		}
		public override void Draw()
		{
			GameDevice.Instance().GetRenderer().DrawTexture(assetName, position, new Rectangle(counter*120,0,120,120));
		}
	}
}
