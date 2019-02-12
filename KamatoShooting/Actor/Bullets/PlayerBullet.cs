
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
	class PlayerBullet : Character
	{
		private Vector2 velocity;

    public PlayerBullet(Vector2 position, Vector2 velocity, ActorSide side) : base("gyoza",position,16,16, side)
		{
			this.velocity = velocity;
    }

		public override void Initialize()
		{

		}

		public override void Update(GameTime gameTime)
		{
			position += velocity;
      if (position.Y > Screen.Height) { Die(); }
      if (position.Y < -64) { Die(); }
		}

		public override void Shutdown()
		{
      characterManager.Add(new BulletExplosion(position));
		}

		public override void Hit(Character other)
		{
      if (!(other is Enemy)) { return; }


        GameDevice.Instance().GetSound().PlaySE("hit");

      Die();
		}

    public override void Draw()
    {
      base.Draw();
    }


  }
}

