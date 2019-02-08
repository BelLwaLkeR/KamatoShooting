using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace KamatoShooting.Actor
{
  class HormingBullet : Character
  {
    private Character target;
    private Vector2 direction;
    private float speed;
    private float angle { get { return (float)Math.Atan2(direction.Y, direction.X); } }

    public HormingBullet(Vector2 position) : base("gyoza", position, 16,16, ActorSide.Player, 1, 0)
    {
    }

    public override void Initialize()
    {
      target = null;
      speed = 10;
      direction = new Vector2(0,-1);
    }

    public override void Shutdown()
    {
      characterManager.Add(new BulletExplosion(position, angle));
    }


    public override void Update(GameTime gameTime)
    {
      SearchTarget();

      if (target != null && !target.IsDead())
      {
        direction = (target.centerPosition - position);
        direction.Normalize();
      }
      MoveForward();

      if (position.X < -64) { endurance = 0; }
    }

    private void MoveForward()
    {
      position += direction * speed;
    }

    private void SearchTarget()
    {
      if (target != null) { return; }
      characterManager.GetCharacters(ActorSide.Enemy).Where(e=>e is Enemy).ToList().ForEach(e=> {
        if (target == null) { target = e; }
        else {
          if ((e.centerPosition - position).LengthSquared() < (target.centerPosition - position).LengthSquared())
          { target = e; }
        }
      });
    }

    public override void Draw()
    {
      renderer.DrawTexture(assetName, position, Vector2.One * 8, angle);
    }

    public override void Hit(Character other)
    {
      if (!(other is Enemy)) { return; }
      endurance = 0;
    }
  }
}
