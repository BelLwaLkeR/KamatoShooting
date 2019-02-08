using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamatoShooting.Def;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor.Bullets
{
  class EnemyBullet : Character
  {
    private Vector2 velocity;
    public EnemyBullet( Vector2 position, Vector2 velocity) : base("EnemyBullet", position, 28, ActorSide.Enemy, 100)
    {
      this.velocity = velocity;
      characterManager.Add(this);
    }

    public override void Hit(Character other)
    {
      Console.WriteLine("EnemyBulletHit");
    }

    public override void Initialize()
    {
    }

    public override void Shutdown()
    {
    }

    public override void Update(GameTime gameTime)
    {
      position += velocity;
      if ( position.X < 0 || position.X > Screen.Width ||
           position.Y < 0 || position.Y > Screen.Height)
      {
        Die();
      }
    }
  }
}
