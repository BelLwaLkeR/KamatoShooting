using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using KamatoShooting.Device;
using KamatoShooting.Def;
using KamatoShooting.Scene;
using KamatoShooting.Util;

namespace KamatoShooting.Actor
{
	class Player : Character
	{
		private Motion motion;
    private Timer shotTimer;
    

		public Player(Vector2 position) : base("kamato",position,32,ActorSide.Player)
		{
      shotTimer = new CountDownTimer(0.2f);
      characterManager = CharacterManager.GetInstance();
		}

		public override void Initialize()
		{
			position = new Vector2(300, 400);
			motion = new Motion();

			for (int i = 0; i < 4; i++){
				motion.Add(i, new Rectangle(32 * i, 0, 32, 32));
			}
			motion.Initialize(new Range(0, 3), new CountDownTimer(0.1f));



		}

		public override void Update(GameTime gameTime)
		{
			Vector2 velocity = Input.Velocity();
			float speed = 5.0f;
			position = position + velocity * speed;

			var min = Vector2.Zero;
			var max = new Vector2(Screen.Width - 64, Screen.Height - 64);
			position = Vector2.Clamp(position, min, max);
      shotTimer.Update(gameTime);
			motion.Update(gameTime);
		}

    public void Shot()
    {
      if (!shotTimer.IsTime()) { return; }
      for (int i = 0; i < 3; i++)
      {
        shotTimer.Initialize();
        Vector2 bulletPosition = position + new Vector2(-8 + i * 16, ((i + 1) % 2) * 8 - 16);
        characterManager.Add(new Bullet(bulletPosition, new Vector2(0, -10), ActorSide.Player));
      }
    }


		public override void Shutdown()
		{

		}


		public override void Draw( )
		{
			renderer.DrawTexture(assetName, position, motion.DrawingRange());
		}
	}
}
