using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using KamatoShooting.Def;
using KamatoShooting.Device;
using KamatoShooting.Scene;
using KamatoShooting.Util;

namespace KamatoShooting.Actor
{
  abstract	class EnemyBlack : Character
	{
		private Random random;
		private Timer timer;
		private bool isDisplay;
		private readonly int Impression = 10;
		private int displayCount;

    public EnemyBlack() 
      : base("black",Vector2.Zero, 64, ActorSide.Enemy, 1, 1)
    {
      
    }
    
    public override void Initialize()
		{
			var gameDevice = GameDevice.Instance();
			random = gameDevice.GetRandom();

			state = State.Alive;
			timer = new CountDownTimer(0.25f);
			isDisplay = true;
			displayCount = Impression;
		}
    
    protected abstract void AliveUpdate(GameTime gameTime);
		private void AliveDraw()
		{
			base.Draw();
		}
		private void DyingUpdate(GameTime gameTime)
		{
			timer.Update(gameTime);
			if (timer.IsTime())
			{
				isDisplay = !isDisplay;
				displayCount -= 1;
				timer.Initialize();
			}
			if (displayCount <= 0)
			{
				state = State.Dead;
				timer.Initialize();
				displayCount = Impression;
				isDisplay = true;
			}
		}
		private void DyingDraw( )
		{
			if (isDisplay)
			{
				renderer.DrawTexture(assetName, position, Color.Red);
			}
			else
			{
				base.Draw();
			}
		}
		private void DeadUpdate(GameTime gameTime)
		{
			characterManager.Add(new BurstEffect(position));
      Extinction();
		}
		private void DeadDraw( )
		{

		}

		public override void Update(GameTime gameTime)
		{
			switch (state)
			{
				case State.Alive:
						   AliveUpdate(gameTime);
					break;
				case State.Dying:
						   DyingUpdate(gameTime);
					break;
				case State.Dead:
						   DeadUpdate(gameTime);
					break;
			}
		}
		public override void Shutdown()
		{

		}

		public override void Hit(Character other)
		{

			if (state != State.Alive)
			{
				return;
			}
      base.Hit(other);
      if (IsDead())
      {
        state = State.Dying;
      }
		}

		public override void Draw( )
		{
			
			switch (state)
			{
				case State.Alive:
					AliveDraw();
					break;
				case State.Dying:
					DyingDraw();
					break;
				case State.Dead:
					DeadDraw();
					break;
			}
		}
	}
}
