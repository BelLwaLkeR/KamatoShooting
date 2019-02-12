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
    private Timer hormingShotTimer;
    private Sound sound;
    private readonly float invinsibleTime = 1;
    private Timer invinsibleTimer;
    private PatternOnce deadPattern;
    
		public Player(Vector2 position) : base("kamato",position,32,8,ActorSide.Player)
		{
      shotTimer = new CountDownTimer(0.1f);
      hormingShotTimer = new CountDownTimer(0.5f);
      sound = GameDevice.Instance().GetSound();
      invinsibleTimer = new CountDownTimer(invinsibleTime);

      motion = new Motion();
      for (int i = 0; i < 4; i++)
      {
        motion.Add(i, new Rectangle(32 * i, 0, 32, 32));
      }
      motion.Initialize(new Range(0, 3), new CountDownTimer(0.1f));
    }

		public override void Initialize()
		{
      invinsibleTimer.Initialize();
			position = new Vector2(Screen.Width/2-imageSize.X, Screen.Height*4/5);
      deadPattern = new PatternOnce();

    }

    public override void Update(GameTime gameTime)
		{
      if (invinsibleTimer.IsTime())
      {
        NormalUpdate(gameTime);
      }
      else
      {
        InvinsibleUpdate(gameTime);
      }
      motion.Update(gameTime);
      deadPattern.Update(gameTime);
    }

    private void InvinsibleUpdate(GameTime gameTime)
    {
      //position.Y -= 2;
      characterManager.ClearEnemys();
    }

    private void NormalUpdate(GameTime gameTime)
    {
      var min = Vector2.Zero;
      var max = new Vector2(Screen.Width - 64, Screen.Height - 64);
      position = Vector2.Clamp(position, min, max);
    }

    public void Shot()
    {
      if (!invinsibleTimer.IsTime()) { return; }
      ShotNormalBullet();
      ShotHormingBullet();
    }

    private void ShotNormalBullet()
    {
      if (!shotTimer.IsTime()) { return; }
      sound.PlaySE("shot");
      shotTimer.Initialize();
      for (int i = -1; i <= 1; i += 1)
      {
        Vector2 bulletPosition = centerPosition + new Vector2(16*i, -16+((i*i)%2)*8);
        characterManager.Add(new PlayerBullet(bulletPosition, new Vector2(0,-10), ActorSide.Player));
      }
    }

    private void ShotHormingBullet()
    {
      if (!hormingShotTimer.IsTime()) { return; }
      hormingShotTimer.Initialize();
      for (int i = 0; i < 6; i ++)
      {
        Vector2 bulletPosition = centerPosition + new Vector2(((i%2)*2-1) * (32+(i/2)*16), (int)(i/2)*16-32);
        characterManager.Add(new HormingBullet (bulletPosition));
      }
    }

    public override void Shutdown()
		{

    }

    public override void Draw( )
		{
      int it = (int)(invinsibleTimer.Now() * 60);
      Console.WriteLine("it:"+it);
      if (it % 5 == 0 || invinsibleTimer.IsTime())
      {
        renderer.DrawTexture(assetName, position, motion.DrawingRange());
      }
		}

    public override void Hit(Character other)
    {
      if (!invinsibleTimer.IsTime()) { return; }
      if (other.actorSide != ActorSide.Enemy) { return; }
      Die();
    }

    public override void Die()
    {
      sound.PlaySE("die");
      invinsibleTimer.Initialize();
      deadPattern.AddPattern(invinsibleTime, ResetInvincible);
      deadPattern.AddPattern(invinsibleTime, ResetInvincible);
      deadPattern.AddPattern(1, Initialize);
    }
    private void ResetInvincible()
    {
      invinsibleTimer.Initialize();
    }
  }
}
